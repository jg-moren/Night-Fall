using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { ATO1, ATO2,ATO3,ATO4}//definir todos os estados do jogo

public class gamemanager 
{
    
    public GameState gameState;// variavel de estados do jogo

    public void SetGameState(GameState state)
    {
        this.gameState = state;//define em qual dos estados estara
    }
    public void updateScene(scenes scene)//aualizara a cena. scene_maneger.Start
    {
        //define os gameobjects como o gameobject com a tag da cena atual
        GameObject talk = GameObject.FindGameObjectWithTag("Talk");
        GameObject transition = GameObject.FindGameObjectWithTag("Transition");

        Debug.Log("aaaa");

        foreach (var cenaAtual in scene.atos[(int)gameState].cenas)
        {
            Debug.Log(cenaAtual.name);

            if (cenaAtual.scene.name == SceneManager.GetActiveScene().name)
            {
                Debug.Log("aa-----"+cenaAtual.scene.name);
                
                for (int x = 0; x < cenaAtual.talk.Length; x++)
                {
                    talk.transform.GetChild(x).GetComponent<Talk>().dialogues = cenaAtual.talk[x].dialogo;
                }
                //define o loked do gameobject = isLocked das cenas
                //transition.transform.GetChild(0).GetComponent<transition>().locked = scene.atos[(int)gameState].cenas[0].transition[0].isLoked;

            }
        }
    }
   
    //sla oq isso faz ;-;
    private static gamemanager instance;

  
    public static gamemanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new gamemanager();
            }

            return instance;
        }
    }





}
