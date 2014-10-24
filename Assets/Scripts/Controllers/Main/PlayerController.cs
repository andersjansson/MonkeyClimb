using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Controllers.Main
{
	/// <summary>
	/// Player controller and behavior
	/// </summary>
	[RequireComponent (typeof(SpriteRenderer))]
	public class PlayerController : MonoBehaviour
	{
		private HealthController 	health;
		private LerpMovementController 	movement;

		void Start ()
		{
			this.health 	= this.GetComponent<HealthController>();
			this.movement 	= this.GetComponent<LerpMovementController>();

			var centerPos	= this.transform.position;
			centerPos.x 	= GameController.GetLevelPos (GameController.LEVEL_CENTER, this.renderer.bounds).x;
			this.transform.position = centerPos;
		}

		private void Move(int movetype)
		{
			var endPos 		= GameController.GetLevelPos(movetype,this.renderer.bounds);
			var centerPos	= GameController.GetLevelPos(GameController.LEVEL_CENTER,this.renderer.bounds);

			if(this.transform.position.x != centerPos.x && endPos.x != this.transform.position.x)
			{
				this.movement.StartLerp(centerPos);
				return;
			}
	
			if(endPos.x != this.transform.position.x)
				this.movement.StartLerp(endPos);
		}



		void Update()
		{
			if(ReadyController.Ready && this.movement != null && !this.movement.IsLerping)
			{
				float inputX = Input.GetAxis ("Horizontal");
				//float inputY = Input.GetAxis ("Vertical");

				if(inputX < 0f)
				{
					this.Move(GameController.LEVEL_LEFT);
				}
				else if(inputX > 0f)
				{
					this.Move(GameController.LEVEL_RIGHT);
				}
			}
		}
	}
}
