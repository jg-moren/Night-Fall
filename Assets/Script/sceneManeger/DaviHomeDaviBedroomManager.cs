using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaviHomeDaviBedroomManager : scene_maneger
{
    GameObject talk;
    GameObject transition;


    private void Start()
    {
        talk = GameObject.FindGameObjectWithTag("Talk");
        transition = GameObject.FindGameObjectWithTag("Transition");

    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.3":

                GameObject fala = talk.transform.GetChild(0).gameObject;
                GameObject cadeira = talk.transform.GetChild(1).gameObject;
                if (fala.GetComponent<Talk>().estado.terminou) fala.SetActive(false);

                if (cadeira.GetComponent<Talk>().estado.terminou && cadeira.GetComponent<Talk>().estado.Resposta == "Sim") {
                    GM.SetGameState("ATO1.3.1");
                    transition.transform.GetChild(0).GetComponent<transition>().ativar("DaviHome_DaviBedroom",new Vector3(2.5f,0.4f));
                }if(cadeira.GetComponent<Talk>().estado.terminou && cadeira.GetComponent<Talk>().estado.Resposta == "Não"){
                    GM.SetGameState("ATO1.3.1");
                }
                break;
        }

    }
}
