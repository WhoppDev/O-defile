using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroAlegorico : MonoBehaviour
{
    private CarroElementosController[] elementos;

    public float popularidadeTotal;
    public float segurancaTotal;
    public float belezaTotal;
    public float velocidadeTotal;

    private void Start()
    {
        elementos = FindObjectsOfType<CarroElementosController>();
        AtualizarElementos();
    }

    public void AtualizarElementos()
    {
        popularidadeTotal = 0;
        segurancaTotal = 0;
        belezaTotal = 0;
        velocidadeTotal = 80;

        foreach (var elemento in elementos)
        {
            if (elemento != null && elemento.carrosData != null)
            {
                elemento.gameObject.SetActive(elemento.carrosData.equipado);

                if (elemento.carrosData.equipado)
                {
                    popularidadeTotal += elemento.carrosData.impactoPopularidade;
                    segurancaTotal += elemento.carrosData.impactoSeguranca;
                    belezaTotal += elemento.carrosData.impactoBeleza;
                    velocidadeTotal += elemento.carrosData.impactoVelocidade;
                }
            }
        }

        // Atualiza a interface
        if (FindObjectOfType<PropriedadesControl>() != null)
        {
            FindObjectOfType<PropriedadesControl>().AtualizarBarras(this);
        }
    }
}
