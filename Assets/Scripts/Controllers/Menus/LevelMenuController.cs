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
			this.buttonBackController 	= buttonBack.GetComponent<ButtonController>();

			CameraFade.StartAlphaFade(Color.black, true, 1f, 0f);
		}

		void OnGUI() {

			// Draw a button to start the game
			if(GUI.Button(buttonJungleController.Button,buttonJungleController.title,buttonJungleController.style))
			{
				CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("Jungle"); } );
			}

			// Draw a button to go back
			if(GUI.Button(buttonBackController.Button,buttonBackController.title,buttonBackController.style))
			{
				AudioController.PlayButtonClick();
				this.GoBack();
			}
		}

		void Update ()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				this.GoBack();
			}

		}

		private void GoBack()
		{
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("PlayMenu"); } );
		}
	}
}
