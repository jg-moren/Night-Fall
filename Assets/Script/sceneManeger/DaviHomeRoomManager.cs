using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaviHomeRoomManager : scene_maneger
{
    player player;
    GameObject talk;
    GameObject transition;

    public Dialogues sair_com;
    public Dialogues outro_com;

    private void Start()
    {
        player = FindObjectOfType<player>();
        talk = GameObject.FindGameObjectWithTag("Talk");
        transition = GameObject.FindGameObjectWithTag("Transition");
        switch (GM.GetGameState())
        {
            case "ATO1.3":
                transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.3":
                if (talk.transform.GetChild(1).GetComponent<Talk>().estado.terminou) talk.transform.GetChild(1).gameObject.SetActive(false);

                if (player.transform.position.y > 9.5)talk.transform.GetChild(3).gameObject.SetActive(true);
                if(player.transform.position.y < 8.5)talk.transform.GetChild(3).gameObject.SetActive(false);

                if (talk.transform.GetChild(5).GetComponent<Talk>().estado.Resposta == "Sim")
                {
                    talk.transform.GetChild(5).gameObject.SetActive(false);
                    transform.GetChild(0).gameObject.SetActive(false);
                    talk.transform.GetChild(4).gameObject.SetActive(true);
                    talk.transform.GetChild(2).GetComponent<Talk>().dialogues = outro_com;
                    talk.transform.GetChild(3).GetComponent<Talk>().dialogues = sair_com;
                }
                if (talk.transform.GetChild(4).GetComponent<Talk>().estado.idPergunta == 1)
                {
                    talk.transform.GetChild(4).gameObject.SetActive(false);
                    talk.transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(0).gameObject.transform.position = new Vector3(15.5f,2.5f,0);
                    transform.GetChild(0).gameObject.SetActive(true);
                    transition.transform.GetChild(0).GetComponent<transition>().locked = false;
                }
                break;
            case "ATO1.3.1":
                if (talk.transform.GetChild(4).GetComponent<Talk>().estado.terminou)
                {
                    GM.SetGameState("ATO1.4");
                    transition.transform.GetChild(0).GetComponent<transition>().ativar("Sonho", new Vector3(0, 0));
                }
                break;
        }
        
    }
}
