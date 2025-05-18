using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public int hp = 100;

    //reference to the textmeshpro text component
    public TextMeshProUGUI hpDisplay;

    public AudioClip hurtSound;
    public AudioClip deathSound;
    private AudioSource audioSource;

    private LevelController levelController;


    // Start is called before the first frame update
    void Start()
    {
        hpDisplay.text = "HP: " + hp.ToString();
        audioSource = GetComponent<AudioSource>();
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }


    public void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("Player is dead!");
            hpDisplay.text = "! YOU DIED !";
            // Play the death sound
            audioSource.PlayOneShot(deathSound);

            levelController.endGame();
        }
        else
        {
            hpDisplay.text = "HP: " + hp.ToString();
            // Play the hurt sound
            audioSource.PlayOneShot(hurtSound);
        }
    }
  
}
