using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] float spawnMin = -100;
    [SerializeField] float spawnMax = 100;
    [SerializeField] float spawnDelay = 1;
    [SerializeField] float spawnTime = 1;
    [SerializeField] GameObject[] enemies;

    private void Start() {
        InvokeRepeating("SpawnEnemiesRandom", spawnDelay, spawnTime);
    }

    void SpawnEnemiesRandom() {
        int enemyIndex = Random.Range(0, enemies.Length);
        Vector3 spawnLocation = new Vector3(Random.Range(spawnMin, spawnMax), 8.75f, 100);
        Instantiate(enemies[enemyIndex], spawnLocation, transform.rotation);
    }

}
