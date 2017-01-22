using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {

	public static bool hasWon = false;

	[SerializeField] TransformButton lastButton;
	[SerializeField] float timePerCharacter = .1f;
	[SerializeField] Text winText;
	[SerializeField] float timeAfterCredits = 4f;
	[SerializeField] Image blackScreen;

	bool buttonOne = false;
	bool buttonTwo = false;
	float textTimer = 0f;
	string winString;

	public void Win(){
		hasWon = true;
		//player control is removed in the player script already
	}

	void Start(){
		winString = winText.text;
		winText.text = "";
		lastButton.enabled = false;
	}

	void Update(){
		if (WinScript.hasWon){
			textTimer += Time.deltaTime;

			//update the win text
			int currentLength = Mathf.Min((int)(textTimer / timePerCharacter), winString.Length);
			winText.text = winString.Substring(0, currentLength);

			if(textTimer - currentLength > 0f){
				float alpha = 2 * (textTimer - currentLength) / timeAfterCredits;
				blackScreen.color = new Color(0,0,0,alpha);
			}
		}
	}

	public void WinButtonPressed(){
		Win();
	}

	public void ButtonOnePressed(){
		buttonOne = true;
		CheckEnableWinButton();
	}

	public void ButtonTwoPressed(){
		buttonTwo = true;
		CheckEnableWinButton();
	}

	void CheckEnableWinButton(){
		if (buttonOne && buttonTwo){
			lastButton.enabled = true;
		}
	}
}
