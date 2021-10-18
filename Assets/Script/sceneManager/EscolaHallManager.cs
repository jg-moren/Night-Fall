using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolaHallManager : scene_manager
{

    GameObject Fala;
    Talk amigos;
    GameObject transition;
    GameObject Personagem;
    personagem ronaldo;
    personagem lucas;
    Talk prof;


    void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");
        Personagem = GameObject.FindGameObjectWithTag("Personagens");
        transition = GameObject.FindGameObjectWithTag("Transition");
        prof = Fala.transform.GetChild(1).gameObject.GetComponent<Talk>();

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
                }

                break;
            case "ATO1.5":
                if (amigos.estado.terminou)
                {
                    ronaldo.move = moveState.mover;
                    lucas.move = moveState.mover;

                    Fala.transform.GetChild(0).gameObject.SetActive(false);
                }
                if(prof.estado.idPergunta == 7)
                {
                    Vector2[] move_to = { new Vector2(20,3) };
                    ronaldo.movePoints = move_to;
                    lucas.movePoints = move_to;
                    ronaldo.ResetValue();
                    lucas.ResetValue();
                }
                if (ronaldo.transform.position.x >= 19.5) ronaldo.gameObject.SetActive(false);
                if (lucas.transform.position.x >= 19.5) lucas.gameObject.SetActive(false);
                if (prof.estado.terminou){
                    GM.SetGameState("ATO1.5.1");
                    transition.transform.GetChild(0).GetComponent<transition>().ativar("Escola_Andar", new Vector3(15, 1));
                }

                break;
            case "ATO1.8":
                if (amigos.estado.terminou)
                {
                    ronaldo.move = moveState.mover;
                    lucas.move = moveState.mover;

                    Fala.transform.GetChild(0).gameObject.SetActive(false);
                }
                if (prof.estado.idPergunta == 4)
                {
                    Vector2[] move_to = { new Vector2(20, 3) };
                    ronaldo.movePoints = move_to;
                    lucas.movePoints = move_to;
                    ronaldo.ResetValue();
                    lucas.ResetValue();
                }
                if (ronaldo.transform.position.x >= 19.5) ronaldo.gameObject.SetActive(false);
                if (lucas.transform.position.x >= 19.5) lucas.gameObject.SetActive(false);
                if (prof.estado.terminou)
                {
                    prof.gameObject.SetActive(false);

                }
                break;

        }
    }
}