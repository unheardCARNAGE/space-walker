using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButton : MonoBehaviour {
    public ObstacleScript[] obstacleAry;
    public bool clickable;

    void OnMouseUp()
    {
        if (!clickable)
        {
            return;
        }

        foreach (ObstacleScript obstacle in obstacleAry)
        {
            obstacle.running = true;
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
