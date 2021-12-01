using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolaRuaManager : scene_manager
{

    GameObject Fala;

    

    void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.5.1":
                if (Fala.transform.GetChild(1).gameObject.GetComponent<Talk>().estado.terminou)
                {
                    Fala.transform.GetChild(1).gameObject.SetActive(false);
                    GM.SetGameState("ATO1.6");
                }
                break;
            case "ATO1.8":
                if (Fala.transform.GetChild(1).gameObject.GetComponent<Talk>().estado.terminou)
                {
                    Fala.transform.GetChild(1).gameObject.SetActive(false);
                    GM.SetGameState("ATO1.9");
                }
                break;
            default:

                break;
        }

    }
}
