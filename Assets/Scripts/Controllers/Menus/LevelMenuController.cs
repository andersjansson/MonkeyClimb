using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class LevelMenuController : MonoBehaviour {
		
		public Texture btnTexture;
		
		void OnGUI() {
			float buttonWidth = Screen.width;
			float buttonHeight = (Screen.height/3);
			
			Rect levelButton = new Rect(0,0,buttonWidth,buttonHeight);
			
			// Draw a button to start the game
			if(GUI.Button(levelButton,"Jungle Level"))
			{
				Debug.Log("Clicked the button with an image");
				//Application.LoadLevel("SinglePlayer");
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
