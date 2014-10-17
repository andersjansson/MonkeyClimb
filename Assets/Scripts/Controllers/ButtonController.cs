using UnityEngine;
using System.Collections;
using Utilities;
using Extensions;
using Models;

namespace Controllers
{
	public class ButtonController : MonoBehaviour
	{
		public string title = "Title";
		public float fontSizeRatio = 0.1f;
		public Vector2 textOffsetRatio = new Vector2(0f,0f);

		public GUIStyle style;

		public Rect Button {get;set;}

		private RectSize scaledSize = new RectSize(0f,0f);
		private Vector2 pos = new Vector2(0f,0f);

		void OnGUI()
		{
			this.scaledSize = style.normal.background.GetScaleSize(this.transform.localScale);

			float screenW = (float)(Screen.width)/2f - Camera.main.pixelWidth/2;
			float screenH = (float)(Screen.height)/2f - Camera.main.pixelHeight/2;

			this.pos = new Vector2
			(
				screenW + this.transform.position.x * (Camera.main.pixelWidth - this.scaledSize.Width),
				screenH + this.transform.position.y * (Camera.main.pixelHeight - this.scaledSize.Height)
			);

			this.Button = new Rect(this.pos.x,this.pos.y,scaledSize.Width,scaledSize.Height);

			float finalSize = Mathf.Min(scaledSize.Width,scaledSize.Height) * this.fontSizeRatio;
			this.style.fontSize = (int)finalSize;

			this.style.contentOffset = new Vector2 (
				scaledSize.Width * this.textOffsetRatio.x,
				scaledSize.Height * this.textOffsetRatio.y);
		}

		public float GetWidthRatio()
		{
			float ratio = (this.scaledSize.Width * 1.5f + this.pos.x) / (Camera.main.pixelWidth);
			return ratio;
		}

		public float GetHeigthRatio()
		{
			float ratio = (this.scaledSize.Height * 1.5f + this.pos.y) / Camera.main.pixelHeight;
			return ratio;
		}
	}
}