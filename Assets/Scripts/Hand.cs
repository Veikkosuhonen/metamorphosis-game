using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("upgrade"))
        {
          UpgradePicker upgradePicker = other.GetComponent<UpgradePicker>();
          GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerModelManager>().upgradeTo(upgradePicker.PartUpgrade);
          GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>().currentLevelState = LevelController.LevelState.Playing;

        }
    }
}
