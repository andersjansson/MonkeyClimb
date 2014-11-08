using UnityEngine;
using System;
using System.Collections;
using Controllers.Main;

namespace Controllers
{
	public class LerpMovementController : MonoBehaviour
	{
		/// <summary>
		/// The time taken to move from the start to finish positions
		/// </summary>
		public float timeTakenDuringLerp = 1f;

		/// <summary>
		/// The start and finish positions for the interpolation
		/// </summary>
		public Vector3 startPosition;

		/// <summary>
		/// The end positions for the interpolation
		/// </summary>
		public Vector3 endPosition;

		//----------------------------------------------------------------------------

		public bool IsLerping{get;private set;}
		private float timeStartedLerping;
		private bool local = false;
		private Action callback;

		private void PrepareLerp()
		{
			this.startPosition 	= this.transform.position;
			if(this.local)
				this.startPosition 	= this.transform.localPosition;

			if(this.startPosition != this.endPosition)
			{
				this.timeStartedLerping = Time.time;
				this.IsLerping = true;
			}
		}


		/// <summary>
		/// Start move to end destination.
		/// </summary>
		/// <param name="endPosition"></param>
		/// <param name="local"></param>
		/// <param name="callback"></param>
		public void StartLerp(Vector3 endPosition,bool local = false,Action callback = null)
		{
			if(this.IsLerping) return;

			this.callback = callback;
			this.local = local;
			this.endPosition 	= endPosition;
			this.PrepareLerp();
		}

		/// <summary>
		/// Start move to end destination using fixed finish position.
		/// </summary>
		/// <param name="local"></param>
		/// <param name="callback"></param>
		public void StartLerp(bool local = false,Action callback = null)
		{
			if(this.IsLerping) return;

			this.callback = callback;
			this.local = local;
			this.PrepareLerp();
		}

		/// <summary>
		/// Stop moving.
		/// </summary>
		public void Stop()
		{
			if(this.callback != null)
			{
				this.callback();
			}

			this.IsLerping = false;
		}

		void FixedUpdate()
		{
			if(GameController.Pause) return;

			if(this.IsLerping)
			{
				float timeSinceStarted = Time.time - this.timeStartedLerping;
				float percentageComplete = timeSinceStarted / this.timeTakenDuringLerp;
				if(percentageComplete >= 1.0f)
				{
					percentageComplete = 1.0f;
				}			

				if(this.local)
				{
					this.transform.localPosition = Vector3.Lerp(this.startPosition, this.endPosition, percentageComplete);
					if(this.transform.localPosition == this.endPosition)
					{
						this.Stop();
					}

					return;
				}

				this.transform.position = Vector3.Lerp(this.startPosition, this.endPosition, percentageComplete);
				if(this.transform.position == this.endPosition)
				{
					this.Stop();
				}
			}
		}
	}
}