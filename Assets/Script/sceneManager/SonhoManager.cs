using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonhoManager : scene_manager
{

    Raiva raiva;
    player player;
    GameObject talk;
    GameObject transition;

    bool batalha_iniciada = false;
    bool batalha_terminou = false;

    void Start()
    {

        raiva = FindObjectOfType<Raiva>();
        player = FindObjectOfType<player>();
        talk = GameObject.FindGameObjectWithTag("Talk");
        transition = GameObject.FindGameObjectWithTag("Transition");
        switch (GM.GetGameState())
        {
            case "ATO1.4":
                raiva.transform.position = new Vector3(0, 9, 0);
                raiva.moveTo(new Vector3(0, 9, 0), 1);
                break;
            case "ATO1.7":
                raiva.transform.position = new Vector3(0, 6, 0);
                raiva.moveTo(new Vector3(0, 6, 0), 1);
                break;
            case "ATO1.9":
                player.speed = 5;
                raiva.transform.position = new Vector3(0, 6, 0);
                raiva.moveTo(new Vector3(0, 6, 0), 1);
                break;
            case "ATO1.9.1":
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
                        StartCoroutine(batalha1());
                        batalha_iniciada = true;
                    }
                    if (batalha_iniciada && batalha_terminou){
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
                        StartCoroutine(batalha2());
                        batalha_iniciada = true;
                    }
                    if (batalha_iniciada && batalha_terminou)
                    {
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
                        StartCoroutine(batalha3());
                        batalha_iniciada = true;
                    }
                    if (batalha_iniciada && batalha_terminou)
                    {
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
    IEnumerator batalha1()  
    {
        print("batalha1");
        yield return new WaitForSeconds(2f);
        raiva.moveTo(new Vector3(0, 2, 0), 2);
        raiva.setSprAtacar(true);
        yield return new WaitForSeconds(1f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
        for(int x = 0; x < 10; x++){
            raiva.setSprAtacar(true);
            raiva.atacar(player.transform.position, 1);
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
    IEnumerator batalha2()
    {
        print("batalha2");
        yield return new WaitForSeconds(2f);
        raiva.moveTo(new Vector3(0, 3, 0), 2);
        raiva.setSprAtacar(true);
        yield return new WaitForSeconds(1f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
        for (int x = 0; x < 2; x++)
        {
            raiva.setSprAtacar(true);
            for (int x2 = 0; x2 < 100; x2++)
            {
                Vector2 posicao = raiva.transform.position;

                Vector2 direcao;
                float Px = Mathf.Sin(x2/2 ); //player.transform.position.x;
                float Py = Mathf.Cos(x2/2 );

                direcao = new Vector2(Px, Py);
                raiva.atacar(posicao + direcao, 10);
                /*
                direcao = new Vector2(Px, -Py);
                raiva.atacar(posicao + direcao, 10);

                direcao = new Vector2(-Px, -Py);
                raiva.atacar(posicao + direcao, 10);

                direcao = new Vector2(-Px, Py);
                raiva.atacar(posicao + direcao, 10);
                */
                yield return new WaitForSeconds(0.01f);


            }

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

    IEnumerator batalha3()
    {
        print("batalha3");
        yield return new WaitForSeconds(2f);
        raiva.moveTo(new Vector3(0, 3, 0), 2);
        raiva.setSprAtacar(true);
        yield return new WaitForSeconds(1f);
        raiva.setSprAtacar(false);
        yield return new WaitForSeconds(1f);
        for (int x = 0; x < 10; x++)
        {
            raiva.setSprAtacar(true);
            raiva.atacar(player.transform.position, 1);
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


