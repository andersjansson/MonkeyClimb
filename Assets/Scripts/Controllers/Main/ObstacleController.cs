using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	[RequireComponent (typeof(MovementController))]
	public class ObstacleController : MonoBehaviour
	{
		private MovementController movement;
		public bool rotate;
		
		void Start()
		{
			this.movement = this.GetComponent<MovementController>();
		}
		
		void Update ()
		{
			this.movement.enabled = true;
			if(GameController.Pause || !ReadyController.Ready)
			{
				this.movement.enabled = false;
				this.rigidbody2D.velocity = Vector2.zero;
			}
			else
			{
				if(this.rotate)
					this.transform.RotateAround(this.renderer.bounds.center,Vector3.forward,this.movement.speed.y*400f*Time.deltaTime);
			}
		}
	}
}
