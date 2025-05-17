using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{

    public PlayerModelManager.PartUpgrade PartUpgrade;
    public TextMeshProUGUI upgradeText;
    

    public void SetUpgrade(PlayerModelManager.PartUpgrade upgrade)
    {
        PartUpgrade = upgrade;
        upgradeText.text = PartUpgrade.ToString();
    }
}
