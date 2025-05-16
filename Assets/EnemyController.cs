using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 10.0f;
    public float upDownMovement = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time + transform.position.x) * upDownMovement, transform.position.z);
    }
}
