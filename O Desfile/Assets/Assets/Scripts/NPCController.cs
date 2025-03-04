using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public int popularity = 5; // 0-10
    public float spawnInterval = 5.0f;
    public GameObject npcPrefab; 
    public Transform carTransform; 
    public float npcSpawnRadius = 10.0f; 

    private List<GameObject> spawnedNpcs = new List<GameObject>(); 
    private float timer = 0.0f;
    private bool isSpawning = true;

    void Update()
    {
        if (isSpawning)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnNPC();
                timer = 0.0f; 
            }
        }
    }

    void SpawnNPC()
    {

        int npcsToSpawn = Mathf.Clamp(popularity, 1, 10); 

        for (int i = 0; i < npcsToSpawn; i++)
        {

            Vector3 spawnPosition = carTransform.position + Random.insideUnitSphere * npcSpawnRadius;
            spawnPosition.y = carTransform.position.y; 

            GameObject npc = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
            spawnedNpcs.Add(npc);
        }
    }

    public void EndJourney()
    {
        isSpawning = false; 


        int totalPopularity = 0;
        int totalMoney = 0;

        foreach (GameObject npc in spawnedNpcs)
        {
            totalPopularity += popularity;
            totalMoney += popularity * 10;
        }
        foreach (GameObject npc in spawnedNpcs)
        {
            Destroy(npc);
        }

        spawnedNpcs.Clear();

        Debug.Log("Jornada finalizada!");
        Debug.Log("Popularidade total: " + totalPopularity);
        Debug.Log("Dinheiro gerado: " + totalMoney);
    }
}
