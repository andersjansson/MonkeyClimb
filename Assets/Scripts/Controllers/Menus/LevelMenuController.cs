using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class LevelMenuController : MonoBehaviour {

		private GameObject buttonJungle;
		private GameObject buttonBack;

		private ButtonController buttonJungleController;
		private ButtonController buttonBackController;

		void Start(){
			this.buttonJungle 	= GameObject.Find("ButtonJungle");
			this.buttonBack 	= GameObject.Find("ButtonBack");

			this.buttonJungleController = buttonJungle.GetComponent<ButtonController>();
			this.buttonBackController 	= buttonBack.GetComponent<ButtonController>();
		}

		void OnGUI() {

			// Draw a button to start the game
			if(GUI.Button(buttonJungleController.Button,buttonJungleController.title,buttonJungleController.style))
			{
				Application.LoadLevel("Jungle");
			}
			// Draw a button to go back
			if(GUI.Button(buttonBackController.Button,buttonBackController.title,buttonBackController.style))
			{
				Application.LoadLevel("PlayMenu");
			}
		}
		
		// Update is called once per frame
		void Update () {

			//Android back-button
			if (Input.GetKey (KeyCode.Escape))
			{
				Application.LoadLevel("PlayMenu");
			}

		}
	}
}
