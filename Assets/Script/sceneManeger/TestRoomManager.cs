using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoomManager : scene_maneger
{


    GameObject Fala;

    void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");
    }


    private void Update()
    {
        GM.updateScene(game);

        switch (GM.GetGameState())
        {
            case "ATO1.1":

                break;
        }
    }
}
