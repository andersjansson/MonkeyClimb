using UnityEngine;
using System.Collections;
using Utilities;
using Extensions;

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
		var scaled = GUIScale.RectScaleSize(this.orginalWidth,this.orginalHeight,this.scaleRatio);

		float x = -(scaled.Width / 2);
		float y = -(scaled.Height / 2);

		guiTexture.pixelInset = new Rect(x, y, scaled.Width, scaled.Height);
	}
}
