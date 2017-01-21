using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float movementSpeed = 0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Movement
        Vector3 newPos = transform.position;

        //Up
            if (Input.GetKey(KeyCode.W))
            {
                newPos += new Vector3(
                    0,
                    0,
                    movementSpeed
                    );
            }
        //Left
            if (Input.GetKey(KeyCode.A))
            {
                newPos += new Vector3(
                    -movementSpeed,
                    0,
                    0);
            }
        //Down
            if (Input.GetKey(KeyCode.S))
            {
                newPos += new Vector3(
                    0,
                    0,
                    -movementSpeed);
            }
        //Up
            if (Input.GetKey(KeyCode.D))
            {
                newPos += new Vector3(
                    movementSpeed,
                    0,
                    0);
            }

        transform.position = newPos;
	}
}
