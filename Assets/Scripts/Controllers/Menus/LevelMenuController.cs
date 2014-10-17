using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class LevelMenuController : MonoBehaviour {

		private GameObject buttonJungle;

		private ButtonController buttonJungleController;

		void Start(){
			this.buttonJungle = GameObject.Find("ButtonJungle");
			this.buttonJungleController = buttonJungle.GetComponent<ButtonController>();
		}

		void OnGUI() {
			float buttonWidth = Screen.width;
			float buttonHeight = (Screen.height/4);
			
			Rect levelButton = new Rect(0,100,buttonWidth,buttonHeight);
			
			// Draw a button to start the game
			if(GUI.Button(buttonJungleController.Button,buttonJungleController.title,buttonJungleController.style))
			{
				Application.LoadLevel("PlayMenu");
			}
			/*
			if (!btnTexture) {
				Debug.LogError("Please assign a texture on the inspector");
				return;
			}*/
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
