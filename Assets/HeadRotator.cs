using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotator : MonoBehaviour
{
    public Transform eyeL;
    public Transform eyeR;

    public List<GameObject> spikes = new List<GameObject>();
    public List<GameObject> horns = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Find gameobjects with the tag "Spike" and add them to the list
        foreach (GameObject spike in GameObject.FindGameObjectsWithTag("teeth"))
        {
            spikes.Add(spike);
        }
        // Find gameobjects with the tag "Hand" and add them to the list
        foreach (Hand hand in GetComponentsInChildren<Hand>())
        {
            horns.Add(hand.gameObject);
        }
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

        foreach (GameObject horn in horns)
        {
            if (xp.levels >= 1.0f)
            {
                horn.SetActive(true);
                var zScale = 0.1f + xp.levels * 0.5f;
                horn.transform.localScale = new Vector3(horn.transform.localScale.x, horn.transform.localScale.y, zScale);
            }
            else
            {
                horn.SetActive(false);
            }
        }
    }
}
