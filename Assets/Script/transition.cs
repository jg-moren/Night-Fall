using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class transition : MonoBehaviour
{
    public bool locked;
    public string nextScene;
    public Vector2 initialPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !locked)//se colidie com o player e nao estiver trancada
        {
            print("go to scene" + nextScene);
            //salva a posicao que sera carregada
            // salva a cena que sera carregada
            PlayerPrefs.SetString("Save:cena", nextScene);
            PlayerPrefs.SetFloat("Save:position.x", initialPosition.x);
            PlayerPrefs.SetFloat("Save:position.y", initialPosition.y);


            SceneManager.LoadScene(sceneName: nextScene);//carrega a proxima cena

        }
    }




}
