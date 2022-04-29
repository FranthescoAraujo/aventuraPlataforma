using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class personagem : MonoBehaviour
{
    public float velX;
    public float velZ;
    public Rigidbody corpo;
    public Animator animador;
    public float forcaPulo = 1f;
    public float hpAtual = 300f;
    public float hpTotal = 300f;
    public float rotY;
    public float velRotY = 2.5f;
    public GameObject healthBar;
    public float tempoMorto;
    public GameObject vitoria;

    void Start()
    {
        corpo = GetComponent<Rigidbody>();
        animador = GetComponent<Animator>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        vitoria = GameObject.FindGameObjectWithTag("Vitoria");
    }
    void Update()
    {
        Andar();
        Pular();
        Girar();
        Morrer();
        Vitoria();
    }

    void Girar()
    {
        if (Input.GetMouseButton(0) && this.hpAtual > 0)
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                rotY += velRotY;
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                rotY -= velRotY;
            }
        }
        transform.eulerAngles = new Vector3(0, rotY, 0);
    }

    void Andar()
    {
        if (this.hpAtual > 0)
        {
            float velocidadeX = Input.GetAxis("Horizontal") * velX;
            float velocidadeZ = Input.GetAxis("Vertical") * velZ;

            if (velocidadeZ < 0) animador.SetBool("isAndandoBack", true);
            else animador.SetBool("isAndandoBack", false);

            if (velocidadeZ > 0) animador.SetBool("isAndandoFront", true);
            else animador.SetBool("isAndandoFront", false);

            if (velocidadeX < 0) animador.SetBool("isAndandoLeft", true);
            else animador.SetBool("isAndandoLeft", false);

            if (velocidadeX > 0) animador.SetBool("isAndandoRight", true);
            else animador.SetBool("isAndandoRight", false);

            Vector3 velocidadeXZ = (transform.right * velocidadeX) + (transform.forward * velocidadeZ);
            corpo.velocity = new Vector3(velocidadeXZ.x, corpo.velocity.y, velocidadeXZ.z);
        }
    }

    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.hpAtual>0)
        {
            Vector3 Impulso = new Vector3(0f, forcaPulo, 0f);
            corpo.velocity = corpo.velocity + Impulso;
            animador.SetTrigger("isPulando");
        }
    }

    public void SofrerDano(int dano)
    {
        animador.SetTrigger("isSofrendoDano");
        this.hpAtual -= dano;
        healthBar.GetComponent<Image>().fillAmount = this.hpAtual / this.hpTotal;
    }

    public void Morrer()
    {
        if (this.hpAtual <= 0)
        {
            animador.SetTrigger("isMorto");
            if (IsMorto())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public bool IsMorto()
    {
        tempoMorto += Time.deltaTime;
        if (tempoMorto >= 2f)
        {
            tempoMorto = 0;
            return true;
        }
        return false;
    }

    public void Vitoria()
    {
        if ((Vector3.Distance(vitoria.transform.position, transform.position)<1) && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
