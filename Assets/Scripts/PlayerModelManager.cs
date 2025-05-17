using CJM.HumanPose2DToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerModelManager : MonoBehaviour
{
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
    public float confidenceThreshold = 0.5f;



    public CharacterPart head;

    //keep at same size as the inferencecontrollers 
    public CharacterPart[] CharacterParts;





    // Start is called before the first frame update
    void Start()
    {
        // Get the screen size
        screenW = Screen.width;
        screenH = Screen.height;
    }

    // Update is called once per frame
    void Update()
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
