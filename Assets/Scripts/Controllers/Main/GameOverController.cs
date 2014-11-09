using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	public class GameOverController : MonoBehaviour
	{
		public int guiDepth = 1000;
		public Color colorOverlay;
		public GameObject[] menuObjects;
		
		private Texture2D textureOverlay;
		private GUIStyle styleOverlay;
	
		private bool displayingGameOver;
		public static bool ShowGameOver{get;set;}

		void Start ()
		{
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
				foreach (GameObject item in this.menuObjects)
				{
					item.SetActive(true);
				}

				this.displayingGameOver = true;
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
