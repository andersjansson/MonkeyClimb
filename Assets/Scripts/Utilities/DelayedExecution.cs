using UnityEngine;
using System;
using System.Collections;

namespace Utilities
{
	public static class DelayedExecution
	{
		public static void StartCoroutine(this GameObject gameObject, IEnumerator coroutine)
		{
			var behaviour = gameObject.GetComponent<CoroutineHelper>();
			if(!behaviour)
				behaviour = gameObject.AddComponent<CoroutineHelper>();
			behaviour.StartCoroutine(coroutine);
		}
		
		public class CoroutineHelper : MonoBehaviour {}
		
		public class WaitController
		{
			public bool cancel;
			public bool pause;
		}
		
		static IEnumerator WaitForANumberOfFrames(int numberOfFrames, Action thingToDo, WaitController controller)
		{
			while(numberOfFrames > 0)
			{
				if(!controller.pause)
					numberOfFrames--;
				if(controller.cancel)
					yield break;
				yield return null;
			}

			thingToDo();
		}
		
		static IEnumerator WaitForAPeriodOfTime(float timeToWait, Action thingToDo, WaitController controller)
		{
			while(timeToWait > 0)
			{
				if(!controller.pause)
					timeToWait -= Time.deltaTime;
				if(controller.cancel)
					yield break;
				yield return null;
			}

			thingToDo();
		}
		
		public static WaitController DoSomethingLater(this GameObject gameObject, Action thingToDo, int numberOfFrames)
		{
			var controller = new WaitController();
			gameObject.StartCoroutine(WaitForANumberOfFrames(numberOfFrames, thingToDo, controller));
			return controller;
		}

		public static WaitController DoSomethingLater(this GameObject gameObject, Action thingToDo, float timeToWait)
		{
			var controller = new WaitController();
			gameObject.StartCoroutine(WaitForAPeriodOfTime(timeToWait, thingToDo, controller));
			return controller;
		}

		public static WaitController DoSomethingLater(this MonoBehaviour behaviour, Action thingToDo, int numberOfFrames)
		{
			var controller = new WaitController();
			behaviour.StartCoroutine(WaitForANumberOfFrames(numberOfFrames, thingToDo, controller));
			return controller;
		}

		public static WaitController DoSomethingLater(this MonoBehaviour behaviour, Action thingToDo, float timeToWait)
		{
			var controller = new WaitController();
			behaviour.StartCoroutine(WaitForAPeriodOfTime(timeToWait, thingToDo, controller));
			return controller;
		}
	}
}
