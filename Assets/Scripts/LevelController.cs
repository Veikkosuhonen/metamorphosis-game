using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public List<EnemySpawner> enemySpawners = new List<EnemySpawner>();


    public float difficulty = 1;
    float trueStart = 0.0f;
    public enum LevelState
    {
        Start,
        Playing,
        Upgrading,
        GameOver,
    }


    public LevelState currentLevelState = LevelState.Playing;

    // Start is called before the first frame update
    void Start()
    {
        foreach (EnemySpawner ep in enemySpawners)
        {
            ep.spawnMode = EnemySpawner.mode.manual;
        }
        trueStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > trueStart + 10)
        {
            //spawn enemies on the left
            foreach (EnemySpawner ep in enemySpawners)
            {
                if(ep.spawnGroup == EnemySpawner.group.left)
                {
                    ep.spawnMode = EnemySpawner.mode.automatic;
                }
            }
        }


        if (Time.time > trueStart + 30)
        {
            //spawn enemies on the left
            foreach (EnemySpawner ep in enemySpawners)
            {
                if (ep.spawnGroup == EnemySpawner.group.right)
                {
                    ep.spawnMode = EnemySpawner.mode.automatic;
                }
            }
        }


        if (Time.time > trueStart + 60)
        {
            //spawn enemies on the left
            foreach (EnemySpawner ep in enemySpawners)
            {
                if (ep.spawnGroup == EnemySpawner.group.top)
                {
                    ep.spawnMode = EnemySpawner.mode.automatic;
                }
            }
        }
    }

    public void endGame()
    {
        currentLevelState = LevelState.GameOver;
        Debug.Log("Game Over");
    }


    public void startUpgrading()
    {
        currentLevelState = LevelState.Upgrading;
        Debug.Log("Upgrading");
    }


    public void enterPlaying()
    {
        currentLevelState = LevelState.Playing;
        Debug.Log("Playing");
    }


}
