using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
    public float xDir;
    public float yDir;
    public float zDir;
    public float movementSpeed = 3f;

    private float timePassed;
    private Vector3 originalPos;

    public bool active;

    // Use this for initialization
    void Start()
    {
        originalPos = transform.position;

        if (active)
        {
            originalPos -= new Vector3(xDir, yDir, zDir);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ObstacleActivated>().activated)
        {
            if (active)
            {
                transform.position = new Vector3(Mathf.Lerp(originalPos.x + xDir, originalPos.x, timePassed), Mathf.Lerp(originalPos.y + yDir, originalPos.y, timePassed), Mathf.Lerp(originalPos.z + zDir, originalPos.z, timePassed));
                timePassed += movementSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(Mathf.Lerp(originalPos.x, originalPos.x + xDir, timePassed), Mathf.Lerp(originalPos.y, originalPos.y + yDir, timePassed), Mathf.Lerp(originalPos.z, originalPos.z + zDir, timePassed));
                timePassed += movementSpeed * Time.deltaTime;
            }

            if (timePassed > 1.0f)
            {
                GetComponent<ObstacleActivated>().activated = false;
                active = !active;
                timePassed = 0.0f;
            }
        }
    }
}
