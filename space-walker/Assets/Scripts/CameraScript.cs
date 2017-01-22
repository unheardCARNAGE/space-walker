using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform player;
    public float smoothTime = 0.3f;
    public Vector3 originalPos;

    private Vector3 velocity = Vector3.zero;

	public static CameraScript mainCamera;

    void Start()
    {
		mainCamera = this;
        originalPos = transform.position;
        transform.position = player.transform.position + transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + originalPos, ref velocity, smoothTime);
    }
}
