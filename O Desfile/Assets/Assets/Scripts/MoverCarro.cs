using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCarro : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 startPosition;
    public float distanceTraveled = 0f;
    [SerializeField] private float momentoGanharDinheiro = 10f;
    [SerializeField] CarroAlegorico carroAlegorico;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!CORE.instance.gameManager.gameStart) return;
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector3.right * moveDistance);

        distanceTraveled = Vector3.Distance(startPosition, transform.position);

        //Debug.Log("Dist�ncia percorrida: " + distanceTraveled.ToString("F2") + " metros");

        if(distanceTraveled >= momentoGanharDinheiro) {

            gameManager.dinheiroJogador += carroAlegorico.dinheiroGanho;
            Debug.Log("Ganha " + carroAlegorico.dinheiroGanho + " dinheiros");
            momentoGanharDinheiro += 10f;

        }
    }
}
