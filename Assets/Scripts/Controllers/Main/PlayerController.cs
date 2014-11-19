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
		private HealthController 		health;
		private LerpMovementController 	movement;
		private ScoreController 		score;

		private int lastVerticalMoveType 	= GameController.LEVEL_MIDDLE;
		private int lastHorizontalMoveType 	= GameController.LEVEL_CENTER;

		void Start ()
		{
			this.health 	= this.GetComponent<HealthController>();
			this.movement 	= this.GetComponent<LerpMovementController>();
			this.score 		= this.GetComponent<ScoreController>();

			var centerPos	= this.transform.position;
			centerPos.x 	= GameController.GetLevelPos (GameController.LEVEL_CENTER, this.gameObject).x;
			this.transform.localPosition = centerPos;
		}

		private void MoveHorizontal(int movetype)
		{
			var endPos 		= GameController.GetLevelPos(movetype,this.gameObject);
			var centerPos	= GameController.GetLevelPos(GameController.LEVEL_CENTER,this.gameObject);

			this.movement.timeTakenDuringLerp = 0.3f;

			if(this.lastHorizontalMoveType != GameController.LEVEL_CENTER && this.lastHorizontalMoveType != movetype)
			{
				this.movement.StartLerp(centerPos,true,() => {
					
					this.lastHorizontalMoveType = GameController.LEVEL_CENTER; 
				});
				
				return;
			}
	
			if(this.lastHorizontalMoveType != movetype)
			{
				this.movement.StartLerp(endPos,true,() => {
					
					this.lastHorizontalMoveType = movetype; 
				});
			}
		}

		private void MoveVertical(int movetype)
		{
			var endPos 		= GameController.GetLevelPos(movetype,this.gameObject);
			var middlePos	= GameController.GetLevelPos(GameController.LEVEL_MIDDLE,this.gameObject);

			this.movement.timeTakenDuringLerp = 0.3f;
			if(this.lastVerticalMoveType != GameController.LEVEL_MIDDLE && this.lastVerticalMoveType != movetype)
			{
				this.movement.StartLerp(middlePos,true,() => {

					this.lastVerticalMoveType = GameController.LEVEL_MIDDLE; 
				});

				return;
			}

			if(this.lastVerticalMoveType != movetype)
			{
				this.movement.StartLerp(endPos,true,() => {

					this.lastVerticalMoveType = movetype; 
				});
			}
		}



		void Update()
		{
			if(ReadyController.Ready && this.movement != null && !this.movement.IsLerping)
			{
				float inputX = Input.GetAxis ("Horizontal");
				float inputY = Input.GetAxis ("Vertical");

				bool climbButton = false;
				climbButton |= Input.GetButtonDown("Fire1");
				climbButton |= Input.GetButtonDown("Fire2");
				climbButton |= (inputY > 0f);

				if(inputX < 0f || InputSwipeController.Left)
				{
					this.MoveHorizontal(GameController.LEVEL_LEFT);
				}
				else if(inputX > 0f || InputSwipeController.Right)
				{
					this.MoveHorizontal(GameController.LEVEL_RIGHT);
				}
				else if(inputY > 0.1f || InputSwipeController.Up)
				{
					this.MoveVertical(GameController.LEVEL_TOP);
				}
				else if(inputY < -0.1f || InputSwipeController.Down)
				{
					this.MoveVertical(GameController.LEVEL_BOTTOM);
				}
			}

			this.score.Points = (this.GetComponentInParent<Transform>().position.y - this.transform.localPosition.y)*100f;
		}
	}
}
