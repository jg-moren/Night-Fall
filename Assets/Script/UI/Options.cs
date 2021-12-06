using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Options : MonoBehaviour
{
    GameObject option;

    GameObject controles;
    bool isOpen = false;
    bool musica;
    Image spr_musica;
    public Sprite musica_on;
    public Sprite musica_off;

    

    void Awake()
    {
        try
        {

            option = gameObject.transform.GetChild(0).gameObject;
            controles = gameObject.transform.GetChild(1).gameObject;
            musica = false;
            spr_musica = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
        }
        catch
        {

        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
    public void Musica()
    {
        if (musica)
        {
            spr_musica.sprite = musica_on;
            AudioListener.volume = 1;
        }
        else
        {
            spr_musica.sprite = musica_off;
            AudioListener.volume = 0;

        }
        musica = musica ? false : true;

    }
    public void Controles()
    {
        controles.SetActive(true);
        option.SetActive(false);
    }
    public void ControlesFechar()
    {
        option.SetActive(true);
        controles.SetActive(false);
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
        Time.timeScale= isOpen ? 0 : 1;
        option.SetActive(isOpen);
    }
}
