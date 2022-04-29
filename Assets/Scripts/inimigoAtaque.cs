using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoAtaque : MonoBehaviour
{
    public Animator animador;
    public int dano = 30;
    public float tempoAtaque = 0;
    public bool podeAtacar = true;
    public personagem personagem;
    private void Start()
    {
        personagem = GameObject.FindGameObjectWithTag("Player").GetComponent<personagem>();
    }
    void Update()
    {
        Atacar();
        TempoAtaque();
    }
    void Atacar()
    {
        if (podeAtacar == true && personagem.hpAtual > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.6f))
            {
                podeAtacar = false;
                animador.SetTrigger("isAtacando");
                if (hit.collider.gameObject.tag == "Player") hit.collider.gameObject.GetComponent<personagem>().SofrerDano(dano);
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
