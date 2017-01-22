using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {

	public static bool hasWon = false;

	[SerializeField] float timePerCharacter = .3f;
	[SerializeField] Text winText;

	float textTimer = 0f;
	string winString;

	public void Win(){
		hasWon = true;
		//player control is removed in the player script already

		//winText.text = ;
		//win overlay
		//roll credits
	}

	void Start(){
		winString = winText.text;
	}

	void Update(){
		if (WinScript.hasWon){
			textTimer += Time.deltaTime;
			winText.text = winString.Substring(0, textTimer / timePerCharacter);
		}
	}
}
