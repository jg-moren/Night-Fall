using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class transition_place : MonoBehaviour
{
    public bool locked;
    public places place1;
    public places place2;
    public player player;
    [System.Serializable]
    public class places
    {
        public string texto;
        public string nextScene;
        public Vector2 initialPosition;

    }


    GameObject canvas;
    Text[] options = new Text[3];
    int selected = 2;


    void Start()
    {
        canvas = gameObject.transform.GetChild(0).gameObject;
        options[0] = canvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        options[1] = canvas.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>();
        options[2] = canvas.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Text>();
        canvas.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && !locked)
        {
            player.isStop = true;
            canvas.SetActive(true);
            options[0].text = place1.texto;
            options[1].text = place2.texto;
            options[2].text = "voltar";


            /*
            playerState.initialValue = place1.initialPosition;
            SceneManager.LoadScene(sceneName: place1.nextScene);
            */
        }
    }

    void Update()
    {
        options[0].color = Color.white;
        options[1].color = Color.white;
        options[2].color = Color.white;

        options[selected].color = Color.red;
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selected < options.Length-1)
            {
                selected += 1;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (0 < selected)
            {
                selected -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && canvas.activeSelf)
        {
            player.isStop = false;
            canvas.SetActive(false);
            switch (selected+1)
            {
                case 1:
                    PlayerPrefs.SetString("Save:cena", place1.nextScene);
                    PlayerPrefs.SetFloat("Save:position.x", place1.initialPosition.x);
                    PlayerPrefs.SetFloat("Save:position.y", place1.initialPosition.y);
                    SceneManager.LoadScene(sceneName: place1.nextScene);
                    break;
                case 2:
                    PlayerPrefs.SetString("Save:cena", place2.nextScene);
                    PlayerPrefs.SetFloat("Save:position.x", place2.initialPosition.x);
                    PlayerPrefs.SetFloat("Save:position.y", place2.initialPosition.y);
                    SceneManager.LoadScene(sceneName: place2.nextScene);
                    break;
                case 3:

                    break;

            }

        }
    }
}
