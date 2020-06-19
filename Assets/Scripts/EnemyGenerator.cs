using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyGenerator : MonoBehaviour
{
    public static TextMeshProUGUI scoreText;
    public static int score = 0;

    public GameObject enemigo_1;
    //private GameObject enemigo_2;

    private float Fila_1 = 0f;
    //private float Fila_2 = 0f;
    //private float Fila_3 = 0f;
    //private float Fila_4 = 0f;

    //void Start()
    //{

    //}

    void Update()
    {
        Fila_1 += Time.deltaTime;

        if (Fila_1 >= .5f)
        {
            Instantiate(enemigo_1);
            Fila_1 = 0f;
        }

    }
}
