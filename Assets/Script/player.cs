using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 0.1f;
    Animator anim;
    Rigidbody2D rb;
    Vector2 movement;
    public bool isStop = false;
    

    //configura o personagem para que na troca de cenas ele nao comece errado
    void Awake()
    {
        Vector3 initialState = new Vector3(PlayerPrefs.GetFloat("Save:position.x"), PlayerPrefs.GetFloat("Save:position.y"), 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        transform.position = initialState;
        anim.speed = speed / 5;
        isStop = false;
    }

    //PROVISORIO para mostrar o ato atual na tela
    private void OnGUI()
    {
        //GUILayout.TextArea(PlayerPrefs.GetString("gameState"));
    }
    private void FixedUpdate()
    {
        if (!isStop)
        {
            movement.x += Input.GetAxisRaw("Horizontal");
            movement.y += Input.GetAxisRaw("Vertical");
        
            movement.x = movement.x / 2;
            movement.y = movement.y / 2;


            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
            if (movement.x != 0) anim.SetFloat("Horizontal", movement.x);
            if (movement.y != 0) anim.SetFloat("Vertical", movement.y);
            anim.SetBool("Move", (Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0));
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }
}
