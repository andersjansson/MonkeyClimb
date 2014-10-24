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

		private GameObject moveBox;
	
		void Start ()
		{
			this.health 	= this.GetComponent<HealthController>();
			this.movement 	= this.GetComponent<LerpMovementController>();

			this.moveBox = GameObject.Find("Level/Middlegrounds/Middlegrounds - Main/TreeTrunk1");
		}


		private void MoveLeft()
		{
			var endPos = this.transform.position;
			endPos.x = 
				moveBox.collider2D.bounds.center.x - 
					moveBox.collider2D.bounds.size.x/2f +
					this.renderer.bounds.size.x/2f;

			this.movement.StartLerp(endPos);
		}

		private void MoveCenter()
		{
			var endPos = this.transform.position;
			endPos.x = moveBox.transform.position.x;
			
			this.movement.StartLerp(endPos);
		}

		private void MoveRight()
		{
			var endPos = this.transform.position;
			endPos.x = 
				moveBox.collider2D.bounds.center.x + 
					moveBox.collider2D.bounds.size.x/2f -
					this.renderer.bounds.size.x/2f;

			this.movement.StartLerp(endPos);
		}

		void Update()
		{
			if(this.movement != null && !this.movement.IsLerping)
			{
				float inputX = Input.GetAxis ("Horizontal");
				//float inputY = Input.GetAxis ("Vertical");

				if (this.renderer == null) return;

				if(inputX < 0f)
				{
					this.MoveLeft();
				}
				else if(inputX > 0f)
				{
					this.MoveRight();
				}
			}
		}
	}
}
