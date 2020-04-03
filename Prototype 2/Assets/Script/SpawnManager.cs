using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] animalPrefabs;
    private float spawnXRange = 20f;
    private float startTime = 2;
    private float spawnInterval = 1.0f;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startTime, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 SpawnPos = new Vector3(Random.Range(-spawnXRange, spawnXRange), 0, 20);
        Instantiate(animalPrefabs[animalIndex], SpawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
