using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float movementSpeed = 50f;
    public float maxRayDistance = 100.0f;

    private Vector3 move;

    public Transform wave;

    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        //Ray casting

        //Ray ray = new Ray(transform.position, -light.transform.forward);
        Ray ray = new Ray(transform.position, transform.position + Vector3.forward * maxRayDistance + Vector3.up * maxRayDistance);

        RaycastHit hit;

        //Debug.DrawLine()
        Debug.DrawLine(transform.position, transform.position + Vector3.forward * maxRayDistance + Vector3.up * maxRayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            Debug.Log("Player dies");
            Debug.DrawLine(transform.position, transform.position + Vector3.forward * maxRayDistance, Color.blue, 100f, false);
        }
    }

    // Update is called once per frame
    void Update () {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(move * movementSpeed * Time.deltaTime);
	}
}
