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
			buttonQuitController.OnClick = GameController.Exit;

			CameraFade.StartAlphaFade(Color.black, true, 0.5f, 0f);
			AudioController.Play("BackgroundSound",0,true);
		}

		// Update is called once per frame
		void Update ()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				GameController.Exit();
			}
		}

		private void PlayMenu()
		{
			AudioController.Play("ButtonSound",1);
			GameController.LoadLevel("PlayMenu");
		}
	}
}
