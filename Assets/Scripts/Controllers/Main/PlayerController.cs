using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Controllers.Main
{
	/// <summary>
	/// Player controller and behavior
	/// </summary>
	public class PlayerController : MonoBehaviour
	{
		private HealthController 	health;
		private MovementController 	movement;

		private float moveTimer;
		private Vector3 startPos;
		private Vector3 endPos;
		private GameObject moveBox;

		void Start ()
		{
			this.health 	= this.GetComponent<HealthController>();
			this.movement 	= this.GetComponent<MovementController>();

			this.moveBox = GameObject.Find("Level/Middlegrounds/Middlegrounds - Main/TreeTrunk1");


			MoveLeft ();

		}

		void ResetMove()
		{
			this.moveTimer = Time.time;
			this.startPos = this.transform.position;
			this.endPos = this.transform.position;
		}

		void MoveLeft()
		{
			this.ResetMove ();
			this.endPos.x = 
				moveBox.transform.position.x - 
					moveBox.renderer.bounds.size.x/2f +
					this.renderer.bounds.size.x;
		}

		void MoveRight()
		{
			this.ResetMove ();
			this.endPos.x = 
				moveBox.transform.position.x + 
					moveBox.renderer.bounds.size.x/2f -
					this.renderer.bounds.size.x/2f;
		}
		
		// Update is called once per frame
		void Update ()
		{
			float inputX = Input.GetAxis("Horizontal");
			//float inputY = Input.GetAxis("Vertical");

			//Debug.Log(inputX);

			//Debug.Log (Time.time - moveTimer);
			transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 20f);
		}
	}
}
