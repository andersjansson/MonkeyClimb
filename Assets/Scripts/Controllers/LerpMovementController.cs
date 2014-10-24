using UnityEngine;
using System.Collections;

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

		private void PrepareLerp()
		{
			this.IsLerping = true;
			this.timeStartedLerping = Time.time;
			this.startPosition 	= this.transform.position;
		}


		/// <summary>
		/// Start move to end destination.
		/// </summary>
		/// <param name="endPosition"></param>
		public void StartLerp(Vector3 endPosition)
		{
			this.PrepareLerp();
			this.endPosition 	= endPosition;
		}

		/// <summary>
		/// Start move to end destination using fixed finish position.
		/// </summary>
		public void StartLerp()
		{
			this.PrepareLerp();
		}

		/// <summary>
		/// Stop moving.
		/// </summary>
		public void Stop()
		{
			this.IsLerping = false;
		}

		void FixedUpdate()
		{
			if(this.IsLerping)
			{
				float timeSinceStarted = Time.time - this.timeStartedLerping;
				float percentageComplete = timeSinceStarted / this.timeTakenDuringLerp;
				if(percentageComplete >= 1.0f)
				{
					this.IsLerping = false;
					percentageComplete = 1.0f;
				}				

				Vector3 newPos = this.transform.position;
				newPos.x = Vector3.Lerp (this.startPosition, this.endPosition, percentageComplete).x;
				transform.position = newPos;
			}
		}
	}
}