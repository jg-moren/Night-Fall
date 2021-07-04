using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_New : MonoBehaviour
{

    gamemanager GM;

    void Awake()
    {
        GM = gamemanager.Instance;
    }


    private void OnMouseDown()
    {

        PlayerPrefs.DeleteAll();
        GM.SetGameState("ATO1.1");
        SceneManager.LoadScene(sceneName: "monologo");
        
    }

}
