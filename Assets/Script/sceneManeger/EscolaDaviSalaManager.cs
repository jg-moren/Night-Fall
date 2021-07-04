using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolaDaviSalaManager : MonoBehaviour
{
    gamemanager GM;
    public scenes scene;

    GameObject Fala;
    Talk professor;
    void Awake()
    {
        GM = gamemanager.Instance;
        Fala = GameObject.FindGameObjectWithTag("Talk");
    }

    void Start()
    {
        professor = Fala.transform.GetChild(0).gameObject.GetComponent<Talk>();
        GM.updateScene(scene);
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.1":
                if (professor.estado.terminou)
                {
                    print("terminou");
                    GM.SetGameState("ATO1.2");
                    GM.updateScene(scene);
                }

                break;
        }
    }
}