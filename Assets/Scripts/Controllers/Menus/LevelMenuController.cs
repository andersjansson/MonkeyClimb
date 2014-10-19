﻿using UnityEngine;
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

			CameraFade.StartAlphaFade(Color.black, true, 1f, 0f);
		}

		void OnGUI(){}

		void Update()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				this.GoBack();
			}
		}

		private void JungleLevelSinglePlayer()
		{
			AudioController.PlayButtonClick();
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("Jungle"); } );
		}

		private void PlayMenu()
		{
			AudioController.PlayButtonClick();
			this.GoBack();
		}

		private void GoBack()
		{
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("PlayMenu"); } );
		}
	}
}
