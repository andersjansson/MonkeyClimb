using UnityEngine;
using System.Collections;

namespace Controllers
{
	public class PauseController : MonoBehaviour
	{
		public int guiDepth = 1000;
		public Color colorOverlay;

		private Texture2D textureOverlay;
		private GUIStyle styleOverlay;
		private bool paused;

		private GameObject labelObject;
		private LabelController labelController;

		void Start ()
		{
			this.textureOverlay = new Texture2D (1, 1);
			this.textureOverlay.SetPixel(0, 0, this.colorOverlay);
			this.textureOverlay.Apply();

			this.styleOverlay = new GUIStyle();
			this.styleOverlay.normal.background = this.textureOverlay;

			this.labelObject = GameObject.Find("GUI/PauseMenu/Label");
			this.labelController = this.labelObject.GetComponent<LabelController>();
			labelController.enabled = false;
		}

		void Update()
		{
			bool pauseButton = false;
			pauseButton |= Input.GetButtonDown("Exit");
			if(pauseButton)
			{
				this.labelController.enabled = false;
				this.paused = !paused;
				if(this.paused)
				{
					this.labelController.enabled = true;
				}
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
	}
}
