﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica_fundo : MonoBehaviour
{

    AudioSource audioSource;
    musica_fundo[] musica;
    private void Awake()
    {
        musica = FindObjectsOfType<musica_fundo>();
        audioSource = GetComponent<AudioSource>();
        if(musica.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }
    public void pause()
    {
        audioSource.Stop();
    }

    public void play()
    {
        audioSource.Play();
    }
    public void changeAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();

    }



}