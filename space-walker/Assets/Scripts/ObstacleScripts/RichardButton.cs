using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardButton : MonoBehaviour {
    public GameObject[] obstacleAry;
    
    void OnMouseDown()
    {
        foreach (GameObject obstacle in obstacleAry) {
            if (!obstacle.GetComponent<ObstacleActivated>().active)
            {
                obstacle.GetComponent<ObstacleActivated>().active = true;
            }
        }
    }
}
