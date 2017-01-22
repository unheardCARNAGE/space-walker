using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
	public Vector3 activeOffset;
	public bool relativeRotation = false;
    public float movementDuration = 3f;

    private float timePassed = 0f;
    private Vector3 originalPos;

    public bool running = false;
    public bool active;

    public AudioClip soundOnOpening = null;
    public AudioClip soundOnClosing = null;
    public AudioClip soundForWall = null;
    public AudioClip soundForFinish = null;

    AudioSource music;

    // Use this for initialization
    void Start()
    {
        music = GetComponent<AudioSource>();

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
        Debug.Log(soundForFinish);
        if (running)
        {
            if (soundForWall != null)
            {
                music.PlayOneShot(soundForWall);
            }

            timePassed += Time.deltaTime;
            if (active)
            {
				transform.position = Vector3.Lerp(originalPos + activeOffset, originalPos, timePassed / movementDuration);
                if (soundOnOpening != null)
                {
                    music.PlayOneShot(soundOnOpening);
                }
            }
            else
            {
				transform.position = Vector3.Lerp(originalPos, originalPos + activeOffset, timePassed / movementDuration);
                if (soundOnClosing != null)
                {
                    music.PlayOneShot(soundOnClosing);
                }
            }

            if (timePassed > movementDuration)
            {
                if (soundForFinish != null)
                {
                    music.Stop();
                    music.PlayOneShot(soundForFinish);
                }
                running = false;
                active = !active;
                timePassed = 0f;
            }
        }
    }
}
