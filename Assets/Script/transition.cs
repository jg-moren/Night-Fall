using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    public bool locked;
    public string nextScene;
    public Vector2 initialPosition;
    Animator anim;
    player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        anim = transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
        anim.SetBool("Start", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !locked)//se colidie com o player e nao estiver trancada
        {
            player.isStop = true;
            StartCoroutine(LoadNextScene());

        }
    }
    IEnumerator LoadNextScene()
    {
        anim.SetBool("Start", true);
        yield return new WaitForSeconds(0.5f);

        //salva a posicao que sera carregada
        // salva a cena que sera carregada
        PlayerPrefs.SetString("Save:cena", nextScene);
        PlayerPrefs.SetFloat("Save:position.x", initialPosition.x);
        PlayerPrefs.SetFloat("Save:position.y", initialPosition.y);


        SceneManager.LoadScene(sceneName: nextScene);//carrega a proxima cena
    }




}
