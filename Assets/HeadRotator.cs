using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotator : MonoBehaviour
{
    public Transform eyeL;
    public Transform eyeR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 l_to_r = eyeR.position - eyeL.position;
        Vector3 l_to_r_normalized = l_to_r.normalized;

        // Angle to x-axis
        float angle = Mathf.Atan2(l_to_r_normalized.y, l_to_r_normalized.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(-90 - angle, 90, 90);
    }
}
