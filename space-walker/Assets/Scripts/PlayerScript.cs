using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    public string loadScene;

    public List<string> receivedKeys;

    public float movementSpeed = 50f;
    public float maxRayDistance = 100.0f;

    private Vector3 move;

    public Transform wave;

	public static bool hasSaveStart = false;
    public static Vector3 saveLocation;

	bool isDead = false;
	float respawnTimer = 0f;
	public float deathTime = 4f;
	public GameObject corpse;

	/*
    private bool pause;
    public Rect windowRect = new Rect(20, 20, 120, 50);
    */

    void Start()
    {
		Debug.Log("Start Called with: " + hasSaveStart);
		if (!hasSaveStart){
			saveLocation = transform.position;
			hasSaveStart = true;
		} else{
			transform.position = saveLocation;
		}
    }

    // Update is called once per frame
    void Update(){
        if (!isDead) {
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (move.x == 1f || move.x == -1f || move.z == 1f || move.z == -1f) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
            }

            transform.Translate(move * movementSpeed * Time.deltaTime, Space.World);
        } else if (WinScript.hasWon) {
            // turn winCondition true with last button
            // create win screen
        } else if (respawnTimer < deathTime) {
            respawnTimer += Time.deltaTime;
        } else {
            Respawn();
        }
    }

    public void CreateRay()
	{
        Ray ray = new Ray(transform.position, -wave.transform.forward);

        RaycastHit hit;

        Debug.DrawRay(transform.position, -wave.transform.forward * maxRayDistance, Color.red);

        if (!Physics.Raycast(ray, out hit, maxRayDistance, LayerMask.GetMask("Obstacle")) && !isDead)
        {
            // play death animation
			OnDeath();
        }
    }

	void OnDeath(){
		isDead = true;
		GetComponent<Collider>().enabled = false;
		GetComponent<Rigidbody>().useGravity = false;
		SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer mr in renderers){
			Debug.Log("Hiding Part");
			mr.enabled = false;
		}
		GameObject o = GameObject.Instantiate<GameObject>(corpse);
		o.transform.position = transform.position;
		o.transform.rotation = transform.rotation;

		Rigidbody[] parts = o.GetComponentsInChildren<Rigidbody>();
		foreach(Rigidbody part in parts){
			part.AddForceAtPosition(new Vector3(0f, Random.Range(.25f, .5f), Random.Range(-1.5f, -1f)) * 500f,
				Random.onUnitSphere);

		}
	}

	void Respawn(){
		SceneManager.LoadScene(loadScene);
	}
}
