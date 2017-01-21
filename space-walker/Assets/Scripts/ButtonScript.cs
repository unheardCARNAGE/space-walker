using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("radius: " + (player.transform.position - transform.position).sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Mouse0) && (player.transform.position - transform.position).sqrMagnitude < 3.0f)
        {
            //Debug.Log("radius: " + (player.transform.position - transform.position).sqrMagnitude);
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
	}
}
