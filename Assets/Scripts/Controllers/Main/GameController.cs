using UnityEngine;
using System.Collections;
using Utilities;

namespace Controllers.Main
{	
	public class GameController : MonoBehaviour
	{
		public static Collider2D LevelCollider {get;private set;}

		public const int LEVEL_LEFT 	= 0;
		public const int LEVEL_CENTER 	= 1;
		public const int LEVEL_RIGHT 	= 2;

		void Start ()
		{
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

		public static Vector3 GetLevelPos(int positionType,Bounds bounds)
		{
			var collider = GameController.LevelCollider;
			var endPos = bounds.center;
			
			switch (positionType)
			{
				case LEVEL_LEFT:
					endPos.x = collider.bounds.center.x - collider.bounds.size.x/2f + bounds.size.x/2f;
					break;
				case LEVEL_CENTER:
					endPos.x = collider.bounds.center.x;
					break;
				case LEVEL_RIGHT:
					endPos.x = collider.bounds.center.x + collider.bounds.size.x/2f - bounds.size.x/2f;
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

		public static void Exit()
		{
			if(Application.isLoadingLevel) return;
			Application.Quit();
		}
	}
}

