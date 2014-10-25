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
				bool climbButton = false;
				climbButton |= Input.GetButtonDown("Fire1");
				climbButton |= Input.GetButtonDown("Fire2");

				if(inputX < 0f)
				{
					this.Move(GameController.LEVEL_LEFT);
				}
				else if(inputX > 0f)
				{
					this.Move(GameController.LEVEL_RIGHT);
				}
				else if(climbButton && this.transform.localPosition.y < 0.20f)
				{
					this.movement.StartLerp(this.transform.localPosition + Vector3.up*0.1f,true);
				}
			}

			if(this.transform.localPosition.y > -0.6f)
			{
				var newPos = this.transform.localPosition;
				newPos.y = newPos.y - 0.1f * Time.deltaTime;
				this.transform.localPosition = newPos;
			}
		}
	}
}
