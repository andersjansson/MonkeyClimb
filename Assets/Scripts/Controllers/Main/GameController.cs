using UnityEngine;
using System.Collections;
using Utilities;

namespace Controllers.Main
{	
	public class GameController : MonoBehaviour
	{
		public static float speedScale = 1.0f;

		public static Collider2D LevelCollider {get;private set;}
		public static bool Pause{get;set;}
		public static bool GameOver{get;set;}

		public const int LEVEL_LEFT 	= 0;
		public const int LEVEL_CENTER 	= 1;
		public const int LEVEL_RIGHT 	= 2;
		public const int LEVEL_TOP 		= 3;
		public const int LEVEL_MIDDLE 	= 4;
		public const int LEVEL_BOTTOM 	= 5;

		void Start ()
		{
			GameController.Pause = false;
			GameController.GameOver = false;

			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}

		public static void SetLevelCollider(string path)
		{
			var levelObject = GameObject.Find (path);
			if (levelObject.collider2D == null)
			{
				throw new MissingComponentException("2D collider for level could not be found.");
			}

			GameController.LevelCollider = levelObject.collider2D;
		}

		public static Vector3 GetLevelPos(int positionType,GameObject obj)
		{
			var collider = GameController.LevelCollider;
			var endPos = obj.transform.localPosition;
			
			switch (positionType)
			{
				case LEVEL_LEFT:
					endPos.x = collider.transform.localPosition.x - collider.bounds.size.x/2f + obj.renderer.bounds.size.x/2f;
					break;
				case LEVEL_CENTER:
					endPos.x = collider.transform.localPosition.x;
					break;
				case LEVEL_RIGHT:
					endPos.x = collider.transform.localPosition.x + collider.bounds.size.x/2f - obj.renderer.bounds.size.x/2f;
					break;
				case LEVEL_TOP:
					endPos.y = collider.transform.localPosition.y + collider.bounds.size.y/2f;
					break;
				case LEVEL_MIDDLE:
					endPos.y = collider.transform.localPosition.y;
					break;
				case LEVEL_BOTTOM:
					endPos.y = collider.transform.localPosition.y - collider.bounds.size.y/2f;
					break;
			}

			return endPos;
		}

		public static void LoadLevel(string name)
		{
			CameraFade.StartAlphaFade( Color.black, false, 0.5f, 0f, () => { 

				if(Application.isLoadingLevel) return;
				Application.LoadLevel(name); 
			});
		}

		public static void LoadLevel(int index)
		{
			CameraFade.StartAlphaFade( Color.black, false, 0.5f, 0f, () => { 
				
				if(Application.isLoadingLevel) return;
				Application.LoadLevel(index); 
			});
		}

		public static void Exit()
		{
			if(Application.isLoadingLevel) return;
			Application.Quit();
		}
	}
}

