using UnityEngine;
using System.Collections;

public enum MenuState { Title, Options, Credits }

public class MenuManager : MonoBehaviour {
	
	readonly string[] menuButtonNameArr = {"PlayButton", "OptionsButton", "BackButton", "MuteButton"};
	GUITexture[] mainMenuButtons;
	GUIText[] mainMenuTexts;

	void Awake(){
		mainMenuButtons = new GUITexture[menuButtonNameArr.Length];
		mainMenuTexts = new GUIText[menuButtonNameArr.Length];
	}

	// Use this for initialization
	void Start(){
		for (int i = 0; i < menuButtonNameArr.Length; i++){
			mainMenuButtons[i] = GameObject.Find(menuButtonNameArr[i]).guiTexture;
			mainMenuTexts[i] = GameObject.Find(menuButtonNameArr[i]).transform.Find("Text").guiText;
		}
		SwitchMenuState(MenuState.Title);
	}

	// Update is called once per frame
	void Update(){
		
	}

	protected internal void GoToDestination(string _buttonStr){
		switch (_buttonStr){
			case "play_game":
				Application.LoadLevel(1);
				break;
			case "options": //Options
				SwitchMenuState(MenuState.Options);
				break;
			case "back": //Back
				SwitchMenuState(MenuState.Title);
				break;
		}
	}

	void SwitchMenuState(MenuState _newMenuState){
		mainMenuButtons[0].enabled = (_newMenuState == MenuState.Title);
		mainMenuTexts[0].enabled = (_newMenuState == MenuState.Title);
		mainMenuButtons[1].enabled = (_newMenuState == MenuState.Title);
		mainMenuTexts[1].enabled = (_newMenuState == MenuState.Title);
		mainMenuButtons[2].enabled = (_newMenuState == MenuState.Options);
		mainMenuTexts[2].enabled = (_newMenuState == MenuState.Options);
		mainMenuButtons[3].enabled = (_newMenuState == MenuState.Options);
		mainMenuTexts[3].enabled = (_newMenuState == MenuState.Options);
	}
}