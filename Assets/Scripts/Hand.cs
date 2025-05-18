using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour


{


    public List<GameObject> claws = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("upgrade"))
        {
          UpgradePicker upgradePicker = other.GetComponent<UpgradePicker>();
          GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerModelManager>().upgradeTo(upgradePicker.PartUpgrade);
          GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>().currentLevelState = LevelController.LevelState.Playing;

        }
    }


    public void growClaws(float multiplier)
    {
        foreach (GameObject claw in claws)
        {
            claw.transform.localScale = new Vector3(claw.transform.localScale.x, claw.transform.localScale.y, claw.transform.localScale.z * multiplier);
        }

        gameObject.GetComponent<BoxCollider>().size = new Vector3(gameObject.GetComponent<BoxCollider>().size.x * multiplier, gameObject.GetComponent<BoxCollider>().size.y, gameObject.GetComponent<BoxCollider>().size.z * multiplier);
    }
}
