using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum moveState { nao_mover, ao_colidir,mover };

public class personagem : MonoBehaviour
{
    GameObject player;
    SpriteRenderer sprite;
    public moveState move;
    Animator anim;
    public Vector2[] movePoints;
    bool isMove =false;
    public float speed=0.1f;
    int pointId = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        anim.speed = (speed / 6) / transform.lossyScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //resetar o caminho que ele fara
    public void ResetValue()
    {
        pointId = 0;
    }

    //se ele colidir com o jogado e estive na opcao de move ao colidir ele se movimenta
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && (int)move == 1){
            isMove = true;
        }
    }


    void Update()
    {

        // 2 = mover , 0 = nao mover
        if ((int)move == 2) isMove = true;
        if ((int)move == 0) isMove = false;

        //corrigir colisao com o player para nao ficare m an mesma camada
        sprite.sortingOrder = (player.transform.position.y > transform.position.y)? 1: -1;

        //move se isMove = true e pive rmais pontos para ir
        anim.SetBool("Move", (isMove && (movePoints.Length > pointId)));

        if (isMove && (movePoints.Length>pointId))
        {
            Vector3 addmove = new Vector3(0,0,0);
            if (transform.position.x.ToString("0.0") != movePoints[pointId].x.ToString("0.0")) addmove.x = (movePoints[pointId].x > transform.position.x) ? speed : -speed;
            if (transform.position.y.ToString("0.0") != movePoints[pointId].y.ToString("0.0")) addmove.y = (movePoints[pointId].y > transform.position.y) ? speed : -speed;

            transform.position += addmove * Time.deltaTime;
            anim.SetFloat("Vertical",   (movePoints[pointId].y - transform.position.y) );
            anim.SetFloat("Horizontal", (movePoints[pointId].x - transform.position.x) );

            if (((Vector2)transform.position).ToString("0.0") == movePoints[pointId].ToString("0.0")) pointId += 1;
        }


    }

}
