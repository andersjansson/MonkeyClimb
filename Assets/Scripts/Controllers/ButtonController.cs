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

		public Rect Button {get;set;}

		void OnGUI()
		{
			ScaledTextureSize scaled = style.normal.background.GetScaleSize(this.transform.localScale);

			float x = this.transform.position.x * ((float)(Screen.width)  - scaled.Width);
			float y = this.transform.position.y * ((float)(Screen.height) - scaled.Height);
		
			Button = new Rect(x,y,scaled.Width,scaled.Height);

			float finalSize = Mathf.Min(scaled.Width,scaled.Height) * this.fontSizeRatio;
			style.fontSize = (int)finalSize;
		}
	}
}