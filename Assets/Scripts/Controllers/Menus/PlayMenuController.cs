using UnityEngine;
using System.Collections;
using Controllers.Main;
using Utilities;

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

			CameraFade.StartAlphaFade(Color.black, true, 1f, 0f);
		}
		
		void OnGUI()
		{
			buttonBack.transform.position = new Vector2(buttonBack.transform.position.x,buttonSingleplayerController.GetHeigthRatio());

			// Draw a button to start the game
			if(GUI.Button(buttonSingleplayerController.Button,buttonSingleplayerController.title,buttonSingleplayerController.style))
			{
				AudioController.PlayButtonClick();
				CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("LevelMenu"); } );
			}
			
			// Draw a button to quit the game
			if(GUI.Button(buttonBackController.Button,buttonBackController.title,buttonBackController.style))
			{
				AudioController.PlayButtonClick();
				this.GoBack();
			}
		}

		void Update()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				this.GoBack();
			}
		}

		private void GoBack()
		{
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("MainMenu"); } );
		}
	}
}
