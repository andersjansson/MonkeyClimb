using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class PlayMenuController : MonoBehaviour {
		
		// Use this for initialization
		void Start () {
			
		}
		
		void OnGUI()
		{
			const int buttonWidth = 84;
			const int buttonHeight = 60;
			
			// Determine the button's place on screen
			// Center in X, 2/3 of the height in Y
			Rect buttonStart = new Rect(
				Screen.width / 2 - (buttonWidth / 2),
				(2 * Screen.height / 3) - (buttonHeight / 2),
				buttonWidth,
				buttonHeight
				);
			
			Rect buttonQuit = new Rect(
				Screen.width / 2 - (buttonWidth / 2),
				(2 * Screen.height / 3) - (buttonHeight / 2) + buttonStart.height + 5,
				buttonWidth,
				buttonHeight
				);
			
			// Draw a button to start the game
			if(GUI.Button(buttonStart,"Singleplayer"))
			{
				Application.LoadLevel("LevelMenu");
			}
			
			// Draw a button to quit the game
			if(GUI.Button(buttonQuit,"Back"))
			{
				Application.LoadLevel("MainMenu");
			}
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
