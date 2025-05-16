using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelManager : MonoBehaviour
{
    [System.Serializable]
    public struct CharacterPart
    {
        //gameobject to control
        [Tooltip("GameObject to control")]
        public GameObject gameObject;

        [Tooltip("Index of the part in the humanpose2d from where position is read")]
        //index of the part in the HumanPose2D
        public int index;
    }
    //This reference allows to read the HumanPose2D as well as many other things =)
    public InferenceController inferenceController;

    public GameObject head;


    //upper body
    public CharacterPart wrist_l;
    public CharacterPart elbow_l;
    public CharacterPart shoulder_l;

    public CharacterPart wrist_r;
    public CharacterPart elbow_r;
    public CharacterPart shoulder_r;


    //lower body
    public CharacterPart foot_l;
    public CharacterPart knee_l;
    public CharacterPart hip_l;

    public CharacterPart foot_r;
    public CharacterPart knee_r;
    public CharacterPart hip_r;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
