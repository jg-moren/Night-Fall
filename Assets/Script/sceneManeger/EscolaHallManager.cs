using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolaHallManager : scene_maneger
{

    GameObject Fala;
    Talk amigos;
    GameObject Personagem;
    personagem ronaldo;
    personagem lucas;


    void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");
        Personagem = GameObject.FindGameObjectWithTag("Personagens");

        ronaldo = Personagem.transform.GetChild(0).gameObject.GetComponent<personagem>();
        lucas = Personagem.transform.GetChild(1).gameObject.GetComponent<personagem>();

        amigos = Fala.transform.GetChild(0).gameObject.GetComponent<Talk>();
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.1":
                if (amigos.estado.terminou)
                {
                    ronaldo.move = moveState.mover;
                    lucas.move = moveState.mover;
                    Fala.transform.GetChild(0).gameObject.SetActive(false);
                    //print("aaaaaaaaaa");
                }

                break;
        }
    }
}