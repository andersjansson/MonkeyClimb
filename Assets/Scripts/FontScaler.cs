using UnityEngine;
using System.Collections;

public class FontScaler : MonoBehaviour {

	/// <summary>
	/// The pixelOffset scaled with screen size.
	/// </summary>
	public Vector2 offset;

	/// <summary>
	/// Font Size ratio in float.
	/// </summary>
	public float fontSizeRatio = 0.1f;

	//----------------------------------------------------------------------------
	
	void OnGUI()
	{
		float finalSize = Mathf.Min(Camera.main.pixelWidth, Camera.main.pixelHeight) * this.fontSizeRatio;

		guiText.fontSize = (int) finalSize;
		guiText.pixelOffset = new Vector2( this.offset.x * Camera.main.pixelWidth, this.offset.y * Camera.main.pixelHeight);
	}
}
