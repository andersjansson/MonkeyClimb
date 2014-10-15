using UnityEngine;
using System.Collections;

namespace Utilities
{
	public class ScaledTextureSize
	{
		public float Width {get;set;}
		public float Height {get;set;}
		
		public ScaledTextureSize(float width, float height)
		{
			this.Width 	= width;
			this.Height = height;
		}
	}

	public static class GUIScale
	{
		public static void AutoResize(int screenWidth, int screenHeight)
		{
			Vector2 resizeRatio = new Vector2((float)Screen.width / screenWidth, (float)Screen.height / screenHeight);
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
		}

		public static ScaledTextureSize RectScale(float originalWidth, float originalHeight, Vector2 scaleRatio)
		{
			float screenHeight 		= (float) Screen.height;
			float screenWidth 		= (float) Screen.width;
			
			float screenAspectRatio = (screenWidth / screenHeight);
			float textureAspectRatio = (originalWidth / originalHeight);
			
			float scaledHeight;
			float scaledWidth;
			
			if (textureAspectRatio <= screenAspectRatio)
			{
				// The scaled size is based on the height
				scaledHeight = screenHeight;
				scaledWidth = (screenHeight * textureAspectRatio);
			}
			else
			{
				// The scaled size is based on the width
				scaledWidth = screenWidth;
				scaledHeight = (scaledWidth / textureAspectRatio);
			}
			
			scaledWidth = scaledWidth * scaleRatio.x;
			scaledHeight = scaledHeight * scaleRatio.y;
			
			var scaledTexture = new ScaledTextureSize(scaledWidth,scaledHeight);
			return scaledTexture;
		}


	}
}
