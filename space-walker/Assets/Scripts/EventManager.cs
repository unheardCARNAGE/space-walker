using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void loadNext() {
        SceneManager.LoadScene("TimothyHarvey");
  }


  public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

  public void quitGame() {
    Application.Quit();
  }
}
