using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int levels = 0;
    public int playerXP = 0; // Player's XP
    public TextMeshProUGUI xpDisplay;

    public TextMeshProUGUI scoreDisplay;
    public int score = 0; // Player's score
    private AudioSource audioSource;
    public AudioClip xpSound;

    private LevelController levelController;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    public void EnemyDefeated(EnemyController enemy)
    {
        // Add XP to the player
        Debug.Log("Enemy defeated! Gained XP.");
        StartCoroutine(ChangeXpAfterDelay(1, 0.5f));

    }

    public void changeXp(int amount, bool playSound = true)
    {
        playerXP += amount;
        xpDisplay.text = "XP: " + playerXP.ToString();
        score += amount;
        scoreDisplay.text = "Score: " + score.ToString();

        if (playerXP >= (levels + 1) * 10)
        {
            levelController.startUpgrading();
            Debug.Log("Level Up! time to start upgrading!");
            levels++;
            playerXP = 0;
        }

        // Play the XP sound
        if (playSound) audioSource.PlayOneShot(xpSound);

        levelController.difficulty += 1;
    }

    private IEnumerator ChangeXpAfterDelay(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        changeXp(amount);
    }

    private float lastChangeTime = 0.0f;
    private void FixedUpdate()
    {
        // Add xp every second
        if (Time.time - lastChangeTime >= 1.0f && levelController.currentLevelState == LevelController.LevelState.Playing)
        {
            changeXp(1, false);
            lastChangeTime = Time.time;
        }
    }
}
