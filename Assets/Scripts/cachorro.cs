using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cachorro : MonoBehaviour
{
    public Transform personagem;
    public GameObject[] inimigos;
    public Transform inimigo;
    public Animator animador;

    void Start()
    {
        personagem = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
    }

    void Update()
    {
        verificaSePosicaoInimigoNula();
        procuraInimigoMaisProximo();
        Andar();
    }

    public void verificaSePosicaoInimigoNula()
    {
        if (inimigo == null)
        {
            for (int i = 0; i < inimigos.Length; i++)
            {
                if (inimigos[i] != null)
                {
                    inimigo = inimigos[i].GetComponent<Transform>();
                    break;
                }
                else
                {
                    inimigo = GameObject.FindGameObjectWithTag("Point").transform;
                }
            }
        }
    }

    public void procuraInimigoMaisProximo()
    {
        if (!(inimigo == null))
        {
            for (int i = 0; i < inimigos.Length; i++)
            {
                if (inimigos[i] != null)
                {
                    if (Vector3.Distance(transform.position, inimigos[i].GetComponent<Transform>().position) < Vector3.Distance(transform.position, inimigo.position))
                    {
                        inimigo = inimigos[i].GetComponent<Transform>();
                    }
                }
            }
        } 
    }

    public void Andar()
    {
        if ((Vector3.Distance(personagem.position, inimigo.position) > 6f) && (Vector3.Distance(transform.position, personagem.position) > 1f))
        {
            animador.SetBool("isAndando", true);
            transform.LookAt(personagem);
            transform.position = Vector3.MoveTowards(transform.position, personagem.position, 0.06f);
            return;
        }
        else
        {
            if (Vector3.Distance(transform.position, inimigo.position) > 3f)
            {
                if (Vector3.Distance(transform.position, personagem.position) > 1f)
                {
                    animador.SetBool("isAndando", true);
                    transform.LookAt(personagem);
                    transform.position = Vector3.MoveTowards(transform.position, personagem.position, 0.04f);
                    return;
                }
                animador.SetBool("isAndando", false);
                animador.SetBool("isCorrendo", false);
                return;
            }
            else if (Vector3.Distance(transform.position, inimigo.position) > 1f)
            {

                animador.SetBool("isCorrendo", true);
                transform.LookAt(inimigo);
                transform.position = Vector3.MoveTowards(transform.position, inimigo.position, 0.2f);
                return;
            }
        }
    }
}
