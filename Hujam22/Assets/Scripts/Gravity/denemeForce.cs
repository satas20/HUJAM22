using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class denemeForce : MonoBehaviour
{
    private Rigidbody2D rb;
    private int force = 3;
    private Vector2 kuvvet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        kuvvet = new Vector2(1,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(kuvvet, ForceMode2D.Force);
    }
}
