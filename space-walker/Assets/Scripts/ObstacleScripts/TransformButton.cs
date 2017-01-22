using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformButton : MonoBehaviour {
    public ObstacleScript[] obstacleAry;
    public bool clickable;

    //Temporary, Placeholder
	public GameObject buttonNotification = null;
    private GameObject button_notification = null;

	public UnityEvent onUse;

    void Update()
    {
        if (clickable && Input.GetKeyDown(KeyCode.Space))
        {
            foreach (ObstacleScript obstacle in obstacleAry)
            {
                obstacle.running = true;
            }
			onUse.Invoke();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Player")
        {
            clickable = true;

            //Temporary, Placeholder
			if(buttonNotification != null){
				button_notification = Instantiate<GameObject>(buttonNotification, gameObject.transform.position, Quaternion.identity);
			}
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == "Player")
        {
            clickable = false;

            //Temporary, Placeholder
			if (button_notification != null){
				Destroy(button_notification, 1.0f);
			}
        }
    }
}
