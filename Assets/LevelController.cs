using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
