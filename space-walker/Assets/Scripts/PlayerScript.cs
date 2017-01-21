using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float movementSpeed = 50f;
    public float maxRayDistance = 100.0f;

    private Vector3 move;

    public Transform wave;

    // Update is called once per frame
    void Update () {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(move * movementSpeed * Time.deltaTime);
	}

    public void CreateRay()
    {
        Ray ray = new Ray(transform.position, -wave.transform.forward);

        RaycastHit hit;

        Debug.DrawRay(transform.position, -wave.transform.forward * maxRayDistance, Color.red);

        if (!Physics.Raycast(ray, out hit, maxRayDistance))
        {
            Debug.Log("Player dies");
        }
    }
}
