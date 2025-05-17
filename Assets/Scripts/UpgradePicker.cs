using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{

    public PlayerModelManager.PartUpgrade PartUpgrade;
    public TextMeshPro upgradeText;

    void Start()
    {
        upgradeText.text = PartUpgrade.ToString();
    }

    public void SetUpgrade(PlayerModelManager.PartUpgrade upgrade)
    {
        PartUpgrade = upgrade;
        upgradeText.text = PartUpgrade.ToString();
    }
}
