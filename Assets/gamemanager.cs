using UnityEngine;
using UnityEngine.SceneManagement;


public class gamemanager 
{
    public void SetGameState(string state)
    {
        PlayerPrefs.SetString("gameState",state);//define em qual dos estados estara
    }
    public string GetGameState()
    {
        return PlayerPrefs.GetString("gameState");
    }
    public void updateScene(scenes scene)//aualizara a cena. scene_maneger.Start
    {
        //define os gameobjects como o gameobject com a tag da cena atual
        GameObject talk = GameObject.FindGameObjectWithTag("Talk");
        GameObject transition = GameObject.FindGameObjectWithTag("Transition");
        foreach (var atoAtual in scene.atos)
        {

            if (atoAtual.name == GetGameState())
            {
                foreach (var cenaAtual in atoAtual.cenas)
                {

                    if (cenaAtual.scene.name == SceneManager.GetActiveScene().name)
                    {
                        for (int x = 0; x < cenaAtual.talk.Length; x++)
                        {
                            talk.SetActive(cenaAtual.talk[x].ativo);
                            talk.transform.GetChild(x).GetComponent<Talk>().opicional = cenaAtual.talk[x].opicional;
                            talk.transform.GetChild(x).GetComponent<Talk>().dialogues = cenaAtual.talk[x].dialogo;
                        }

                        //define o loked do gameobject = isLocked das cenas
                        for (int x = 0; x < cenaAtual.transition.Length; x++)
                        {
                            transition.transform.GetChild(x).GetComponent<transition>().locked = cenaAtual.transition[x].isLoked;
                        }
                    }
                }
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
