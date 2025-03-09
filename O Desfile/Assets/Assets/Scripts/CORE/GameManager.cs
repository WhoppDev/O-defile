using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float dinheiroJogador;
    public TMP_Text dinheiroPlayerHud;

    public bool gameStart = false;

    void Awake()
    {
        gameStart = false;
    }

    private void Start()
    {
        dinheiroPlayerHud.text = dinheiroJogador.ToString();
    }

    public void GanharDinheiro(float dinheiroGanho)
    {
        dinheiroJogador += dinheiroGanho;
        dinheiroPlayerHud.text = dinheiroJogador.ToString();
    }

    public void GastarDinheiro(float dinheiroGanho)
    {
        dinheiroJogador -= dinheiroGanho;
        dinheiroPlayerHud.text = dinheiroJogador.ToString();
    }

    public void GameStatus()
    {
        gameStart = !gameStart;
    }
}
