using UnityEngine;
using System.Collections;
using Utilities;

namespace Extensions
{
	public static class Texture2DExtensions
	{
		public static ScaledTextureSize Scale(this Texture2D texture, Vector2 scaleRatio)
		{
			float textureHeight 	= (float)texture.height;
			float textureWidth 		= (float)texture.width;
			
			return GUIScale.RectScale(textureWidth, textureHeight, scaleRatio);
		}

		public static ScaledTextureSize Scale(this Texture texture, Vector2 scaleRatio)
		{
			float textureHeight 	= (float)texture.height;
			float textureWidth 		= (float)texture.width;
			
			return GUIScale.RectScale(textureWidth, textureHeight, scaleRatio);
		}
	}
}
