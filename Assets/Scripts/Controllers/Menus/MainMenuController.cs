﻿using UnityEngine;
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

			this.buttonQuit = GameObject.Find("ButtonQuit");
			this.buttonQuitController = buttonQuit.GetComponent<ButtonController>();

			CameraFade.StartAlphaFade(Color.black, true, 1f, 0f);
			AudioController.LoopMenuMusic();
		}

		void OnGUI()
		{
			// Draw a button to start the game
			if(GUI.Button(this.buttonPlayController.Button,this.buttonPlayController.title,this.buttonPlayController.style))
			{
				AudioController.PlayButtonClick();
				CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("PlayMenu"); } );
			}
			
			// Draw a button to quit the game
			if(GUI.Button(this.buttonQuitController.Button,this.buttonQuitController.title,this.buttonQuitController.style))
			{
				Application.Quit();
			}

			this.buttonQuit.gameObject.transform.position = new Vector2(buttonQuit.transform.position.x,this.buttonPlayController.GetHeigthRatio());
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
}
