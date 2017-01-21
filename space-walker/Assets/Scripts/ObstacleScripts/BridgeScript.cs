using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour {
    public float yDir;
    public float movementSpeed;

    private float timePassed;
    private Vector3 originalPos;

    public bool open;

    // Use this for initialization
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ObstacleActivated>().active)
        {
            if (open)
            {
                transform.position = new Vector3(originalPos.x, Mathf.Lerp(yDir, originalPos.y, timePassed), originalPos.y);
                timePassed += movementSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(originalPos.x, Mathf.Lerp(originalPos.y, yDir, timePassed), originalPos.y);
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
