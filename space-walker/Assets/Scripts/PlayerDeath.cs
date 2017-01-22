using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public void Shatter(){
		foreach (Transform child in transform){
			Rigidbody b = child.gameObject.AddComponent<Rigidbody>();
			child.SetParent(null);
			b.AddForceAtPosition(new Vector3(0f, Random.Range(.25f, .5f), Random.Range(-1.5f, -1f)) * 500f,
				Random.onUnitSphere);
		}
	}
}
