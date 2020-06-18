using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMovement : MonoBehaviour
{
    private float yMovement;
    private float timeDestroy = 00f;
    private int tiempoVida = 0;
    void Start()
    {
        tiempoVida = Random.Range(5, 7);
        yMovement = Random.Range(-0.1f, -1f) * Time.deltaTime;
        //yMovement = Random.Range(-0.01f, -0.06f) * Time.deltaTime;
        var starSize = Random.Range(0.01f, 0.1f);
        var a = new Vector3(starSize , starSize , starSize);
        gameObject.transform.localScale = a;
    }


    void Update()
    {
        gameObject.transform.Translate(0, yMovement, 0);
        timeDestroy += Time.deltaTime;


        if ((timeDestroy >= tiempoVida) || (gameObject.transform.position.z <= -9.75f))
        {
            RandomStars.numEstrellas--;
            Destroy(this.gameObject);
        }
    }
}
