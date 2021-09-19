using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition_map : MonoBehaviour
{
    personagem player;
    int position = 0;

    public places[] lugares;
    // tipo de classe para variavel de lugares em que personagem irá
    [System.Serializable]
    public class places
    {
        public Vector2 coo;
        public string nextScene;
        public Vector2 initialPosition;

    }
    void Start()
    {
        player = transform.GetChild(0).GetComponent<personagem>();
        position = (int)PlayerPrefs.GetFloat("Save:position.x");

        player.transform.position = lugares[position].coo;
    }

    // define o personagem para ir para a posicao selecionada
    void setPosition(Vector2 position)
    {
        player.move = moveState.mover;
        player.movePoints[0] = position;
        player.movePoints[1] = new Vector2(position.x, position.y - 0.15f);
        player.ResetValue();
    }

    void Update()
    {
        // varia a 'position' restingido de 0 a 2 ao pressionar alguma tecla. varia com o movimento horizontal
        if (Input.GetAxisRaw("Horizontal")!=0 && Input.anyKeyDown)
        {
            position += (int)Input.GetAxisRaw("Horizontal");
            if (!(position < 0 || 2 < position))
            {
                print(position);
                setPosition(lugares[position].coo);
            }
            if (position < 0) position = 0;
            if (2 < position) position = 2;
        }


        // ao selecionar alguma opcao ele carrega a cena e a localizacao
        if (Input.GetAxisRaw("Submit") == 1 && Input.anyKeyDown)
        {
            PlayerPrefs.SetString("Save:cena", lugares[position].nextScene);
            PlayerPrefs.SetFloat("Save:position.x", lugares[position].initialPosition.x);
            PlayerPrefs.SetFloat("Save:position.y", lugares[position].initialPosition.y);
            SceneManager.LoadScene(sceneName: lugares[position].nextScene);
        }
    }
}
