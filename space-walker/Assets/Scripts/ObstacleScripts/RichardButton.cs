using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardButton : MonoBehaviour {
    public GameObject[] obstacleAry;
    public bool clickable;
    
    void OnMouseDown()
    {
        if (!clickable)
        {
            return;
        }

        foreach (GameObject obstacle in obstacleAry) {
            if (!obstacle.GetComponent<ObstacleActivated>().active)
            {
                obstacle.GetComponent<ObstacleActivated>().active = true;
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
