using UnityEngine;
using System.Collections;

namespace Models
{
	public class RectSize
	{
		public float Width {get;set;}
		public float Height {get;set;}
		
		public RectSize(float width, float height)
		{
			this.Width 	= width;
			this.Height = height;
		}
	}
}