using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class transition : MonoBehaviour
{
    public bool locked;
    public string nextScene;
    public Vector2 initialPosition;
    public VectorValue playerState;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !locked)//se colidie com o player e nao estiver trancada
        {
            print("go to scene" + nextScene);
            playerState.initialValue = initialPosition;//salva a posicao que sera carregada
            playerState.scene = nextScene; // salva a cena que sera carregada
            SceneManager.LoadScene(sceneName: nextScene);//carrega a proxima cena

        }
    }




}
