using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 0.1f;
    Animator anim;
    Rigidbody2D rb;
    Vector2 movement;
    public VectorValue playerState;
    public bool isStop = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        transform.position = playerState.initialValue;

    }

    // Update is called once per frame
    void Update()
    {
        movement.Set(0, 0);
        if (!isStop) { 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        }
        rb.MovePosition(rb.position+ movement * speed * Time.fixedDeltaTime);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetBool("Move", (movement != new Vector2(0, 0))); 
        anim.speed = speed /5;

    }
}
