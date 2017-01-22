using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButton : MonoBehaviour {
    public RotationScript[] obstacleAry;
    public bool clickable;

    void Update()
    {
        if (clickable && Input.GetKeyDown(KeyCode.Space))
        {
            foreach (RotationScript obstacle in obstacleAry)
            {
                obstacle.running = true;
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
