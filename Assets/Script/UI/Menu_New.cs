using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_New : MonoBehaviour
{

    gamemanager GM;

    void Awake()
    {
        GM = new gamemanager();
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    private void OnMouseDown()
    {
        PlayerPrefs.DeleteAll();
        GM.SetGameState("ATO1.1");
        SceneManager.LoadScene(sceneName: "monologo");



    }

}
