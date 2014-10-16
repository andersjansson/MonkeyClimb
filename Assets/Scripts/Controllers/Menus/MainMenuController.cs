using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class MainMenuController : MonoBehaviour {

		private GameObject buttonPlay;
		private GameObject buttonQuit;

		private ButtonController buttonPlayController;
		private ButtonController buttonQuitController;

		// Use this for initialization
		void Start () {
		
			this.buttonPlay = GameObject.Find("ButtonPlay");
			this.buttonPlayController = buttonPlay.GetComponent<ButtonController>();

			this.buttonQuit = GameObject.Find("ButtonQuit");
			this.buttonQuitController = buttonQuit.GetComponent<ButtonController>();
		}

		void OnGUI()
		{

			
			// Draw a button to start the game
			if(GUI.Button(buttonPlayController.Button,buttonPlayController.title,buttonPlayController.style))
			{
				Application.LoadLevel("PlayMenu");
			}
			
			// Draw a button to quit the game
			if(GUI.Button(buttonQuitController.Button,buttonQuitController.title,buttonQuitController.style))
			{
				Application.Quit();
			}
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
}
