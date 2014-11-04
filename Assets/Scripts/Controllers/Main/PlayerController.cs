﻿using UnityEngine;
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
			centerPos.x 	= GameController.GetLevelPos (GameController.LEVEL_CENTER, this.gameObject).x;
			this.transform.localPosition = centerPos;
		}

		private void MoveHorizontal(int movetype)
		{
			var endPos 		= GameController.GetLevelPos(movetype,this.gameObject);
			var centerPos	= GameController.GetLevelPos(GameController.LEVEL_CENTER,this.gameObject);

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

			//Debug.Log (endPos.y + "dsdsd" + this.transform.localPosition.y);
			//if(endPos.y == this.transform.localPosition.y) return;

			if(this.transform.localPosition.y != middlePos.y && endPos.y != this.transform.localPosition.y)
			{

				Debug.Log (endPos.y + "dsdsd" + this.transform.localPosition.y);
				this.movement.StartLerp(middlePos,true);
				return;
			}
			
			if(endPos.y != this.transform.localPosition.y)
				this.movement.StartLerp(endPos,true);
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

				if(inputX < 0f)
				{
					this.MoveHorizontal(GameController.LEVEL_LEFT);
				}
				else if(inputX > 0f)
				{
					this.MoveHorizontal(GameController.LEVEL_RIGHT);
				}
				else if(inputY > 0f)
				{
					this.MoveVertical(GameController.LEVEL_TOP);
				}
				else if(inputY < 0f)
				{
					this.MoveVertical(GameController.LEVEL_BOTTOM);
				}
				else if(climbButton && this.transform.localPosition.y < 0.20f)
				{
					//this.movement.StartLerp(this.transform.localPosition + Vector3.up*0.1f,true);
				}
			}

			if(this.transform.localPosition.y > -0.6f)
			{
				//var newPos = this.transform.localPosition;
				//newPos.y = newPos.y - 0.1f * Time.deltaTime;
				//this.transform.localPosition = newPos;
			}
		}
	}
}
