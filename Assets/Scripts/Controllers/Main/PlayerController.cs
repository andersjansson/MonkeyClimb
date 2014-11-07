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
		private int lastVerticalMoveType = GameController.LEVEL_MIDDLE;

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

			this.movement.timeTakenDuringLerp = 0.5f;
			if(this.transform.localPosition.x != centerPos.x && endPos.x != this.transform.localPosition.x)
			{
				this.movement.StartLerp(centerPos,true);
				return;
			}
	
			if(endPos.x != this.transform.localPosition.x)
				this.movement.StartLerp(endPos,true);
		}

		private void MoveVertical(int movetype)
		{
			var endPos 		= GameController.GetLevelPos(movetype,this.gameObject);
			var middlePos	= GameController.GetLevelPos(GameController.LEVEL_MIDDLE,this.gameObject);

			this.movement.timeTakenDuringLerp = 1f;
			if(this.lastVerticalMoveType != GameController.LEVEL_MIDDLE && this.lastVerticalMoveType != movetype)
			{
				this.movement.StartLerp(middlePos,true,() => {

					this.lastVerticalMoveType = GameController.LEVEL_MIDDLE; 
				});

				return;
			}

			if(endPos.y != this.transform.localPosition.y && this.transform.localPosition.y == middlePos.y)
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

			this.score.Points = (this.GetComponentInParent<Transform>().position.y - this.transform.localPosition.y)*10f;
		}
	}
}
