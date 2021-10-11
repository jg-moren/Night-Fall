using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{

    GameObject player;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        sprite.sortingOrder = (player.transform.position.y > transform.position.y) ? 1 : -1;

    }
}
