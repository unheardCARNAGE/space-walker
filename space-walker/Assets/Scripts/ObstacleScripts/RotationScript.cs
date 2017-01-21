using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {
    public float yRot = 90f;
    public float smooth = 3f;
    public bool pressed = false;
    public float timePassed = 0f;

    public Quaternion originalRot;

    void Start()
    {
        originalRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            timePassed += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(originalRot, Quaternion.Euler(0, originalRot.eulerAngles.y + yRot, 0), timePassed);

            Debug.Log(transform.rotation.eulerAngles.y);

            if (timePassed >= 1f)
            {
                originalRot = transform.rotation;
                timePassed = 0f;
                pressed = false;
            }
        }
    }
}
