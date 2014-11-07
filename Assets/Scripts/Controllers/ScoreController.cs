using UnityEngine;
using System;
using System.Collections;

namespace Controllers
{
	public class ScoreController : MonoBehaviour
	{
		public GameObject labelObject;
		private LabelController label;

		private float points = 0f;
		public 	float Points
		{
			get
			{
				return points;
			}
			set
			{
				this.points = value;
				this.UpdateScore();
			}
		}

		// Use this for initialization
		void Start ()
		{
			if(this.labelObject != null)
			{
				this.label = this.labelObject.GetComponent<LabelController>();
				this.UpdateScore();
			}
		}

		private void UpdateScore()
		{
			this.label.title = String.Format ("Distance: {0} Meters", (int)this.Points);
		}
	}
}