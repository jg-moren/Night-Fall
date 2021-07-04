using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Options : MonoBehaviour
{
    GameObject option;
    bool isOpen = false;
    player player;
    Button musica;
    Button menu;
    Button voltar;



    // Start is called before the first frame update
    void Awake()
    {
        option = gameObject.transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        //option.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(42));
        //option.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(42));
        //option.gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(42));
    }

    public void Menu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
    public void Musica()
    {
        Debug.Log("musica");
    }
    public void Voltar()
    {
        isOpen = false;
        openOptions();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = isOpen ? false : true;
            openOptions();
        }
    }


    void openOptions()
    {
        player.isStop = isOpen;
        option.SetActive(isOpen);
    }
}
