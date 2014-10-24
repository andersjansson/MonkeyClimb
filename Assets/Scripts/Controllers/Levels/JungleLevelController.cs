using UnityEngine;
using System.Collections;
using Controllers.Main;
using Utilities;

namespace Controllers.Level
{
	public class JungleLevelController : MonoBehaviour {

		private LabelController readyLabel;
		private LabelController readyStatusLabel; 
		public DelayedExecution.WaitController timer;
		private int iReady = 3;
		private bool readyEnd = false;
		private Color readyColor;

		// Use this for initialization
		void Start ()
		{
			GameController.SetLevelCollider ("Level/Middlegrounds/Middlegrounds - Main/TreeTrunk1");

			var labelObject = GameObject.Find ("GUI/ReadyLabel");
			this.readyLabel = labelObject.GetComponent<LabelController>();

			labelObject = GameObject.Find ("GUI/ReadyStatusLabel");
			this.readyStatusLabel = labelObject.GetComponent<LabelController>();

			this.readyColor = this.readyStatusLabel.style.normal.textColor;
			this.UpdateReady ();

			AudioController.Play ("ButtonSound",5,forward:this.StartSound);
		}
		
		// Update is called once per frame
		void Update ()
		{
			if(this.readyEnd && this.readyColor.a > 0f)
			{
				this.readyColor.a -= 1f * Time.deltaTime;
				//this.readyStatusLabel.fontSizeRatio *= this.readyColor.a/4f;

				this.readyLabel.style.normal.textColor = this.readyColor;
				this.readyStatusLabel.style.normal.textColor = this.readyColor;

				if(this.readyColor.a <= 0f)
				{
					this.readyLabel.enabled = false;
					this.readyStatusLabel.enabled = false;
				}
			}
		}

		void StartSound()
		{
			AudioController.Play("BackgroundSound",2);
		}

		void UpdateReady()
		{
			readyStatusLabel.title = iReady.ToString();
			if(iReady == 0)
			{
				readyStatusLabel.title = "Go!";
				readyEnd = true;
			}


			if(iReady > 0)
			{
				iReady--;
				this.timer = this.gameObject.DoSomethingLater(this.UpdateReady,1f);
			}
		}

		void FadeOut()
		{

		}
	}
}
