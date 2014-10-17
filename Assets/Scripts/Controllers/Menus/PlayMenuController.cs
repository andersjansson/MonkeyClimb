using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class PlayMenuController : MonoBehaviour
	{
		private GameObject buttonSingleplayer;
		private GameObject buttonBack;
		
		private ButtonController buttonSingleplayerController;
		private ButtonController buttonBackController;

		void Start ()
		{
			this.buttonSingleplayer = GameObject.Find("ButtonSingleplayer");
			this.buttonSingleplayerController = buttonSingleplayer.GetComponent<ButtonController>();
			
			this.buttonBack = GameObject.Find("ButtonBack");
			this.buttonBackController = buttonBack.GetComponent<ButtonController>();
		}
		
		void OnGUI()
		{
			// Draw a button to start the game
			if(GUI.Button(buttonSingleplayerController.Button,buttonSingleplayerController.title,buttonSingleplayerController.style))
			{
				Application.LoadLevel("LevelMenu");
			}
			
			// Draw a button to quit the game
			if(GUI.Button(buttonBackController.Button,buttonBackController.title,buttonBackController.style))
			{
				Application.LoadLevel("MainMenu");
			}
		}

		void Update()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}
}
