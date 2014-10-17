using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	public class CameraController : MonoBehaviour
	{
		public float targetAspect = 9.0f / 16.0f;

		private Camera cam;
		private float currentWindowAspect;

		void Start() 
		{
			this.cam = this.GetComponent<Camera>();
		}

		void Update()
		{
			float windowAspect = (float)Screen.width / (float)Screen.height;
			if(this.currentWindowAspect != windowAspect)
			{
				this.currentWindowAspect = windowAspect;
				float scaleHeight = windowAspect / this.targetAspect;
			
				// if scaled height is less than current height, add letterbox
				if (scaleHeight < 1.0f)
				{  
					Rect rect = cam.rect;
					
					rect.width = 1.0f;
					rect.height = scaleHeight;
					rect.x = 0;
					rect.y = (1.0f - scaleHeight) / 2.0f;
					
					cam.rect = rect;
				}
				else // add pillarbox
				{
					float scaleWidth = 1.0f / scaleHeight;
					
					Rect rect = cam.rect;
					
					rect.width = scaleWidth;
					rect.height = 1.0f;
					rect.x = (1.0f - scaleWidth) / 2.0f;
					rect.y = 0;
					
					cam.rect = rect;
				}
			}
		}
	}
}
