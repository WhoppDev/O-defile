using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public int popularity = 5;
    public float spawnInterval = 5.0f;
    public GameObject[] npcPrefab;
    public Transform carTransform;
    public float npcSpawnDistance = 10.0f;

    private List<GameObject> spawnedNpcs = new List<GameObject>();
    private float timer = 0.0f;
    private bool isSpawning = true;

    void Update()
    {
        if (!CORE.instance.gameManager.gameStart) return;

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
        if (Camera.main == null) return;

        int npcsToSpawn = Mathf.Clamp(popularity, 1, 10);

        for (int i = 0; i < npcsToSpawn; i++)
        {
            Transform cameraTransform = Camera.main.transform;
            Vector3 spawnPosition = cameraTransform.position - (cameraTransform.forward * npcSpawnDistance);
            spawnPosition += new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
            spawnPosition.y = carTransform.position.y;

            GameObject randomNpcPrefab = npcPrefab[Random.Range(0, npcPrefab.Length)];
            GameObject npc = Instantiate(randomNpcPrefab, spawnPosition, Quaternion.identity);
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
    }
}
