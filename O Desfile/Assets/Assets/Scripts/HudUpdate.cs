using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudUpdate : MonoBehaviour
{
    public CarroAlegorico carro;

    public Transform areaSom, areaIluminacao, areaSeguranca, areaAtracoes;
    public GameObject painelSom, painelIluminacao, painelSegurança, painelAtracoes;
    public GameObject botaoPrefab;

    private void OnEnable()
    {
        carro = GameObject.FindAnyObjectByType<CarroAlegorico>();

        if (carro == null)
        {
            Debug.LogWarning("Nenhum CarroAlegorico encontrado!");
            return;
        }

        AtualizarHUD();
    }

    void AtualizarHUD()
    {
        AtualizarPainel(areaSom, "som", painelSom);
        AtualizarPainel(areaIluminacao, "luz", painelIluminacao);
        AtualizarPainel(areaSeguranca, "seguranca", painelSegurança);
        AtualizarPainel(areaAtracoes, "atracao", painelAtracoes);
    }

    void AtualizarPainel(Transform area, string tipo, GameObject painel)
    {
        foreach (Transform child in area)
        {
            Destroy(child.gameObject);
        }

        CarroElementosController[] elementos = FindObjectsOfType<CarroElementosController>();

        bool temElemento = false;
        foreach (var elemento in elementos)
        {
            if ((tipo == "som" && elemento.carrosData.som) ||
                (tipo == "luz" && elemento.carrosData.luz) ||
                (tipo == "seguranca" && elemento.carrosData.seguranca) ||
                (tipo == "atracao" && elemento.carrosData.atracao))
            {
                GameObject botao = Instantiate(botaoPrefab, area);
                TMP_Text textoBotao = botao.GetComponentInChildren<TMP_Text>();

                AtualizarTextoBotao(elemento, textoBotao);

                Button btn = botao.GetComponent<Button>();
                btn.onClick.AddListener(() => ComprarOuEquiparItem(elemento, textoBotao));

                temElemento = true;
            }
        }

        painel.SetActive(temElemento); 
    }


    void AtualizarTextoBotao(CarroElementosController elemento, TMP_Text texto)
    {
        texto.text = elemento.carrosData.equipado
            ? $"{elemento.carrosData.nome} (Equipado)"
            : $"{elemento.carrosData.nome} - R$ {elemento.carrosData.custo}";
    }

    void ComprarOuEquiparItem(CarroElementosController elemento, TMP_Text textoBotao)
    {
        CarrosDATA dados = elemento.carrosData;

        if (!dados.equipado)
        {
            if (CORE.instance.gameManager.dinheiroJogador >= dados.custo)
            {
                CORE.instance.gameManager.GastarDinheiro(dados.custo);
                dados.equipado = true;
                Debug.Log($"{dados.nome} comprado!");
            }
            else
            {
                Debug.Log("Dinheiro insuficiente!");
                return;
            }
        }
        else
        {
            dados.equipado = !dados.equipado;
            Debug.Log($"{dados.nome} {(dados.equipado ? "equipado" : "desequipado")}");
        }

        AtualizarTextoBotao(elemento, textoBotao);
        carro.AtualizarElementos(); // Atualiza atributos e interface
    }

}

