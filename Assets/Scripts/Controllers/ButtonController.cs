using UnityEngine;
using System.Collections;
using Utilities;
using Extensions;

namespace Controllers
{
	public class ButtonController : MonoBehaviour {

		public string title = "Title";
		public float fontSizeRatio = 0.1f;

		public GUIStyle style;

		public Vector2 textOffsetRatio = new Vector2(0f,0f);

		public Rect Button {get;set;}

		void OnGUI()
		{
			ScaledTextureSize scaled = style.normal.background.GetScaleSize(this.transform.localScale);

			//float screenW = (float)(Screen.width - Camera.main.pixelWidth);

			float x = this.transform.position.x * ((float)(Screen.width)  - scaled.Width);
			float y = this.transform.position.y * ((float)(Screen.height) - scaled.Height);
		
			Button = new Rect(x,y,scaled.Width,scaled.Height);

			float finalSize = Mathf.Min(scaled.Width,scaled.Height) * this.fontSizeRatio;
			style.fontSize = (int)finalSize;

			style.contentOffset = new Vector2 (
				scaled.Width * this.textOffsetRatio.x,
				scaled.Height * this.textOffsetRatio.y);
		}
	}
}