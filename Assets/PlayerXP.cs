using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int playerXP = 0; // Player's XP

    public void EnemyDefeated(EnemyController enemy)
    {
        // Add XP to the player
        Debug.Log("Enemy defeated! Gained XP.");
        playerXP += 1;
    }
}
