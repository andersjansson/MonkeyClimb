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
	public float fontSizeRatio = 10;

	//----------------------------------------------------------------------------
	
	void OnGUI()
	{
		float finalSize = Mathf.Min(Screen.width, Screen.height) / this.fontSizeRatio;

		guiText.fontSize = (int) finalSize;
		guiText.pixelOffset = new Vector2( this.offset.x * Screen.width, this.offset.y * Screen.height);
	}
}
