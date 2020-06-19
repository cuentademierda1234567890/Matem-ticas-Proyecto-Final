using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStars : MonoBehaviour
{
    public GameObject stars;
    private Vector3 randomVector;
    private Renderer renderer;
    private float Yoffset = 0f;
    [SerializeField]
    private float Y_offsetSpeed;
    public static int numEstrellas = 0;
    [SerializeField]
    private int estrellasEnPantalla;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        Debug.Log(gameObject.transform.localScale.x);
    }


    void Update()
    {
        //randomVector = new Vector3(Random.Range(-30,30) , Random.Range(-15,3) , Random.Range(-50,50));
        randomVector = new Vector3(Random.Range(-13/2f, 13/2f), Random.Range(-5f , 0), Random.Range(-19.5f/2, 19.5f / 2));

        if(numEstrellas < estrellasEnPantalla)
        {
            Instantiate(stars, randomVector, transform.rotation);
            numEstrellas++;
        }

        renderer.material.mainTextureOffset = new Vector2(0 ,Yoffset += Time.deltaTime * Y_offsetSpeed);

        //Debug.Log(numEstrellas);

    }

    

}
