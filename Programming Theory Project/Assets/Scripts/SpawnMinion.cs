using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinion : MonoBehaviour
{
    public GameObject minion;
    public int minionsSpawnCount = 2;
    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        for (int i = 0; i < minionsSpawnCount; i++)
        {
            Instantiate(minion, GenerateSpawnPosition(), minion.transform.rotation);
        }
         
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
