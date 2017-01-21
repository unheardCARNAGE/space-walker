using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public int health = 100;
    public float movementSpeed = 0.05f;
    public float maxRayDistance = 200.0f;

    public Transform light;

    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        //Ray casting

        Ray ray = new Ray(transform.position, -light.transform.forward);

        RaycastHit hit;

        //Debug.DrawLine()
        Debug.DrawLine(transform.position, transform.position + Vector3.forward * maxRayDistance + Vector3.up * maxRayDistance, Color.red, 100f, false);

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            Debug.Log("Player dies");
            Debug.DrawLine(transform.position, transform.position + Vector3.forward * maxRayDistance, Color.blue, 100f, false);
        }
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
