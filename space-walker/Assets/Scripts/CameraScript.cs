using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform player;
    public float smoothTime = 0.3f;
    public Vector3 originalPos;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        originalPos = transform.position;
        transform.position = player.transform.position + transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = player.transform.position + new Vector3(height, 6, -distance);
        //Vector3 goalPos = new Vector3(player.position.x, transform.position.y, dist);

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + originalPos, ref velocity, smoothTime);
    }
}
