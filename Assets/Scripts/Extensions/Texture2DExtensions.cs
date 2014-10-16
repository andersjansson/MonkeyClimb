using UnityEngine;
using System.Collections;
using Utilities;

namespace Extensions
{
	public static class Texture2DExtensions
	{
		public static ScaledTextureSize GetScaleSize(this Texture2D texture, Vector2 scaleRatio)
		{
			float textureHeight 	= (float)texture.height;
			float textureWidth 		= (float)texture.width;
			
			return GUIScale.RectScaleSize(textureWidth, textureHeight, scaleRatio);
		}

		public static ScaledTextureSize GetScaleSize(this Texture texture, Vector2 scaleRatio)
		{
			float textureHeight 	= (float)texture.height;
			float textureWidth 		= (float)texture.width;
			
			return GUIScale.RectScaleSize(textureWidth, textureHeight, scaleRatio);
		}
	}
}
