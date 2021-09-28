using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiva_Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * speed;
    }

    void Update()
    {
        
    }
}
