using UnityEngine;
using System.Collections;
using Utilities;
using Controllers.Main;

namespace Controllers.Menus
{
	public class MainMenuController : MonoBehaviour {

		private GameObject buttonPlay;
		private GameObject buttonQuit;

		private ButtonController buttonPlayController;
		private ButtonController buttonQuitController;

		void Start ()
		{
			this.buttonPlay = GameObject.Find("ButtonPlay");
			this.buttonPlayController = buttonPlay.GetComponent<ButtonController>();
			buttonPlayController.OnClick = this.PlayMenu;

			this.buttonQuit = GameObject.Find("ButtonQuit");
			this.buttonQuitController = buttonQuit.GetComponent<ButtonController>();
			buttonQuitController.OnClick = Application.Quit;

			CameraFade.StartAlphaFade(Color.black, true, 1f, 0f);
			AudioController.LoopMenuMusic();
		}

		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				Application.Quit();
			}
		}

		private void PlayMenu()
		{
			AudioController.PlayButtonClick();
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("PlayMenu"); } );
		}
	}
}
