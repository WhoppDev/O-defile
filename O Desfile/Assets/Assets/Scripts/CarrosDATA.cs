using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CarroData", menuName = "CarroData")]
public class CarrosDATA : ScriptableObject
{
    public string nome;
    public float custo;
    public float impactoPopularidade;
    public float impactoSeguranca;
    public float impactoBeleza;
    public float impactoVelocidade;
    public bool equipado;

    [Header("O que é?")]
    public bool som;
    public bool luz;
    public bool seguranca;
    public bool atracao;
}
