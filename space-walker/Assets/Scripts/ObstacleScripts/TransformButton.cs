using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformButton : MonoBehaviour {
    public ObstacleScript[] obstacleAry;
    public bool clickable;


    //Temporary, Placeholder
    public GameObject buttonNotification;
    private GameObject button_notification;

    void Update()
    {
        if (clickable && Input.GetKeyDown(KeyCode.Space))
        {
            foreach (ObstacleScript obstacle in obstacleAry)
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

            //Temporary, Placeholder
            button_notification = Instantiate<GameObject>(buttonNotification, gameObject.transform.position, Quaternion.identity);
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
