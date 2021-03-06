﻿using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	public class PauseController : MonoBehaviour
	{
		public int guiDepth = 1000;
		public Color colorOverlay;

		private Texture2D textureOverlay;
		private GUIStyle styleOverlay;
		private bool paused;

		public GameObject[] menuObjects;

		void Start ()
		{
			this.textureOverlay = new Texture2D (1, 1);
			this.textureOverlay.SetPixel(0, 0, this.colorOverlay);
			this.textureOverlay.Apply();

			this.styleOverlay = new GUIStyle();
			this.styleOverlay.normal.background = this.textureOverlay;

			foreach (GameObject item in this.menuObjects)
			{
				if(item.tag == "MenuButton")
				{
					var buttonController = item.GetComponent<ButtonController>();
					if(buttonController != null)
					{
						switch(item.name)
						{
							case "ButtonRestart":
								buttonController.OnClick = this.Restart;
								break;
							case "ButtonMainMenu":
								buttonController.OnClick = this.MainMenu;
								break;
							case "ButtonQuit":
								buttonController.OnClick = GameController.Exit;
								break;
						}
					}
				}

				item.SetActive(false);
			}
		}

		void Update()
		{
			if(GameOverController.ShowGameOver)
			{
				this.paused = false;
				return;
			}

			if(GameController.GameOver && !GameOverController.ShowGameOver)
			{
				if(!this.paused)
				{
					this.paused = true;
					this.Pause();
				}

				return;
			}

			bool pauseButton = false;
			pauseButton |= Input.GetButtonDown("Pause");
			pauseButton |= Input.GetButtonDown("Exit");
			pauseButton |= Input.GetKeyDown(KeyCode.Escape);
			pauseButton |= Input.GetKeyDown(KeyCode.Menu);

			if(pauseButton)
			{
				this.paused = !paused;
				this.Pause();
			}
		}

		void OnGUI()
		{
			if(this.paused)
			{
				float cameraX = (float)Screen.width/2f - Camera.main.pixelWidth/2f;
				float cameraY = (float)Screen.height/2f - Camera.main.pixelHeight/2f;

				GUI.depth = this.guiDepth;
				GUI.Label(new Rect(cameraX, cameraY, Camera.main.pixelWidth, Camera.main.pixelHeight), this.textureOverlay, this.styleOverlay);
			}
		}

		private void Pause()
		{
			foreach (GameObject item in this.menuObjects)
			{
				item.SetActive(false);
				if(this.paused)
				{
					item.SetActive(true);
				}
			}
			
			Time.timeScale = 1;
			AudioController.PlayIfPaused("BackgroundSound");
			GameController.Pause = false;
			if(this.paused)
			{
				AudioController.Pause("BackgroundSound");
				GameController.Pause = true;
				Time.timeScale = 0;
			}
		}

		private void MainMenu()
		{
			Time.timeScale = 1;
			AudioController.Stop("BackgroundSound");
			GameController.LoadLevel("MainMenu");
		}

		private void Restart()
		{
			Time.timeScale = 1;
			AudioController.Stop("BackgroundSound");
			GameController.LoadLevel (Application.loadedLevel);
		}
	}
}
