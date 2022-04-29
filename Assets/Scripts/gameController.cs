using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        Time.timeScale = 0;
    }

    public void BotaoIniciar()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BotaoSair()
    {
        Application.Quit();
    }
}
