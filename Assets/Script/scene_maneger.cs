using UnityEngine;
using System.Collections;

public class scene_maneger : MonoBehaviour
{

    public gamemanager GM;
    public game game;



    void Awake()
    {
        GM = gamemanager.Instance;
        GM.updateScene(game);

    }




  


}

