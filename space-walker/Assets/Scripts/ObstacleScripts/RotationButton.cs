using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButton : MonoBehaviour {
    public GameObject[] obstacleAry;
    public bool clickable;

    void OnMouseUp()
    {
        if (!clickable)
        {
            return;
        }

        foreach (GameObject obstacle in obstacleAry)
        {
            if (!obstacle.GetComponent<RotationScript>().pressed)
            {
                obstacle.GetComponent<RotationScript>().pressed = true;
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Player")
        {
            clickable = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == "Player")
        {
            clickable = false;
        }
    }
}
