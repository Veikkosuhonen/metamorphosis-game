using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool dead = false;
    public float speed = 10.0f;
    public float upDownMovement = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
        transform.position -= Vector3.right * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time + transform.position.x) * upDownMovement, transform.position.z);
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
        Debug.Log("Enemy collided with player!");
        if (collision.transform.parent.gameObject.CompareTag("Player"))
        {
            Rigidbody rbody = gameObject.GetComponent<Rigidbody>();
            dead = true;
            rbody.useGravity = true;
            rbody.isKinematic = false;

        }
    }
}
