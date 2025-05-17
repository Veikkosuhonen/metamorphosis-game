using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnedEnemySpeed;
    public GameObject enemyPrefab;

    public float lastSpawn = 0.0f;
    public float spawnRate = 5.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>().currentLevelState == LevelController.LevelState.Upgrading)
        {
            return;
        }   


        //spawn enemy when spawnRate is reached
        if (Time.time > lastSpawn + spawnRate)
        {
            SpawnEnemy();
            lastSpawn = Time.time;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().speed = spawnedEnemySpeed;
    }
}
