using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int levels = 0;
    public int playerXP = 0; // Player's XP
    public TextMeshProUGUI xpDisplay;
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

    public void changeXp(int amount)
    {
        playerXP += amount;
        xpDisplay.text = "XP: " + playerXP.ToString();

        if (playerXP >= (levels + 1) * 10)
        {
            levelController.startUpgrading();
            Debug.Log("Level Up! time to start upgrading!");
            levels++;
            playerXP = 0;
        }
        // Play the XP sound
        audioSource.PlayOneShot(xpSound);
        playerXP += 1;
        levelController.difficulty += 1;
    }

    private IEnumerator ChangeXpAfterDelay(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        changeXp(amount);
    }
}
