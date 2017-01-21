using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

    public float movementSpeed;
    public float xdir;
    public float ydir;
    public float zdir;
    //public float deltaTime;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
    transform.Translate(new Vector3 (xdir, ydir, zdir) * movementSpeed * Time.deltaTime);
		
	}
}
