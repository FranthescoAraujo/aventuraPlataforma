using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personagemAtaque : MonoBehaviour
{
    public Animator animador;
    public int dano01 = 50;
    public int dano02 = 30;
    public float tempoAtaque = 0;
    public bool podeAtacar = true;

    void Update()
    {
        Atacar();
        TempoAtaque();
    }
    void Atacar()
    {
        if (podeAtacar == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                podeAtacar = false;
                animador.SetTrigger("isAtacando");
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1))
                {
                    if (hit.collider.gameObject.tag == "Inimigo") hit.collider.gameObject.GetComponent<inimigo>().SofrerDano(dano01);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                podeAtacar = false;
                animador.SetTrigger("isChutando");
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1))
                {
                    if (hit.collider.gameObject.tag == "Inimigo") hit.collider.gameObject.GetComponent<inimigo>().SofrerDano(dano02);
                }
                return;
            }
        }
    }

    void TempoAtaque()
    {
        tempoAtaque += Time.deltaTime;
        if (tempoAtaque >= 2f)
        {
            tempoAtaque = 0;
            podeAtacar = true;
        }
    }
}
