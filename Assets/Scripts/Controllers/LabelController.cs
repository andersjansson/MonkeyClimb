using UnityEngine;
using System.Collections;
using Utilities;
using Extensions;
using Models;

namespace Controllers
{
	public class LabelController : MonoBehaviour
	{
		public string title = "Title";
		public float fontSizeRatio = 0.1f;
		public Vector2 textOffsetRatio = new Vector2(0f,0f);
		public GUIStyle style;

		public float overrideWidth = 0f;
		public float overrideHeight = 0f;

		private RectSize scaledSize = new RectSize(0f,0f);
		private Vector2 pos = new Vector2(0f,0f);

		void OnGUI()
		{
			this.scaledSize = style.normal.background.GetScaleSize(this.transform.localScale);
			if(this.overrideWidth > 0f || this.overrideHeight > 0f)
			{
				this.scaledSize = GUIScale.RectScaleSize(this.overrideWidth,this.overrideHeight,this.transform.localScale);
			}

			float screenW = (float)(Screen.width)/2f - Camera.main.pixelWidth/2;
			float screenH = (float)(Screen.height)/2f - Camera.main.pixelHeight/2;
			
			this.pos = new Vector2
				(
					screenW + this.transform.position.x * (Camera.main.pixelWidth - this.scaledSize.Width),
					screenH + this.transform.position.y * (Camera.main.pixelHeight - this.scaledSize.Height)
					);
			
			var area = new Rect(this.pos.x,this.pos.y,scaledSize.Width,scaledSize.Height);
			
			float finalSize = Mathf.Min(scaledSize.Width,scaledSize.Height) * this.fontSizeRatio;
			this.style.fontSize = (int)finalSize;
			
			this.style.contentOffset = new Vector2 (
				scaledSize.Width * this.textOffsetRatio.x,
				scaledSize.Height * this.textOffsetRatio.y);

			GUI.Label(area, this.title, this.style);
		}
	}
}