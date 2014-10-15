using UnityEngine;
using System.Collections;
using Utilities;
using Extensions;

public class TextureScaler : MonoBehaviour {

	public float orginalWidth;
	public float orginalHeight;

	void OnGUI()
	{
		var scaled = GUIScale.RectScale(orginalWidth,orginalHeight,this.transform.localScale);
		guiTexture.pixelInset = new Rect(0, 0, scaled.Width, scaled.Height);
	}
}
