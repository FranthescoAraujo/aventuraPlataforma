using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public Transform personagem;
    public Animator animador;
    public int hp = 200;

    void Start()
    {
        personagem = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Andar();
        Morrer();
    }

    void Andar()
    {
        if ((Vector3.Distance(transform.position, personagem.position) < 5f) && (Vector3.Distance(transform.position, personagem.position) > 1.5f))
        {
            animador.SetBool("isAndando", true);
            transform.LookAt(personagem);
            transform.position = Vector3.MoveTowards(transform.position, personagem.position, 0.04f);
            return;
        }
        animador.SetBool("isAndando", false);
    }

    void Morrer()
    { 
        if (this.hp<=0)
        {
            Destroy(this.gameObject);
        }
    }


    public void SofrerDano(int dano)
    {
        this.hp -= dano;
    }
}
