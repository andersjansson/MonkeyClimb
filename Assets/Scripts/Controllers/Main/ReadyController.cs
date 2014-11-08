using UnityEngine;
using System.Collections;
using Utilities;

namespace Controllers.Main
{
	public class ReadyController : MonoBehaviour
	{
		public DelayedExecution.WaitController timer;

		private LabelController readyLabel;
		private LabelController readyStatusLabel; 
		private int iReady = 3;
		private Color color;

		public static bool Ready{get;private set;}

		void Start ()
		{
			var labelObject = GameObject.Find ("GUI/Ready/ReadyLabel");
			this.readyLabel = labelObject.GetComponent<LabelController>();
			
			labelObject = GameObject.Find ("GUI/Ready/ReadyStatusLabel");
			this.readyStatusLabel = labelObject.GetComponent<LabelController>();

			this.color = this.readyStatusLabel.style.normal.textColor;
			this.UpdateReady ();
		}
		
		// Update is called once per frame
		void Update ()
		{
			this.timer.pause = false;
			if(GameController.Pause) this.timer.pause = true;
			else
			{
				if(ReadyController.Ready && this.color.a > 0f)
				{
					this.color.a -= 1f * Time.deltaTime;
					//this.readyStatusLabel.fontSizeRatio *= this.readyColor.a/4f;
					
					this.readyLabel.style.normal.textColor = this.color;
					this.readyStatusLabel.style.normal.textColor = this.color;
					
					if(this.color.a <= 0f)
					{
						this.readyLabel.enabled = false;
						this.readyStatusLabel.enabled = false;
					}
				}
			}
		}

		void UpdateReady()
		{
			readyStatusLabel.title = iReady.ToString();
			if(iReady == 0)
			{
				readyStatusLabel.title = "Go!";
				ReadyController.Ready = true;
			}
			
			
			if(iReady > 0)
			{
				iReady--;
				this.timer = this.gameObject.DoSomethingLater(this.UpdateReady,1f);
			}
		}
	}
}
