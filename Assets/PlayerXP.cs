using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public void EnemyDefeated(EnemyController enemy)
    {
        // Add XP to the player
        Debug.Log("Enemy defeated! Gained XP.");
        // You can add your XP logic here
        // For example, increase player's XP by a certain amount
    }
}
