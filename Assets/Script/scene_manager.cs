using UnityEngine;
using System.Collections;
public class scene_manager : MonoBehaviour
{

    public gamemanager GM;
    public game game;



    void Awake()
    {
        GM = new gamemanager();
        GM.updateScene(game);

    }




  


}

