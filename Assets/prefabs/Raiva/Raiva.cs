using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raiva : MonoBehaviour
{
    float tempo = 0;
    public GameObject ball;
    void Start()
    {
        
    }
    void Update()
    {
        tempo += Time.deltaTime;
        if(((int)tempo)%2 == 0)
        {
            GameObject.Instantiate(ball,transform);
        }
    }
}
