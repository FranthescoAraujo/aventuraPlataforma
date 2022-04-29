using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cachorroAtaque : MonoBehaviour
{
    public Animator animador;
    public int dano = 10;
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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.1f))
            {
                podeAtacar = false;
                animador.SetTrigger("isAtacando");
                if (hit.collider.gameObject.tag == "Inimigo") hit.collider.gameObject.GetComponent<inimigo>().SofrerDano(dano);
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
