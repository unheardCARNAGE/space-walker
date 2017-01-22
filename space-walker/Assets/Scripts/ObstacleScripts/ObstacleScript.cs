using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
	public Vector3 activeOffset;
	public bool relativeRotation = false;
    public float movementDuration = 3f;
	//public bool canBeUndone = true;
	//private bool hasBeenUsed = false;

    private float timePassed = 0f;
    private Vector3 originalPos;

    public bool running = false;
    public bool active;

    // Use this for initialization
    void Start()
    {
		if(relativeRotation){
			activeOffset = transform.rotation * activeOffset;
		}

        originalPos = transform.position;

        if (active)
        {
            originalPos -= activeOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (running)
        {
			timePassed += Time.deltaTime;
            if (active)
            {
				transform.position = Vector3.Lerp(originalPos + activeOffset, originalPos, timePassed / movementDuration);
            }
            else
            {
				transform.position = Vector3.Lerp(originalPos, originalPos + activeOffset, timePassed / movementDuration);
            }

            if (timePassed > movementDuration)
            {
                running = false;
                active = !active;
                timePassed = 0f;
            }
        }
    }
}
