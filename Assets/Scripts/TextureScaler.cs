using UnityEngine;
using System.Collections;
using Utilities;
using Extensions;
using Models;

public class TextureScaler : MonoBehaviour {

	public float orginalWidth;
	public float orginalHeight;
	public Vector2 scaleRatio = new Vector2 (0.5f, 0.5f);

	void Awake()
	{
		this.transform.localScale = new Vector3(0, 0, 0);
	}

	void OnGUI()
	{
		RectSize scaledSize = GUIScale.RectScaleSize(this.orginalWidth,this.orginalHeight,this.scaleRatio);

		float x = -(scaledSize.Width / 2);
		float y = -(scaledSize.Height / 2);

		guiTexture.pixelInset = new Rect(x, y, scaledSize.Width, scaledSize.Height);
	}
}
