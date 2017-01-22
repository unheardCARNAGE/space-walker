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

    private bool pause;
    public Rect windowRect = new Rect(20, 20, 120, 50);

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
    void Update()
    {
        

        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (move.x == 1f || move.x == -1f || move.z == 1f || move.z == -1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
        }

        transform.Translate(move * movementSpeed * Time.deltaTime, Space.World);
    }

    public void CreateRay()
    {
        Ray ray = new Ray(transform.position, -wave.transform.forward);

        RaycastHit hit;

        Debug.DrawRay(transform.position, -wave.transform.forward * maxRayDistance, Color.red);

        if (!Physics.Raycast(ray, out hit, maxRayDistance, LayerMask.GetMask("Obstacle")))
        {
            // play death animation
            SceneManager.LoadScene(loadScene);
        }
    }

    void OnGUI()
    {
        if (pause)
        {
            GUI.Window(0, windowRect, TheMainMenu, "The Pause Menu");
        }
    }

    void TheMainMenu(int windowID)
    {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
            print("Got a click");
    }
}
