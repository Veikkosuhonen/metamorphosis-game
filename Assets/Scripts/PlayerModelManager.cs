using CJM.HumanPose2DToolkit;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

using UnityEngine.Device;

public class PlayerModelManager : MonoBehaviour
{
    public enum PartUpgrade
    {
        None,
        Wolverine,
        Healing,
    }
    public List<PartUpgrade> unlockedUpgrades = new List<PartUpgrade>();

    
    [System.Serializable]
    public struct CharacterPart
    {
        //gameobject to control
        [Tooltip("GameObject to control")]
        public GameObject gameObject;



    }
    //This reference allows to read the HumanPose2D as well as many other things =)
    public InferenceController inferenceController;


    //This is the multiplier for the position of the character parts
    public float screenW;
    public float screenH;

    public float movementMultiplierX = 1.0f;
    public float movementMultiplierY = 1.0f;
    public float confidenceThreshold;

    public float clawSizeMultiplier = 1.0f;

    

    //keep at same size as the inferencecontrollers 
    public CharacterPart[] CharacterParts;

    private PlayerHp playerHp;



    // Start is called before the first frame update
    void Start()
    {
        // Get the screen size
        screenW = UnityEngine.Screen.width;
        screenH = UnityEngine.Screen.height;

        playerHp = gameObject.GetComponent<PlayerHp>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHp.hp <= 0)
        {
            killPlayer();
        }
        else
        {
            UpdatePlayerAbsolute();
            pointHandForward(9, 7); //left
            pointHandForward(10, 8); //right
        }

    }

    void killPlayer()
    {
        for (int i = 0; i < CharacterParts.Length; i++)
        {
            Rigidbody rig = CharacterParts[i].gameObject.GetComponent<Rigidbody>();
            if (rig)
            {
                CharacterParts[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
                CharacterParts[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            else
            {
                CharacterParts[i].gameObject.AddComponent<Rigidbody>();
                CharacterParts[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
                CharacterParts[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }


    private void pointHandForward(int handIndex, int elbowIndex)
    {
        float HandX = inferenceController.humanPoses[0].bodyParts[handIndex].coordinates[0];
        float HandY = inferenceController.humanPoses[0].bodyParts[handIndex].coordinates[1];

        float ElbowX = inferenceController.humanPoses[0].bodyParts[elbowIndex].coordinates[0];
        float ElbowY = inferenceController.humanPoses[0].bodyParts[elbowIndex].coordinates[1];

        Vector2 Hand = new Vector2(HandX, HandY);
        Vector2 Elbow = new Vector2(ElbowX, ElbowY);
        Vector2 handForward = Hand - Elbow;
        
        CharacterParts[handIndex].gameObject.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(handForward.y, handForward.x) * Mathf.Rad2Deg);
    }

    private void UpdatePlayerAbsolute()
    {
        for (int i = 0; i < inferenceController.humanPoses[0].bodyParts.Length; i++)
        {
            BodyPart2D bodyPart = inferenceController.humanPoses[0].bodyParts[i];
            float xp = bodyPart.coordinates[0];
            float yp = bodyPart.coordinates[1];

            float x = (xp - screenW / 2) / screenW * movementMultiplierX;
            float y = (yp - screenH / 2) / screenH * movementMultiplierY;

            if (bodyPart.prob < confidenceThreshold)
            {
                continue;
            }

            if (i > CharacterParts.Length - 1)
            {
                continue;
            }

            if (CharacterParts[i].gameObject == null)
            {
                continue;
            }

            

            CharacterParts[i].gameObject.transform.position = Vector3.Lerp(
                CharacterParts[i].gameObject.transform.position,
                new Vector3(x, y, CharacterParts[i].gameObject.transform.position.z),
                Time.deltaTime * 10f
            );
        }


    }

    public void upgradeTo(PartUpgrade upgrade)
    {

        Debug.Log(upgrade + " unlocked!");
        unlockedUpgrades.Add(upgrade);
        if (upgrade == PartUpgrade.None)
        {
            Debug.Log("No upgrade selected");
            return;
        }

        if (upgrade == PartUpgrade.Healing)
        {
            Debug.Log("Healing the player!");
            playerHp.hp += 100;
            return;
        }
        
        if(upgrade == PartUpgrade.Wolverine)
        {
            clawSizeMultiplier *= 1.5f;
            increaseClawSize(9); //left
            increaseClawSize(10); //right
        }

   
    }


    void increaseClawSize(int handIndex)
    {
        GameObject claw = CharacterParts[handIndex].gameObject;
        claw.GetComponent<Hand>().growClaws(clawSizeMultiplier);
    }
}


