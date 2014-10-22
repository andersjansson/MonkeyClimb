using UnityEngine;
using System.Collections;
using Utilities;
using Controllers.Main;

namespace Controllers.Menus
{
	public class LevelMenuController : MonoBehaviour
	{
		private GameObject buttonJungle;
		private GameObject buttonBack;

		private ButtonController buttonJungleController;
		private ButtonController buttonBackController;

		void Start()
		{
			this.buttonJungle 	= GameObject.Find("ButtonJungle");
			this.buttonBack 	= GameObject.Find("ButtonBack");

			this.buttonJungleController = buttonJungle.GetComponent<ButtonController>();
			this.buttonJungleController.OnClick = this.JungleLevelSinglePlayer;

			this.buttonBackController 	= buttonBack.GetComponent<ButtonController>();
			this.buttonBackController.OnClick = this.PlayMenu;

			CameraFade.StartAlphaFade(Color.black, true, 0.5f, 0f);
		}

		void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				this.GoBack();
			}
			else if(Input.GetKeyDown(KeyCode.Menu))
			{
				GameController.LoadLevel("MainMenu");
			}
		}

		private void SelectLevel()
		{
			AudioController.Stop("BackgroundSound");
			AudioController.Play("ButtonSound",1);
		}

		private void JungleLevelSinglePlayer()
		{
			this.SelectLevel();
			GameController.LoadLevel("Jungle");
		}

		private void PlayMenu()
		{
			AudioController.Play("ButtonSound",1);
			this.GoBack();
		}

		private void GoBack()
		{
			GameController.LoadLevel("PlayMenu");
		}
	}
}
