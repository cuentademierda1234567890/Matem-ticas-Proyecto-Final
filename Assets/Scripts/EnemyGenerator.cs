using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyGenerator : MonoBehaviour
{
    public GameObject win_panel;

    private GameObject generadorEnemigos_uno;
    public GameObject enemyPreFab;

    public static int score = 1;
    public GameObject enemigo_1;
    //private GameObject enemigo_2;

    private float Fila_1 = 0f;
    //private float Fila_2 = 0f;
    //private float Fila_3 = 0f;
    //private float Fila_4 = 0f;

    void Start()
    {
        generadorEnemigos_uno = GameObject.Find("Spawn_Vector_1");
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemigo").Length == 0)
        {
            win_panel.SetActive(true);
        }

        Fila_1 += Time.deltaTime;

        if (Fila_1 >= .5f)
        {
            //Instancia a la nave enemiga en la posición que le doy de segundo parámetro
            //Instantiate(enemyPreFab, generadorEnemigos_uno.gameObject.transform.position , Quaternion.identity);
            Instantiate(enemigo_1);
            Fila_1 = 0f;
        }

    }
}
