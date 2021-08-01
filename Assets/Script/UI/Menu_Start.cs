using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Start : MonoBehaviour
{

    gamemanager GM;

    void Awake()
    {
        GM = gamemanager.Instance;
    }


    private void OnMouseDown()
    {
        string cena = PlayerPrefs.GetString("Save:cena");

        if(cena != null && cena != "" )
        {
            SceneManager.LoadScene(sceneName: cena);
        }
        else
        {
            PlayerPrefs.DeleteAll();
            GM.SetGameState("ATO1.1");
            SceneManager.LoadScene(sceneName: "Monologo");
        }
    }

}
