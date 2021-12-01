using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica_de_fundo : MonoBehaviour
{
    public AudioClip musica_fundo;

    musica_fundo som;

    void Start()
    {
        som = FindObjectOfType<musica_fundo>();
        som.changeAudio(musica_fundo);

    }
}