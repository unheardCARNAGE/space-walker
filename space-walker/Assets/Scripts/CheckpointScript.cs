﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {
    //public bool active = true;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.name == "Player")
		{
			Debug.Log("Hit!");
			PlayerScript.saveLocation = transform.position;
		}
	}
}
