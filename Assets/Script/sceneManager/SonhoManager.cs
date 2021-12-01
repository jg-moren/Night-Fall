using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonhoManager : scene_manager
{

    Raiva raiva;
    player player;
    GameObject talk;
    GameObject transition;

    public AudioClip battle_song;

    public AudioClip sonho_song;
    public AudioClip default_song;
    musica_fundo som;

    bool batalha_iniciada = false;
    bool batalha_terminou = false;

    void Start()
    {
        som = FindObjectOfType<musica_fundo>();
        raiva = FindObjectOfType<Raiva>();
        player = FindObjectOfType<player>();
        talk = GameObject.FindGameObjectWithTag("Talk");
        transition = GameObject.FindGameObjectWithTag("Transition");
        switch (GM.GetGameState())
        {
            case "ATO1.4":
                som.changeAudio(sonho_song);
                player.speed = 5;
                raiva.transform.position = new Vector3(0, 9, 0);
                raiva.moveTo(new Vector3(0, 9, 0), 1);
                break;
            case "ATO1.7":
                som.changeAudio(sonho_song);
                player.speed = 5;
                raiva.transform.position = new Vector3(0, 6, 0);
                raiva.moveTo(new Vector3(0, 6, 0), 1);
                break;
            case "ATO1.9":
                som.changeAudio(sonho_song);
                player.speed = 5;
                raiva.transform.position = new Vector3(0, 6, 0);
                raiva.moveTo(new Vector3(0, 6, 0), 1);
                break;
            case "ATO1.9.1":
                som.changeAudio(sonho_song);
                raiva.transform.position = new Vector3(0, 6, 0);
                raiva.moveTo(new Vector3(0, 6, 0), 1);
                break;
        }
    }

    private void Update()
    {
        if (player.perdeu && !batalha_terminou)
        {
            transition.transform.GetChild(0).GetComponent<transition>().ativar("Sonho", new Vector3(0, 0));
        }
        switch (GM.GetGameState())
        {
            case "ATO1.4":
                if (talk.transform.GetChild(0).GetComponent<Talk>().estado.terminou) talk.transform.GetChild(0).gameObject.SetActive(false);

                if (talk.transform.GetChild(1).GetComponent<Talk>().estado.terminou) {
                    Camera.main.gameObject.transform.position = Vector3.back;
                    talk.transform.GetChild(1).gameObject.SetActive(false);
                    if (!batalha_iniciada) {
                        som.changeAudio(battle_song);
                        StartCoroutine(batalha1());
                        batalha_iniciada = true;
                    }
                    if (batalha_iniciada && batalha_terminou){
                        som.changeAudio(default_song);
                        GM.SetGameState("ATO1.5");
                        transition.transform.GetChild(0).GetComponent<transition>().ativar("DaviHome_DaviBedroom", new Vector3(4.5f, 0));
                    }
                }else{
                    Camera.main.gameObject.transform.position = new Vector3(0, player.transform.position.y, -1);
                }
                break;
            case "ATO1.7":
                if (talk.transform.GetChild(0).GetComponent<Talk>().estado.terminou){
                    talk.transform.GetChild(0).gameObject.SetActive(false);
                    if (raiva.transform.localScale.x < 2) raiva.transform.localScale += raiva.transform.localScale*0.1f*Time.deltaTime;
                    if (!batalha_iniciada)
                    {
                        som.changeAudio(battle_song);
                        StartCoroutine(batalha2());
                        batalha_iniciada = true;
                    }
                    if (batalha_iniciada && batalha_terminou)
                    {
                        som.changeAudio(default_song);
                        GM.SetGameState("ATO1.8");
                        transition.transform.GetChild(0).GetComponent<transition>().ativar("Escola_Hall", new Vector3(19, 1));
                    }
                }
                break;
            case "ATO1.9":
                if (talk.transform.GetChild(0).GetComponent<Talk>().estado.terminou)
                {
                    talk.transform.GetChild(0).gameObject.SetActive(false);
                    if (!batalha_iniciada)
                    {
                        som.changeAudio(battle_song);
                        StartCoroutine(batalha3());
                        batalha_iniciada = true;
                    }
                    if (batalha_iniciada && batalha_terminou)
                    {
                        som.changeAudio(default_song);
                        GM.SetGameState("ATO1.9.1");
                        talk.transform.GetChild(0).GetComponent<Talk>().estado.terminou = false;
                        transition.transform.GetChild(0).GetComponent<transition>().ativar("Sonho", new Vector3(0, 0));

                    }
                }

                break;
            case "ATO1.9.1":
                if (talk.transform.GetChild(0).GetComponent<Talk>().estado.terminou)
                {
                    transition.transform.GetChild(0).GetComponent<transition>().ativar("DaviHome_DaviBedroom", new Vector3(4.5f, 0));

                }
                break;

        }

    }

    IEnumerator ataque_direcionado(int repetir,float wait, float force)
    {
        for (int x = 0; x < repetir; x++)
        {
            raiva.setSprAtacar(true);
            raiva.atacar(player.transform.position, force, 1,true);
            yield return new WaitForSeconds(wait/2);
            raiva.setSprAtacar(false);
            yield return new WaitForSeconds(wait);
        }
    }
    IEnumerator ataque_circulo(int quantos, float wait, float force)
    {
        raiva.setSprAtacar(true);
        for (int x2 = 0; x2 < quantos; x2++)
        {
            Vector2 posicao = raiva.transform.position;

            Vector2 direcao;
            float Px = Mathf.Sin(Mathf.PI *2 * x2 / quantos); //player.transform.position.x;
            float Py = Mathf.Cos(Mathf.PI * 2 * x2 / quantos);
            direcao = new Vector2(Px, Py);
            raiva.atacar(posicao + direcao, force, 0.5f,false);
        }

        yield return new WaitForSeconds(wait);
        raiva.setSprAtacar(false);
    }

    IEnumerator batalha1()  
    {
        raiva.rugir();
        yield return new WaitForSeconds(2f);
        raiva.moveTo(new Vector3(0, 2, 0), 2);
        raiva.setSprAtacar(true);
        yield return new WaitForSeconds(1f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
        raiva.moveTo(new Vector3(9, 2, 0), 2);
        yield return StartCoroutine(ataque_direcionado(10,0.2f,2));
        yield return new WaitForSeconds(2f);
        for (int x = 0; x < 10; x++)
        {
            yield return StartCoroutine(ataque_circulo(15+x, 0.5f, 10));
            yield return StartCoroutine(ataque_direcionado(1,0.2f,1));
        }
        yield return new WaitForSeconds(2f);
        raiva.rugir();
        yield return new WaitForSeconds(0.5f);
        batalha_terminou = true;
        raiva.moveTo(player.transform.position, 5);
        raiva.setSprAtacar(true);
        yield return new WaitForSeconds(1f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator batalha2()
    {

        yield return new WaitForSeconds(2f);
        raiva.moveTo(new Vector3(0, 5, 0), 2);
        raiva.setSprAtacar(true);
        raiva.rugir();
        yield return new WaitForSeconds(2f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
        for (int x = 0; x < 2; x++)
        {
            for (int x2 = 0; x2 < 10; x2++)
            {
                yield return StartCoroutine(ataque_circulo(5 + x2, 0.2f, 10));
            }
            yield return new WaitForSeconds(1f);
        }

        raiva.rugir();
        yield return new WaitForSeconds(0.5f);
        batalha_terminou = true;
        raiva.moveTo(player.transform.position, 5);
        raiva.setSprAtacar(true);
        yield return new WaitForSeconds(1f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator batalha3()
    {
        yield return new WaitForSeconds(2f);
        raiva.moveTo(new Vector3(0, 5, 0),2);
        raiva.setSprAtacar(true);
        raiva.rugir();
        yield return new WaitForSeconds(2f);

        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
        for (int x = 0; x < 10; x++)
        {
            raiva.setSprAtacar(true);
            raiva.atacar(player.transform.position, 1, 0,true);
            yield return new WaitForSeconds(0.5f);
            raiva.setSprAtacar(false);
            yield return new WaitForSeconds(1f);
        }
        batalha_terminou = true;
        raiva.moveTo(player.transform.position, 5);
        raiva.setSprAtacar(true);
        yield return new WaitForSeconds(1f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
    }

}


