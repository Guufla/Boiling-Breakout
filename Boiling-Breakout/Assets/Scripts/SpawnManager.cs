using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    private float spawnRangeXLower = 0.5f;
    private float spawnRangeXUpper = 21;
    private float spawnPosY = 30;
    private float spawnRangeZLower = -5.35f;
    private float spawnRangeZUpper = 2;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomFood", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomFood() 
    { 
        int foodIndex = Random.Range(0, foodPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeXLower, spawnRangeXUpper), spawnPosY, Random.Range(spawnRangeZLower, spawnRangeZUpper));
        Instantiate(foodPrefabs[foodIndex], spawnPos, foodPrefabs[foodIndex].transform.rotation);
    }
}
