using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public int hp = 100;

    //reference to the textmeshpro text component
    public TextMeshProUGUI hpDisplay;


    // Start is called before the first frame update
    void Start()
    {
        hpDisplay.text = "HP: " + hp.ToString();
    }


    public void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("Player is dead!");
            hpDisplay.text = "! YOU DIED !";

        }
        else
        {
            hpDisplay.text = "HP: " + hp.ToString();
        }
    }
  
}
