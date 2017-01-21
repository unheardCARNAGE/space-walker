using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {
    public float yDir;
    public float movementSpeed;

    private float timePassed;
    private Vector3 originalPos;

    public bool up;

    // Use this for initialization
    void Start () {
        originalPos = transform.position;

        if (up)
        {
            originalPos.y -= yDir;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<ObstacleActivated>().active)
        {
            if (up)
            {
                transform.position = new Vector3(originalPos.x, Mathf.Lerp(originalPos.y + yDir, originalPos.y, timePassed), originalPos.z);
                timePassed += movementSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(originalPos.x, Mathf.Lerp(originalPos.y, originalPos.y + yDir, timePassed), originalPos.z);
                timePassed += movementSpeed * Time.deltaTime;
            }

            if (timePassed > 1.0f)
            {
                GetComponent<ObstacleActivated>().active = false;
                up = !up;
                timePassed = 0.0f;
            }
        }
    }
}
