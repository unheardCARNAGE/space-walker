using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButtonScript : MonoBehaviour {

    public string keyName;
    public GameObject player;
    public bool isClickable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            foreach(string key in player.GetComponent<PlayerScript>().receivedKeys)
            {
                if(keyName == key)
                {
                    Debug.Log("door can be opened");
                    isClickable = true;
                    break;
                }
            }
        }
    }
}
