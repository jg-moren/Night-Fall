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
    bool musica;
    Image spr_musica;
    public Sprite musica_on;
    public Sprite musica_off;


    void Awake()
    {
        option = gameObject.transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        musica = false;
        spr_musica = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
    }

    public void Menu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
    public void Musica()
    {
        musica = musica ? false : true;
        if (musica)
        {
            spr_musica.sprite = musica_on;
        }
        else
        {
            spr_musica.sprite = musica_off;
        }
    }
    public void Controles()
    {
        Debug.Log("Controles");
    }
    public void Voltar()
    {
        isOpen = false;
        openOptions();
    }

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
