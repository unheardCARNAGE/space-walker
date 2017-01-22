using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBox : MonoBehaviour {

	[SerializeField] Transform start;
	[SerializeField] Transform end;
	[SerializeField] float speed = 4f;
	[SerializeField] float timeOffset = 0f;

	float duration;
	float currentTime = 0f;
	bool forward = true;

	// Use this for initialization
	void Start () {
		duration = Vector3.Distance(start.position, end.position) / speed;
		currentTime = timeOffset;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += forward ? Time.deltaTime : -Time.deltaTime;
		transform.position = Vector3.Lerp(start.position, end.position, currentTime/duration);
		if(forward && currentTime >= duration){
			forward = !forward;
		} else if(!forward && currentTime <= 0f){
			forward = !forward;
		}
	}
}
