using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool dead = false;
    public float speed = 10.0f;
    public float upDownMovement = 3.0f;
    public float initialY = 0.0f;


    public AudioSource audioSource;
    public AudioClip[] deathSounds;

    public LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        initialY = gameObject.transform.position.y;
        audioSource = GetComponent<AudioSource>();
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
        //this line of code is totally the best practise =)
        if (levelController.currentLevelState == LevelController.LevelState.Upgrading)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            return;

        }
        else
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x, initialY + Mathf.Sin(Time.time + transform.position.x) * upDownMovement, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.CompareTag("Player"))
        {
            // Call the method to handle collision with the player
            Debug.Log("Enemy collided with player!");
            Object.Destroy(gameObject);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (dead)
        {
            return;
        }

        //this line of code is totally the best practise =)
        if(levelController.currentLevelState == LevelController.LevelState.Upgrading)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Wrist") == true)
        {
            Rigidbody rbody = gameObject.GetComponent<Rigidbody>();
            dead = true;
            rbody.useGravity = true;
            rbody.isKinematic = false;
            rbody.freezeRotation = false;
            Vector3 fnormal = collision.contacts[0].normal;
            fnormal.z += Random.Range(-1.0f, 1.0f);

            rbody.AddForce( fnormal * 10.0f, ForceMode.Impulse);
            rbody.AddTorque(fnormal * 1.0f, ForceMode.Impulse);
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerXP>().EnemyDefeated(this);
            PlayDeathSound();
        }

        if (collision.gameObject.CompareTag("Player") == true)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerHp>().takeDamage(15);
        }

        if (collision.gameObject.CompareTag("hurtable") == true)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerHp>().takeDamage(10);
        }
    }

    private void PlayDeathSound()
    {
        // Play a random death sound
        int randomIndex = Random.Range(0, deathSounds.Length);
        audioSource.PlayOneShot(deathSounds[randomIndex]);
    }
}
