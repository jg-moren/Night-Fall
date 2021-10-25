using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiva_Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public bool play_sound = false;
    public float speed;
    public Vector2 direcao;
    public float tamanho_do_rabo_de_cometa_do_coisaa_que_tem_um_rabo_de_cometa_tipo_almondega_de_carne;
    public float particle_size;
    ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direcao * speed;
        particle.startLifetime = particle_size;
        if(play_sound)GetComponent<AudioSource>().Play();
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
//o henrique é muito legal