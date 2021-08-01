using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalQuartoManager : scene_maneger
{

    GameObject Fala;
    Talk avo;

    private void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");

        avo = Fala.transform.GetChild(0).gameObject.GetComponent<Talk>();
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.2":
                if (avo.estado.terminou)
                {
                    GM.SetGameState("ATO1.3");
                    GM.updateScene(game);
                }

                break;
        }
    }
}