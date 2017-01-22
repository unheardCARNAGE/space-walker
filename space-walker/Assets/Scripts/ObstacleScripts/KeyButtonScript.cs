using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButtonScript : MonoBehaviour {

    public string keyName;
    public GameObject player;

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
                    GetComponent<TransformButton>().clickable = true;
                    return;
                }
            }
            GetComponent<TransformButton>().clickable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<TransformButton>().clickable = false;
    }
}
