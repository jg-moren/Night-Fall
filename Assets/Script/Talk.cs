using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Talk : MonoBehaviour
{

    public Dialogues dialogues;



    [System.Serializable]
    public class respostas
    {
        public int idPergunta;
        public int idResposta;
        public string Pergunta;
        public string Resposta;
        public bool terminou = false;
    };
    public respostas estado;

    public bool opicional = false;
    GameObject alert;



    Image sprite;
    Text text;//objeto de texto onde sera mostrado as frases;
    GameObject canvas;//variavel da UI na tela
    player player;//importa a classe player para ter acesso as variaveis publicas
    int idfrase = -1;//controla em qual frase o player esta

    int idAnswer;
    GameObject answer;
    Text answer0;
    Text answer1;
    Text answer2;
    Text answer3;


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        alert = gameObject.transform.GetChild(1).gameObject;
        canvas = gameObject.transform.GetChild(0).gameObject;//define a caixa de fala que é children dessa classe
        text = canvas.gameObject.transform.GetChild(1).GetComponent<Text>();//define o texto que é children da caixa de texto
        sprite = canvas.gameObject.transform.GetChild(2).GetComponent<Image>();//define o texto que é children da caixa de texto

        answer = canvas.gameObject.transform.GetChild(3).gameObject;
        answer0 = answer.gameObject.transform.GetChild(1).GetComponent<Text>();
        answer1 = answer.gameObject.transform.GetChild(2).GetComponent<Text>();
        answer2 = answer.gameObject.transform.GetChild(3).GetComponent<Text>();
        answer3 = answer.gameObject.transform.GetChild(4).GetComponent<Text>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && opicional) //ao colidir com um gameobject com a tag "Player" starta a fala
        {
            alert.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!opicional)
        {
            if (collision.tag == "Player") //ao colidir com um gameobject com a tag "Player" starta a fala
            {
                StartDialog();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        alert.SetActive(false);
    }
    void setAnswer()
    {
        answer0.color = Color.white;
        answer1.color = Color.white;
        answer2.color = Color.white;
        answer3.color = Color.white;
        switch (idAnswer)
        {
            case -1: 
                answer0.color = Color.red;
                break;
            case -2:
                answer1.color = Color.red;
                break;
            case -3:
                answer2.color = Color.red;
                break;
            case -4:
                answer3.color = Color.red;
                break;
        }
    }

    //ao clicar na letra e chama a funcao para escrever a proxima sentenca
    private void Update()
    {


        //se o id da frase estiver entre o tamanho da quantidade de frases
        if (0 <= idfrase && idfrase < dialogues.sentence.Length)
        {
            if (dialogues.sentence[idfrase].hasAnswer)
            {
                answer.SetActive(dialogues.sentence[idfrase].hasAnswer);
                if (Input.GetKeyDown(KeyCode.W) && idAnswer < -1)idAnswer += 1;
                if (Input.GetKeyDown(KeyCode.S) && idAnswer > -(dialogues.sentence[idfrase].answers.Length))idAnswer -= 1;
                setAnswer();
            }
            else
            {
                answer.SetActive(dialogues.sentence[idfrase].hasAnswer);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopAllCoroutines();
                nextSentence();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && alert.activeInHierarchy && !canvas.activeInHierarchy)
            {
                StartDialog();
            }
        }





    }


    void StartDialog()
    {
        idfrase = 0;//zera a contagem de qual frase o pleyer esta lendo
        player.isStop = true;//faz o player parar
        canvas.SetActive(true);//ativa na tela a caixa de dialogo    
        setDialog();//chama a funcao para escrever a frase
    }

    void setDialog()
    {
        //torna o campo limpo para escrever 
        text.text = "";
        answer0.text = "";
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        idAnswer = -1;
        //se o id da frase estiver entre o tamanho da quantidade de frases
        if (0 <= idfrase && idfrase < dialogues.sentence.Length)
        {
            sprite.sprite = dialogues.sentence[idfrase].sprite;//define a imagem

            StopAllCoroutines();//para de escrever as frases
            if (dialogues.sentence[idfrase].hasAnswer)//se tiver resposta
            {
                int size = dialogues.sentence[idfrase].answers.Length;
                //escreve as respostas
                if (size > 0) StartCoroutine(write(dialogues.sentence[idfrase].answers[0].frase, answer0));
                if (size > 1) StartCoroutine(write(dialogues.sentence[idfrase].answers[1].frase, answer1));
                if (size > 2) StartCoroutine(write(dialogues.sentence[idfrase].answers[2].frase, answer2));
                if (size > 3) StartCoroutine(write(dialogues.sentence[idfrase].answers[3].frase, answer3));
            }
            //escreve as perguntas
            StartCoroutine(write(dialogues.sentence[idfrase].frase,text));
        }
        else//se for maior nao tera mais frase para escrever e pode terminar a fala
        {
            player.isStop = false;//faz o player voltar a andar
            canvas.SetActive(false);//desativa na tela a caixa de dialogo
            estado.terminou = true;
        }
    }


    IEnumerator write(string frase, Text texto)//corrotina para escrever as letras uma por uma
    {
        foreach (char letter in frase)//letter passara por todas as letras da frase atual
        {
            yield return new WaitForSeconds(0.01f);//espera
            texto.text += letter;//escreve a letra
        }
    }
    public void nextSentence()
    {
        if (dialogues.sentence[idfrase].hasAnswer)
        {
            estado.idPergunta = idfrase;
            estado.Pergunta = dialogues.sentence[idfrase].frase;
            estado.idResposta = idAnswer;
            estado.Resposta = dialogues.sentence[idfrase].answers[Mathf.Abs(idAnswer) - 1].frase;
            idfrase = dialogues.sentence[idfrase].answers[Mathf.Abs(idAnswer)-1].nextSentence;
            idAnswer = -1;

        }
        else
        {
            estado.idPergunta = idfrase;
            estado.Pergunta = dialogues.sentence[idfrase].frase;
            estado.idResposta = 0;
            estado.Resposta = "";
            idfrase = dialogues.sentence[idfrase].nextSentence;
            idAnswer = -1;
        }
        //        idfrase += 1;//ira para a proxima frase
        setDialog();
    }
}
