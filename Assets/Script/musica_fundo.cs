using System.Collections;
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
        if (audioSource.clip != clip) {
            StartCoroutine(som(clip));
        }

    }
    IEnumerator som(AudioClip clip)
    {

        for (float x = 1; x > 0.1; x=x/1.2f)
        {
            audioSource.volume = x;
            yield return new WaitForSeconds(0.1f);
        }
        audioSource.clip = clip;
        audioSource.Play();

        for (float x = 1; x > 0.1; x = x / 1.2f)
        {
            audioSource.volume = 1-x;
            yield return new WaitForSeconds(0.1f);
        }
        audioSource.volume = 1 ;


    }



}