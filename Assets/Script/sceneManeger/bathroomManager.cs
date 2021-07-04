using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathroomManager : MonoBehaviour
{
    gamemanager GM;
    public scenes scene;

    GameObject Fala;

    void Awake()
    {
        GM = gamemanager.Instance;
        Fala = GameObject.FindGameObjectWithTag("Fala");
    }

    void Start()
    {
        GM.updateScene(scene);
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.1":

                break;
        }
    }
}
