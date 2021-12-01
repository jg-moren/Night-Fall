using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonologoManager : scene_manager
{
    
    GameObject Fala;
    Talk monologo;


    void Start()
    {
        Fala = GameObject.FindGameObjectWithTag("Talk");

        monologo = Fala.transform.GetChild(0).gameObject.GetComponent<Talk>();
    }
    private void Update()
    {
        if (monologo.estado.terminou)
        {
            PlayerPrefs.SetFloat("Save:position.x",0);
            PlayerPrefs.SetFloat("Save:position.y",10);
            SceneManager.LoadScene(sceneName: "Escola_Rua");
        }
    }
}