using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotator : MonoBehaviour
{
    public Transform eyeL;
    public Transform eyeR;

    public GameObject[] spikes;

    // Start is called before the first frame update
    void Start()
    {
        // Find gameobjects with the tag "Spike" and add them to the list
        spikes = GameObject.FindGameObjectsWithTag("teeth");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 l_to_r = eyeR.position - eyeL.position;
        Vector3 l_to_r_normalized = l_to_r.normalized;

        // Angle to x-axis
        float angle = Mathf.Atan2(l_to_r_normalized.y, l_to_r_normalized.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(-90 - angle, 90, 90);


        var player = GameObject.FindGameObjectWithTag("Player");
        var xp = player.GetComponent<PlayerXP>();
        // Update spikes based on XP
        foreach (GameObject spike in spikes)
        {
            if (xp.levels >= 1.0f)
            {
                spike.SetActive(true);
                var zScale = 0.1f + xp.levels * 0.1f;
                spike.transform.localScale = new Vector3(spike.transform.localScale.x, spike.transform.localScale.y, zScale);
            }
            else
            {
                spike.SetActive(false);
            }
        }
    }
}
