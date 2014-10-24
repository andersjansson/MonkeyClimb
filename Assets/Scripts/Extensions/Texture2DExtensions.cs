using UnityEngine;
using System.Collections;
using Utilities;
using Models;

namespace Extensions
{
	public static class Texture2DExtensions
	{
		public static RectSize GetScaleSize(this Texture2D texture, Vector2 scaleRatio)
		{
			float textureHeight 	= 0f;
			float textureWidth 		= 0f;
			if(texture != null)
			{
				textureHeight 	= (float)texture.height;
				textureWidth 	= (float)texture.width;
			}
			
			return GUIScale.RectScaleSize(textureWidth, textureHeight, scaleRatio);
		}
	}
}
