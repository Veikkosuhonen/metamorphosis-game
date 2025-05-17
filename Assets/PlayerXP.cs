using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
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
        changeXp(1);

    }

    public void changeXp(int amount)
    {
        playerXP += amount;
        xpDisplay.text = "XP: " + playerXP.ToString();
        // Play the XP sound
        audioSource.PlayOneShot(xpSound);
        playerXP += 1;
    }
}
