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
        // change angle in accordance to incoming wave
        Ray ray = new Ray(transform.position, transform.position + Vector3.forward * maxRayDistance + Vector3.up * maxRayDistance);

        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + Vector3.forward * maxRayDistance + Vector3.up * maxRayDistance, Color.red);

        if (!Physics.Raycast(ray, out hit, maxRayDistance))
        {
            try
            {
                Debug.Log("tag: " + hit.collider.tag);
            }
            catch
            {
                Debug.Log("Player dies");
            }
            
            
        }
    }

    // Update is called once per frame
    void Update () {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(move * movementSpeed * Time.deltaTime);
	}
}
