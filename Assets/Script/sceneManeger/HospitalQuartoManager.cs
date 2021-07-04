using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalQuartoManager : MonoBehaviour
{
    gamemanager GM;
    public scenes scene;

    void Awake()
    {
        GM = gamemanager.Instance;
    }

    void Start()
    {
        GM.updateScene(scene);
    }
    private void Update()
    {

    }
}