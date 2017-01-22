using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EventManager : MonoBehaviour {

    public GameObject menu;
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void resume()
    {
        Time.timeScale = 1f;
        player.GetComponent<PauseMenu>().isShowing = false;
        menu.SetActive(player.GetComponent<PauseMenu>().isShowing);
      
    }

  public void loadNext() {
        menu.SetActive(false);
        SceneManager.LoadScene("SpaceStation");
  }


  public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

  public void quitGame() {
    Application.Quit();
  }
}
