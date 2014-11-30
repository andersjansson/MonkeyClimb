using UnityEngine;
using System;
using System.Collections;

namespace Controllers.Main
{
	public class GameOverController : MonoBehaviour
	{
		private ScoreController score;

		public int guiDepth = 1000;
		public Color colorOverlay;
		public GameObject[] menuObjects;
		
		private Texture2D textureOverlay;
		private GUIStyle styleOverlay;
	
		private bool displayingGameOver;
		public static bool ShowGameOver{get;set;}

		private LabelController scoreValue; 
		private LabelController bestValue; 
		private LabelController bestValueOnly; 

		void Start ()
		{
			PlayerPrefs.DeleteAll ();

			var player = GameObject.FindGameObjectWithTag ("Player");
			this.score = player.GetComponent<ScoreController>();

			this.displayingGameOver = false;
			GameOverController.ShowGameOver = false;

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
							case "ButtonMenu":
								buttonController.OnClick = this.PauseMenu;
								break;
						}
					}
				}
				else if(item.name == "Scores")
				{
					foreach (Transform scoreItem in item.transform)
					{
						if(scoreItem.gameObject.name == "ScoreValue")
						{
							this.scoreValue = scoreItem.gameObject.GetComponent<LabelController>();
						}
						else if(scoreItem.gameObject.name == "BestValue")
						{
							this.bestValue = scoreItem.gameObject.GetComponent<LabelController>();
						}
					}
				}
				else if(item.gameObject.name == "BestValueOnly")
				{
					this.bestValueOnly = item.GetComponent<LabelController>();
				}
				
				item.SetActive(false);
			}
		}

		void OnGUI()
		{
			float cameraX = (float)Screen.width/2f - Camera.main.pixelWidth/2f;
			float cameraY = (float)Screen.height/2f - Camera.main.pixelHeight/2f;
			
			GUI.depth = this.guiDepth;
			GUI.Label(new Rect(cameraX, cameraY, Camera.main.pixelWidth, Camera.main.pixelHeight), this.textureOverlay, this.styleOverlay);
		}

		void Update()
		{
			if(GameOverController.ShowGameOver && !this.displayingGameOver)
			{
				GameController.Pause = true;
				GameController.GameOver = true;
				this.score.labelObject.SetActive(false);
				this.displayingGameOver = true;

				bool newHighScore = false;
				float bestScore = PlayerPrefs.GetFloat("bestScore");
				if(bestScore == 0f || bestScore < this.score.Points)
				{
					AudioController.Play("FXSound",6);
					bestScore = this.score.Points;
					newHighScore = true;
					PlayerPrefs.SetFloat("bestScore",bestScore);
				}

				foreach (GameObject item in this.menuObjects)
				{
					if(newHighScore && item.name == "Scores") continue;
					if(!newHighScore && (item.name == "BestTextOnly" || item.name == "BestValueOnly")) continue;

					item.SetActive(true);
				}




				this.scoreValue.title = String.Format("{0} Meters",(int) this.score.Points);
				this.bestValue.title = String.Format("{0} Meters",(int) bestScore);
				this.bestValueOnly.title = String.Format("{0} Meters",(int) bestScore);
			}
		}

		private void PauseMenu()
		{
			foreach (GameObject item in this.menuObjects)
			{
				item.SetActive(false);
			}

			GameOverController.ShowGameOver = false;
		}
	}
}
