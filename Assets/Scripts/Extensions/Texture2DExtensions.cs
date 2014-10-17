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
			float textureHeight 	= (float)texture.height;
			float textureWidth 		= (float)texture.width;
			
			return GUIScale.RectScaleSize(textureWidth, textureHeight, scaleRatio);
		}
	}
}
