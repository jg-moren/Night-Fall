using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolaDaviSalaManager : scene_maneger
{

    GameObject Fala;
    Talk professor;


    void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");

        professor = Fala.transform.GetChild(0).gameObject.GetComponent<Talk>();
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.1":
                if (professor.estado.terminou)
                {
                    GM.SetGameState("ATO1.2");
                    GM.updateScene(game);
                }

                break;
        }
    }
}