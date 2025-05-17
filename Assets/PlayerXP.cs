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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EnemyDefeated(EnemyController enemy)
    {
        // Add XP to the player
        Debug.Log("Enemy defeated! Gained XP.");
        StartCoroutine(ChangeXpAfterDelay(1, 0.5f));
        changeXp(1);
    }

    public void changeXp(int amount)
    {
        playerXP += amount;
        xpDisplay.text = "XP: " + playerXP.ToString();

        if(playerXP >= 10)
        {
            GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<LevelController>().startUpgrading();
            Debug.Log("Level Up! time to start upgrading!");
            levels++;
        }
        // Play the XP sound
        audioSource.PlayOneShot(xpSound);
        playerXP += 1;
    }

    private IEnumerator ChangeXpAfterDelay(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        changeXp(amount);
    }
}
