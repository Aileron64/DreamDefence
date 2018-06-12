using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
	
	public string buttonStr;
	RuntimePlatform platform;
	MenuManager menuManager;

	// Use this for initialization
	void Start(){
		platform = Application.platform;
		menuManager = GameObject.Find("MainMenuController").GetComponent<MenuManager>();
	}

	// Update is called once per frame
	void Update(){
		if (platform == RuntimePlatform.Android){
			if (Input.touchCount > 0){
				switch (Input.GetTouch(0).phase){
					case TouchPhase.Began:
						if(guiTexture.HitTest(Input.touches[0].position)){
							if (guiTexture.enabled)ButtonHeld();
						}
						break;
					case TouchPhase.Ended:
						if(guiTexture.HitTest(Input.touches[0].position)){
							if (guiTexture.enabled)ButtonReleased();
						}
						break;
				}
			}
		}
	}

	void OnMouseEnter(){
		if (platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor){
			ButtonHeld();	
		}
	}

	void OnMouseUp(){
		if (platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor){
			ButtonReleased();
		}
	}

	void OnMouseExit(){
		if (platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsEditor){
			guiTexture.color = Color.grey;
		}
	}

	void ButtonHeld(){
		guiTexture.color = Color.green;
	}

	void ButtonReleased(){
		guiTexture.color = Color.grey;
		//HANDLING BUTTON NAME AND TAKING PLAYER TO APPROPRIATE PLACE
		menuManager.GoToDestination(buttonStr);
	}
}