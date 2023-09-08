using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject bossPrefab;

    public int enemyCount;
    public int waveNumber = 1;

    private float spawnRange = 9;
    private int bossRound = 3;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerupWave(1);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            if (waveNumber%bossRound == 0)
            {
                SpawnBoss(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
            SpawnPowerupWave(1);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);
        }
    }

    private void SpawnPowerupWave(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            int powerupIndex = Random.Range(0, powerupPrefab.Length);
            Instantiate(powerupPrefab[powerupIndex], GenerateSpawnPosition(), powerupPrefab[powerupIndex].transform.rotation);
        }
    }

    private void SpawnBoss(int enemiesToSpawn)
    {
        Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        SpawnEnemyWave(enemiesToSpawn - 1);
    }
}
