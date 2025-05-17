using CJM.HumanPose2DToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.Device;

public class PlayerModelManager : MonoBehaviour
{
    public enum PartUpgrade
    {
        None,
        Wolverine,
        Teeth,
        Spiky,
        Horns
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

    public float movementMultiplier = 1.0f;
    public float confidenceThreshold;



    

    //keep at same size as the inferencecontrollers 
    public CharacterPart[] CharacterParts;





    // Start is called before the first frame update
    void Start()
    {
        // Get the screen size
        screenW = UnityEngine.Screen.width;
        screenH = UnityEngine.Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerAbsolute();
        pointHandForward();
     
    }


    private void pointHandForward()
    {
        float leftHandX = inferenceController.humanPoses[0].bodyParts[9].coordinates[0];
        float leftHandY = inferenceController.humanPoses[0].bodyParts[9].coordinates[1];

        float leftElbowX = inferenceController.humanPoses[0].bodyParts[7].coordinates[0];
        float leftElbowY = inferenceController.humanPoses[0].bodyParts[7].coordinates[1];

        Vector2 leftHand = new Vector2(leftHandX, leftHandY);
        Vector2 leftElbow = new Vector2(leftElbowX, leftElbowY);
        Vector2 handForward = leftHand - leftElbow;
        
        CharacterParts[9].gameObject.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(handForward.y, handForward.x) * Mathf.Rad2Deg);
    }

    private void UpdatePlayerAbsolute()
    {
        for (int i = 0; i < inferenceController.humanPoses[0].bodyParts.Length; i++)
        {
            BodyPart2D bodyPart = inferenceController.humanPoses[0].bodyParts[i];
            float xp = bodyPart.coordinates[0];
            float yp = bodyPart.coordinates[1];

            float x = (xp - screenW / 2) / screenW * movementMultiplier;
            float y = (yp - screenH / 2) / screenH * movementMultiplier;

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
}


