﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    public string loadScene;

    public List<string> receivedKeys;

    public float movementSpeed = 50f;
    public float maxRayDistance = 100.0f;

    private Vector3 move;

    public Transform wave;

	public static bool hasSaveStart = false;
    public static Vector3 saveLocation;

    void Start()
    {
		Debug.Log("Start Called with: " + hasSaveStart);
		if (!hasSaveStart){
			saveLocation = transform.position;
			hasSaveStart = true;
		} else{
			transform.position = saveLocation;
		}
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (move.x == 1f || move.x == -1f || move.z == 1f || move.z == -1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
        }

        /*if (Input.GetKey(KeyCode.D))
        {
            if(transform.rotation.x < 90)
                transform.Rotate(Vector3.Lerp());
        }*/

        transform.Translate(move * movementSpeed * Time.deltaTime, Space.World);
    }

    public void CreateRay()
    {
        Ray ray = new Ray(transform.position, -wave.transform.forward);

        RaycastHit hit;

        Debug.DrawRay(transform.position, -wave.transform.forward * maxRayDistance, Color.red);

        if (!Physics.Raycast(ray, out hit, maxRayDistance, LayerMask.GetMask("Obstacle")))
        {
            // play death animation
            SceneManager.LoadScene(loadScene);
        }
    }
}
