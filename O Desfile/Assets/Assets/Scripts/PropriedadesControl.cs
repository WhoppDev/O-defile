using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropriedadesControl : MonoBehaviour
{
    public Image popularidadeBar;
    public Image segurancaBar;
    public Image belezaBar;
    public Image velocidadeBar;

    public void AtualizarBarras(CarroAlegorico carro)
    {
        popularidadeBar.fillAmount = Mathf.Clamp01(carro.popularidadeTotal / 100f);
        segurancaBar.fillAmount = Mathf.Clamp01(carro.segurancaTotal / 100f);
        belezaBar.fillAmount = Mathf.Clamp01(carro.belezaTotal / 100f);
        velocidadeBar.fillAmount = Mathf.Clamp01(carro.velocidadeTotal / 100f);
    }
}
