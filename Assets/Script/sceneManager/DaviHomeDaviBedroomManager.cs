using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaviHomeDaviBedroomManager : scene_manager
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

                if (cadeira.GetComponent<Talk>().estado.idPergunta == 2) {
                    GM.SetGameState("ATO1.3.1");
                    transition.transform.GetChild(0).GetComponent<transition>().ativar("DaviHome_DaviBedroom",new Vector3(2.5f,0.4f));
                }if(cadeira.GetComponent<Talk>().estado.terminou && cadeira.GetComponent<Talk>().estado.Resposta == "Não"){
                    GM.SetGameState("ATO1.3.1");
                }
                break;
            case "ATO1.9":
                if (talk.transform.GetChild(3).gameObject.GetComponent<Talk>().estado.Resposta == "Sim")
                {
                    transition.transform.GetChild(0).GetComponent<transition>().ativar("Sonho", new Vector3(0,0));
                }
                break;
            case "ATO1.9.1":
                if (talk.transform.GetChild(3).gameObject.GetComponent<Talk>().estado.terminou)
                {
                    

                    transition.transform.GetChild(0).GetComponent<transition>().ativar("Creditos", new Vector3(0, 0));
                }
                break;



        }

    }
}
