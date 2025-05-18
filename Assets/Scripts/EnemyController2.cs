using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : EnemyController
{
    public Transform target;

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

        if (target != null) {
            gameObject.transform.LookAt(target);
            transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        }
    }

}
