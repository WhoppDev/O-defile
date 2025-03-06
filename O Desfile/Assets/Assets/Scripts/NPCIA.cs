using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIA : MonoBehaviour
{
    public Transform carTransform;
    public float followSpeed = 3.0f;
    public float danceDistance = 5.0f;
    public float danceDuration = 2.0f;
    public float retreatDistance = 3.0f;
    public float minDistanceFromCar = 2.0f;
    public float npcSpacing = 2.0f;

    private enum NPCState { Following, Dancing, Retreating }
    private NPCState currentState = NPCState.Following;

    private Vector3 retreatPosition;
    private Animator anim;
    private float danceTimer = 0.0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (carTransform == null)
        {
            carTransform = GameObject.FindGameObjectWithTag("Carro").transform;
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case NPCState.Following:
                FollowCar();
                break;

            case NPCState.Dancing:
                Dance();
                break;

            case NPCState.Retreating:
                Retreat();
                break;
        }

        LookAtCar();
    }

    void FollowCar()
    {
        Vector3 direction = (carTransform.position - transform.position).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, carTransform.position) <= danceDistance)
        {
            retreatPosition = GetRandomPositionAroundCar();
            currentState = NPCState.Dancing;
            danceTimer = 0.0f;
        }
    }

    void Dance()
    {
        anim.SetBool("Dancing", true);

        danceTimer += Time.deltaTime;
        if (danceTimer >= danceDuration)
        {
            anim.SetBool("Dancing", false);
            currentState = NPCState.Retreating;
        }
    }

    void Retreat()
    {
        transform.position = Vector3.MoveTowards(transform.position, retreatPosition, followSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, retreatPosition) < 0.1f)
        {
            currentState = NPCState.Following;
        }
    }

    void LookAtCar()
    {
        Vector3 direction = (carTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    Vector3 GetRandomPositionAroundCar()
    {
        Vector3 randomPosition;
        int attempts = 0;
        bool positionFound = false;

        do
        {
            randomPosition = carTransform.position + Random.insideUnitSphere * danceDistance;
            randomPosition.y = carTransform.position.y;

            if (Vector3.Distance(randomPosition, carTransform.position) < minDistanceFromCar)
            {
                continue;
            }

            Collider[] nearbyColliders = Physics.OverlapSphere(randomPosition, npcSpacing);
            positionFound = true;


            attempts++;
            if (attempts > 100)
            {
                Debug.LogWarning("Não foi possível encontrar uma posição válida para o NPC.");
                return transform.position;
            }

        } while (!positionFound);

        return randomPosition;
    }
}