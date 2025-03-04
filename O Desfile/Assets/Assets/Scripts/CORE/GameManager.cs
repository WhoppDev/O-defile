using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float dinheiroJogador;
    public TMP_Text dinheiroPlayerHud;


    public void GanharDinheiro(float dinheiroGanho)
    {
        dinheiroJogador += dinheiroGanho;
        dinheiroPlayerHud.text = dinheiroJogador.ToString();
    }
}
