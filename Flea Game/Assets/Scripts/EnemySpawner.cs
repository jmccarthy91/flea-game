using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private bool canSpawn = true;
    
    // Start my spawning coroutine
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // IEnumerator lets me execute a function over several frames
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnInterval);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
