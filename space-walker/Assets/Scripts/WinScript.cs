using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {

	public static bool hasWon = false;

	[SerializeField] TransformButton lastButton;
	[SerializeField] float timePerCharacter = .3f;
	[SerializeField] Text winText;

	bool buttonOne = false;
	bool buttonTwo = false;
	float textTimer = 0f;
	string winString;

	public void Win(){
		hasWon = true;
		//player control is removed in the player script already

		//win overlay
		//roll credits
	}

	void Start(){
		winString = winText.text;
		winText.text = "";
	}

	void Update(){
		if (WinScript.hasWon){
			textTimer += Time.deltaTime;

			//update the win text
			int currentLength = Mathf.Min((int)(textTimer / timePerCharacter), winString.Length);
			winText.text = winString.Substring(0, currentLength);
		}
	}

	public void WinButtonPressed(){
		Win();
	}

	public void ButtonOnePressed(){
		buttonOne = true;
	}

	public void ButtonTwoPressed(){
		buttonTwo = true;
	}
}
