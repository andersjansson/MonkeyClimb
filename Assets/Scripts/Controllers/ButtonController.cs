using UnityEngine;
using System.Collections;

namespace Controllers
{
	public class ButtonController : MonoBehaviour {

		public string title = "Title";
		public int imageWidth 	= 128;
		public int imageHeight 	= 64;
		public float fontSizeRatio = 10;

		public GUIStyle style;

		public Rect Button {get;set;}

		// Use this for initialization
		void Start () {
		
		}
		
		void OnGUI()
		{
			float width = this.imageWidth;
			float height = this.imageHeight;

			int textureHeight = style.normal.background.height;
			int textureWidth = style.normal.background.width;

			int screenHeight = Screen.height;
			int screenWidth = Screen.width;
			
			int screenAspectRatio = (screenWidth / screenHeight);
			int textureAspectRatio = (textureWidth / textureHeight);
			
			int scaledHeight;
			int scaledWidth;
			if (textureAspectRatio <= screenAspectRatio)
			{
				// The scaled size is based on the height
				scaledHeight = screenHeight;
				scaledWidth = (screenHeight * textureAspectRatio);
			}
			else
			{
				// The scaled size is based on the width
				scaledWidth = screenWidth;
				scaledHeight = (scaledWidth / textureAspectRatio);
			}
	

			float x = this.transform.position.x * ((float)(Screen.width)  - scaledWidth);
			float y = this.transform.position.y * ((float)(Screen.height) - scaledHeight);

		
			Button = new Rect(x,y,scaledWidth,scaledHeight);


			float finalSize = Mathf.Min(width,height) / this.fontSizeRatio;
			style.fontSize = (int)finalSize;
		}
	}
}