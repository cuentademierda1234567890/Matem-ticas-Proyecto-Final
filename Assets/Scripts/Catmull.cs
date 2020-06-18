using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catmull : MonoBehaviour
{
    // cantidad de tramos
    private int routes;

    // número de tramos
    private int routeToGo;

    // Es el paso (parametro de interpolación)
    private float tParam;

    //Determina la posición de la nave
    private Vector3 NavPosition;

    // velocidad del cuerpo
    private float speed;
    private bool coroutineAllowed;
    public Vector3[] point = new Vector3[15];

    void Start()
    {
        routes = 12;
        routeToGo = 0;
        tParam = 0f;
        speed = 1.50f;
        coroutineAllowed = true;

        point[0] = new Vector3(-6f, -1f, 10f);
        point[1] = new Vector3(-6f, 0.5f, 9f);
        point[2] = new Vector3(-5.7f, 1.5f, 5f);
        point[3] = new Vector3(-3.5f, 3f, 0f);
        point[4] = new Vector3(0f, 3.5f, -2f);
        point[5] = new Vector3(3.3f, 4.5f, 0f);
        point[6] = new Vector3(3.3f, 3.5f, 5f);
        point[7] = new Vector3(0f, 2f, 7f);
        point[8] = new Vector3(-3.3f, 0.5f, 5f);
        point[9] = new Vector3(-3.3f, -0.5f, 0f);
        point[10] = new Vector3(0f, 1f, -2f);
        point[11] = new Vector3(3.5f, 2f, 0f);
        point[12] = new Vector3(5.5f, 1f, 4.5f);
        point[13] = new Vector3(6f, 0.5f, 9f);
        point[14] = new Vector3(6f, -1f, 10f);
    }

    void Update()
    {
        if (coroutineAllowed)
            StartCoroutine(GoByTheRoute(routeToGo));
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = point[routeNumber];
        Vector3 p1 = point[routeNumber + 1];
        Vector3 p2 = point[routeNumber + 2];
        Vector3 p3 = point[routeNumber + 3];

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speed;

            NavPosition = (2 * Mathf.Pow(tParam, 3) - 3 * Mathf.Pow(tParam, 2) + 1) * p1 +
                (-2 * Mathf.Pow(tParam, 3) + 3 * Mathf.Pow(tParam, 2)) * p2 +
                (Mathf.Pow(tParam, 3) - 2 * Mathf.Pow(tParam, 2) + tParam) * 0.5f * (p2 - p0) +
                (Mathf.Pow(tParam, 3) - Mathf.Pow(tParam, 2)) * 0.5f * (p3 - p1);

            transform.LookAt(NavPosition);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

            transform.position = NavPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routeToGo += 1;

        if (routeToGo > routes - 1)
            routeToGo = 0;

        coroutineAllowed = true;
    }

}
