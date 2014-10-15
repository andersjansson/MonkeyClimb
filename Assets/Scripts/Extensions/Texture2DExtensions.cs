using UnityEngine;
using System.Collections;

namespace Extensions
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

	public static class Texture2DExtensions
	{
		public static ScaledTextureSize Scale(this Texture2D texture, Vector2 scaleRatio)
		{
			float textureHeight 	= (float)texture.height;
			float textureWidth 		= (float)texture.width;
			
			float screenHeight 		= (float) Screen.height;
			float screenWidth 		= (float) Screen.width;
			
			float screenAspectRatio = (screenWidth / screenHeight);
			float textureAspectRatio = (textureWidth / textureHeight);
			
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
