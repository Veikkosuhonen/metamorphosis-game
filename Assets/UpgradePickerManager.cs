using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickerManager : MonoBehaviour
{
    public List<UpgradePicker> upgradePickers = new List<UpgradePicker>();

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>().currentLevelState == LevelController.LevelState.Upgrading)
        {
            foreach (UpgradePicker upgradePicker in upgradePickers)
            {
                upgradePicker.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (UpgradePicker upgradePicker in upgradePickers)
            {
                upgradePicker.gameObject.SetActive(false);
            }
        }
    }
}
