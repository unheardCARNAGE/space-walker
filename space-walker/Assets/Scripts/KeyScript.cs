using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    //When the user gets the key, the key's name should be pushed into the PlayerScript's List receivedKeys.
    //Once the keys are added into a specific button, the key's name in the receivedKeys should be popped out.

    public GameObject player;

    private bool can_be_carried;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (can_be_carried && Input.GetKey(KeyCode.Space))
        {
                Debug.Log("player has the key");
                Destroy(gameObject);
                player.GetComponent<PlayerScript>().receivedKeys.Add(gameObject.name);
        }


    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Player")
        {
            can_be_carried = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            can_be_carried = false;
        }
    }
}
