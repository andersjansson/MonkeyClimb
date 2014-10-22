using UnityEngine;
using System.Collections;
using Utilities;

namespace Controllers.Main
{	
	public class GameController : MonoBehaviour
	{
		void Start ()
		{
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
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

