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
			buttonSingleplayerController.OnClick = this.LevelMenuSinglePlayer;

			
			this.buttonBack = GameObject.Find("ButtonBack");
			this.buttonBackController = buttonBack.GetComponent<ButtonController>();
			buttonBackController.OnClick = this.MainMenu;

			CameraFade.StartAlphaFade(Color.black, true, 1f, 0f);
		}

		void Update()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				this.GoBack();
			}
		}

		private void LevelMenuSinglePlayer()
		{
			AudioController.PlayButtonClick();
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("LevelMenu"); } );
		}

		private void MainMenu()
		{
			AudioController.PlayButtonClick();
			this.GoBack();
		}

		private void GoBack()
		{
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("MainMenu"); } );
		}
	}
}
