using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnedEnemySpeed;
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;

    public float lastSpawn = 0.0f;
    public float spawnRate = 5.0f;
    public float randomOffset;


    private LevelController levelController;
    
    void Start()
    {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnRate = 5.0f / (1.0f + 0.03f * levelController.difficulty);

        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>().currentLevelState == LevelController.LevelState.Upgrading)
        {
            return;
        }   


        //spawn enemy when spawnRate is reached
        if (Time.time > lastSpawn + spawnRate + randomOffset)
        {
            SpawnEnemy();
            lastSpawn = Time.time;
            randomOffset = Random.Range(0.0f, 2.0f);
        }
    }

    void SpawnEnemy()
    {
        var prefabChoice = Random.Range(0, 4);
        var nextPrefab = enemyPrefab;
        if (prefabChoice == 0)
        {
            nextPrefab = enemy2Prefab;
        }

        GameObject enemy = Instantiate(nextPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().speed = spawnedEnemySpeed;

        if (prefabChoice == 0)
        {
            enemy.GetComponent<EnemyController2>().target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        enemy.transform.forward = gameObject.transform.forward;
    }
}
