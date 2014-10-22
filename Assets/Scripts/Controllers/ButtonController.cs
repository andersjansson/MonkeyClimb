using UnityEngine;
using System;
using System.Collections;
using Utilities;
using Extensions;
using Models;

namespace Controllers
{
	public class ButtonController : MonoBehaviour
	{
		public GameObject linkedTo;
		public Vector2 linkedOffsetRatio = new Vector2(0f,0f);

		public int guiDepth = 1;
		public string title = "Title";
		public float fontSizeRatio = 0.1f;
		public Vector2 textOffsetRatio = new Vector2(0f,0f);
		public GUIStyle style;

		public Action OnClick{get;set;}

		private RectSize scaledSize = new RectSize(0f,0f);
		private Vector2 pos = new Vector2(0f,0f);

		private bool clicked = false;

		void OnGUI()
		{
			this.scaledSize = style.normal.background.GetScaleSize(this.transform.localScale);

			float screenW = (float)(Screen.width)/2f - Camera.main.pixelWidth/2;
			float screenH = (float)(Screen.height)/2f - Camera.main.pixelHeight/2;

			if (this.linkedTo != null && this.linkedTo.tag == "MenuButton")
			{
				var linkedController = this.linkedTo.GetComponent<ButtonController>();
				linkedController.GetHeigthRatio();

				float linkX = this.transform.position.x;
				if(this.linkedOffsetRatio.x != 0f)
					linkX = linkedController.GetWidthRatio() + this.linkedOffsetRatio.x;

				float linkY = this.transform.position.y;
				if(this.linkedOffsetRatio.y != 0f)
					linkY = linkedController.GetHeigthRatio() + this.linkedOffsetRatio.y;

				this.transform.position = new Vector3
				(
					linkX,
					linkY,
					this.transform.position.y
				);
			}

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

			GUI.depth = this.guiDepth;
			if(GUI.Button(area,this.title, this.style) && this.OnClick != null)
			{
				if(this.clicked) return;

				this.clicked = true;
				this.OnClick();
			}
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