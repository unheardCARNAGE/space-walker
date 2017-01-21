using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardButton : MonoBehaviour {
    public GameObject obstacle;

    public float xDir;
    public float yDir;
    public float zDir;

    public bool pressed;

    public float time;
    public float t;

    private Vector3 originalPos;

    private bool activated = false;

	// Use this for initialization
	void Start () {
        originalPos = obstacle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed)
        {
            if (activated)
            {
                 
            } else
            {
                obstacle.transform.position = new Vector3(Mathf.Lerp(originalPos.x, xDir, t), Mathf.Lerp(originalPos.y, yDir, t), Mathf.Lerp(originalPos.z, zDir, t));
                t += 0.5f * Time.deltaTime;
                if (t >= time)
                {
                    pressed = false;
                    activated = true;
                    t = 0f;
                }
            }
        }
	}

    void OnMouseDown()
    {
        pressed = true;
    }
}
