using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiva : MonoBehaviour
{
    public GameObject ball;

    public Sprite spr_atacar;
    Sprite spr_normal;
    public float vida = 100;
    SpriteRenderer spr;


    AudioSource som;
    public AudioClip growl;

    bool isMove = false;
    float speed = 0.1f;
    Vector3 movePoint;


    void Start()
    {
        som = GetComponent<AudioSource>();
        movePoint = transform.position;
        spr = gameObject.GetComponent<SpriteRenderer>();
        spr_normal = spr.sprite;

    }
    void Update()
    {
        isMove = !((transform.position).ToString("0.0") == movePoint.ToString("0.0"));
        if (isMove)
        {
            float x = (movePoint.x - transform.position.x);
            float y = (movePoint.y - transform.position.y);
            transform.position += new Vector3(x,y,0)*Time.deltaTime*speed;
        }
    }
    public void setSprAtacar(bool ativado)
    {

        if (ativado){
            spr.sprite = spr_atacar;
        }else{ 
            spr.sprite = spr_normal;
        }
    }
    public void atacar(Vector3 alvo,float speed,float size,bool sound)
    {
        GameObject objeto = GameObject.Instantiate(ball, transform.position, transform.rotation);
        Raiva_Ball scr_ball = objeto.GetComponent<Raiva_Ball>();
        scr_ball.speed = speed;
        scr_ball.direcao = alvo - transform.position;
        scr_ball.particle_size = size;
        scr_ball.play_sound = sound;
    }
    public void moveTo(Vector3 _position,float _speed)
    {
        movePoint = _position;
        speed = _speed;
    }
 
    public void rugir()
    {
        som.PlayOneShot(growl);
    }

}
