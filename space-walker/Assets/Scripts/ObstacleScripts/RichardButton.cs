using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardButton : MonoBehaviour {
    public GameObject[] obstacleAry;
    public bool clickable;


    //Temporary, Placeholder
    public GameObject buttonNotification;
    private GameObject button_notification;
    
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

            //Temporary, Placeholder
            //button_notification = Instantiate<GameObject>(buttonNotification, gameObject.transform.position, Quaternion.identity);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == "Player")
        {
            clickable = false;

            //Temporary, Placeholder
            Destroy(button_notification, 1.0f);
        }
    }
}
