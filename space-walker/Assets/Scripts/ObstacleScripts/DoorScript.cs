using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    public float xDir;
    public float zDir;
    public float movementSpeed;

    private float timePassed;
    private Vector3 originalPos;

    public bool open;

    // Use this for initialization
    void Start()
    {
        originalPos = transform.position;

        if (open)
        {
            originalPos -= new Vector3(xDir, 0, zDir);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ObstacleActivated>().active)
        {
            if (open)
            {
                transform.position = new Vector3(Mathf.Lerp(originalPos.x + xDir, originalPos.x, timePassed), originalPos.y, Mathf.Lerp(originalPos.z + zDir, originalPos.z, timePassed));
                timePassed += movementSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(Mathf.Lerp(originalPos.x, originalPos.x + xDir, timePassed), originalPos.y, Mathf.Lerp(originalPos.z, originalPos.z + zDir, timePassed));
                timePassed += movementSpeed * Time.deltaTime;
            }

            if (timePassed > 1.0f)
            {
                GetComponent<ObstacleActivated>().active = false;
                open = !open;
                timePassed = 0.0f;
            }
        }
    }
}
