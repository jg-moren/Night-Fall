using UnityEngine;
using System.Collections;

public class scene_maneger : MonoBehaviour
{

    gamemanager GM;
    public scenes scene;

    void Awake()
    {
        GM = gamemanager.Instance;
    }

    void Start()
    {
        print("aaaa");
        GM.SetGameState(GameState.ATO1);
        GM.updateScene(scene);
    }

  


}

