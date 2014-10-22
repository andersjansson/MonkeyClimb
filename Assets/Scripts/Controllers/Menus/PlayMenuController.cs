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

			CameraFade.StartAlphaFade(Color.black, true, 0.5f, 0f);
		}

		void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
			{
				this.GoBack();
			}
		}

		private void LevelMenuSinglePlayer()
		{
			AudioController.Play("ButtonSound",1);
			GameController.LoadLevel("LevelMenu");
		}

		private void MainMenu()
		{
			AudioController.Play("ButtonSound",1);
			this.GoBack();
		}

		private void GoBack()
		{
			GameController.LoadLevel("MainMenu");
		}
	}
}
