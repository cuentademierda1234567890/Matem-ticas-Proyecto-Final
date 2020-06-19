using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 0f;
    private Rigidbody rb;

    public GameObject spawnSpot;
    public GameObject shot_prefab;

    public float fireRate;
    private float nextFire;


    void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        //gameObject.transform.position = new Vector3(0,0, -9.11f);
    }

    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(movimientoHorizontal * speed, rb.velocity.y, rb.velocity.z);
        rb.velocity = movement;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -6.199996f, 6.049995f), 0f, -9.11f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot_prefab, spawnSpot.transform.position, spawnSpot.transform.rotation);
        }
    }
}
