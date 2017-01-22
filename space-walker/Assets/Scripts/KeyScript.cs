using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    //When the user gets the key, the key's name should be pushed into the PlayerScript's List receivedKeys.
    //Once the keys are added into a specific button, the key's name in the receivedKeys should be popped out.

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("player has the key");
            Destroy(gameObject, 0.5f);
            player.GetComponent<PlayerScript>().receivedKeys.Add(gameObject.name);
        }
    }
}
