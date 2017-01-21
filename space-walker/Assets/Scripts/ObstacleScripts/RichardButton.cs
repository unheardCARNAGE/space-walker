using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardButton : MonoBehaviour {
    public GameObject[] obstacleAry;
    public bool clickable;
    
    void OnMouseUp()
    {
        if (!clickable)
        {
            return;
        }

        foreach (GameObject obstacle in obstacleAry) {
            if (!obstacle.GetComponent<ObstacleScript>().pressed)
            {
                obstacle.GetComponent<ObstacleScript>().pressed = true;
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
