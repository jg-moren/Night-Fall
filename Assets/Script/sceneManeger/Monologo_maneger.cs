using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monologo_maneger : MonoBehaviour
{
    gamemanager GM;
    public scenes scene;

    GameObject Fala;
    Talk monologo;
    void Awake()
    {
        GM = gamemanager.Instance;
        Fala = GameObject.FindGameObjectWithTag("Talk");
    }

    void Start()
    {
        monologo = Fala.transform.GetChild(0).gameObject.GetComponent<Talk>();
        GM.updateScene(scene);
    }
    private void Update()
    {
        if (monologo.estado.terminou)
        {
            PlayerPrefs.SetFloat("Save:position.x",-6);
            PlayerPrefs.SetFloat("Save:position.y",3);
            SceneManager.LoadScene(sceneName: "Escola_Hall");
        }
    }
}