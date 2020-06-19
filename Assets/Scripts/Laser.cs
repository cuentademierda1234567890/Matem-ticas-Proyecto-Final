﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed;

    private EnemyGenerator enemyGenerator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemyGenerator = new EnemyGenerator();
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Score: " + EnemyGenerator.score++;     
        Destroy(other.gameObject);

        //Debug.Log("Choca");
    }

}