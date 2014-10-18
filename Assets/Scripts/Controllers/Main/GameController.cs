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
	}
}

