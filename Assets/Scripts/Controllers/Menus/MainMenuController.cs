using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class MainMenuController : MonoBehaviour {

		private GameObject buttonPlay;
		private ButtonController buttonPlayController;

		// Use this for initialization
		void Start () {
		
			this.buttonPlay = GameObject.Find("ButtonPlay");
			this.buttonPlayController = buttonPlay.GetComponent<ButtonController>();
		}

		void OnGUI()
		{

			
			// Draw a button to start the game
			if(GUI.Button(buttonPlayController.Button,buttonPlayController.title,buttonPlayController.style))
			{
				Application.LoadLevel("PlayMenu");
			}
			
			// Draw a button to quit the game
			//if(GUI.Button(buttonQuit,"Quit"))
			//{
			//	Application.Quit();
			//}
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
