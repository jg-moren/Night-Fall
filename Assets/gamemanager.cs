using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public void SetGameState(string state)
    {
        PlayerPrefs.SetString("gameState", state);//define em qual dos estados estara
    }
    public string GetGameState()
    {
        return PlayerPrefs.GetString("gameState");
    }
    public void updateScene(game game)  //aualizara a cena. scene_maneger.Start
    {


        //define os gameobjects como o gameobject com a tag da cena atual
        GameObject talk = GameObject.FindGameObjectWithTag("Talk");
        GameObject transition = GameObject.FindGameObjectWithTag("Transition");
        GameObject personagens = GameObject.FindGameObjectWithTag("Personagens");

        foreach (var atoAtual in game.atos)
        {


            if (atoAtual.name == GetGameState())
            {
                rooms salaAtual = getRoom(SceneManager.GetActiveScene().name, atoAtual.ato);

                for (int x = 0; x < salaAtual.talk.Length; x++)
                {
                    talk.transform.GetChild(x).gameObject.SetActive(salaAtual.talk[x].ativo);
                    talk.transform.GetChild(x).GetComponent<Talk>().opicional = salaAtual.talk[x].opicional;
                    talk.transform.GetChild(x).GetComponent<Talk>().dialogues = salaAtual.talk[x].dialogo;
                }


                for (int x = 0; x < salaAtual.personagens.Length; x++)
                {
                    personagens.transform.GetChild(x).gameObject.SetActive(salaAtual.personagens[x].ativo);
                    personagens.transform.GetChild(x).transform.position = salaAtual.personagens[x].initialPosition;
                    personagens.transform.GetChild(x).GetComponent<personagem>().movePoints = salaAtual.personagens[x].pointPositions;
                    personagens.transform.GetChild(x).GetComponent<personagem>().speed = salaAtual.personagens[x].speed;
                    personagens.transform.GetChild(x).GetComponent<personagem>().move = salaAtual.personagens[x].move;
                }

                //define o loked do gameobject = isLocked das cenas
                for (int x = 0; x < salaAtual.transition.Length; x++)
                {
                    transition.transform.GetChild(x).GetComponent<transition>().locked = salaAtual.transition[x].isLoked;
                }
            }



        }
    }

    rooms getRoom(string RoomName, atos AtoAtual)
    {
        if (RoomName == "Monologo") return AtoAtual.Monologo;
        if (RoomName == "DaviHome_DaviBedroom") return AtoAtual.DaviHome_DaviBedroom;
        if (RoomName == "DaviHome_Hall") return AtoAtual.DaviHome_Hall;
        if (RoomName == "DaviHome_Room") return AtoAtual.DaviHome_Room;
        if (RoomName == "DaviHome_Rua") return AtoAtual.DaviHome_Rua;
        if (RoomName == "Escola_Andar") return AtoAtual.Escola_Andar;
        if (RoomName == "Escola_DaviSala") return AtoAtual.Escola_DaviSala;
        if (RoomName == "Escola_Hall") return AtoAtual.Escola_Hall;
        if (RoomName == "Escola_Rua") return AtoAtual.Escola_Rua;
        if (RoomName == "Hospital_Andar") return AtoAtual.Hospital_Andar;
        if (RoomName == "Hospital_Quarto") return AtoAtual.Hospital_Quarto;
        if (RoomName == "Hospital_Recepcao") return AtoAtual.Hospital_Recepcao;
        if (RoomName == "Hospital_Rua") return AtoAtual.Hospital_Rua;
        if (RoomName == "TestRoom") return AtoAtual.TestRoom;
        return null;
    }
    /*
    //sla oq isso faz ;-;
    private static gamemanager instance;


    public static gamemanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new gamemanager();
            }

            return instance;
        }
    }*/
}
