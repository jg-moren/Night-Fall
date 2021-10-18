using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiva_Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Vector2 direcao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direcao * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        if (transform.position.x < -20 || 20 < transform.position.x) GameObject.Destroy(gameObject);
    }
}
