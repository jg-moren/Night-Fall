using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolaAndarManager : scene_manager
{

    GameObject Fala;
    GameObject transition;

    void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");
        transition = GameObject.FindGameObjectWithTag("Transition");
    }

    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.8":
                if(Fala.transform.GetChild(0).GetComponent<Talk>().estado.terminou){
                    transition.transform.GetChild(0).GetComponent<transition>().ativar("Escola_Rua", new Vector3(0, 12));
                }
                break;
        }
    }
}