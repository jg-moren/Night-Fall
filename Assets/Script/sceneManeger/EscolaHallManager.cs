using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolaHallManager : MonoBehaviour
{
    gamemanager GM;
    public scenes scene;

    GameObject Fala;
    Talk amigos;
    void Awake()
    {
        GM = gamemanager.Instance;
        Fala = GameObject.FindGameObjectWithTag("Talk");
    }

    void Start()
    {
        amigos = Fala.transform.GetChild(0).gameObject.GetComponent<Talk>();
        GM.updateScene(scene);
    }
    private void Update()
    {
        switch (GM.GetGameState())
        {
            case "ATO1.1":
                if (amigos.estado.idPergunta == 1)
                {
                    print("aaaaaaaaaa");
                }

                break;
        }
    }
}