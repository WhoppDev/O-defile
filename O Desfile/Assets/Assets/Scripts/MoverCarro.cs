using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCarro : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 startPosition;
    private float distanceTraveled = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector3.right * moveDistance);

        distanceTraveled = Vector3.Distance(startPosition, transform.position);

        Debug.Log("Distância percorrida: " + distanceTraveled.ToString("F2") + " metros");
    }
}
