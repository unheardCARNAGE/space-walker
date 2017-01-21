using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform player;
    public float offset = 25f;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

	void Start(){
		if(offset == -1f){
			offset = player.position.z - transform.position.z;
		}
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 goalPos = player.position;
        goalPos.z = player.position.z - offset;
        goalPos.y = transform.position.y;

        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
	}
}
