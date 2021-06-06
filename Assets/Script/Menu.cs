using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public VectorValue PlayerPosition;
    private void OnMouseDown()
    {
        if(PlayerPosition.scene != null && PlayerPosition.scene != "" )
        {
            SceneManager.LoadScene(sceneName: PlayerPosition.scene);
        }
        else
        {
            SceneManager.LoadScene(sceneName: "DaviHome_DaviBedroom");
        }
    }

}
