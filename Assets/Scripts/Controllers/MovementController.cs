using UnityEngine;
using System.Collections;
using Controllers.Main;

namespace Controllers
{
	/// <summary>
	/// Simply moves the current game object
	/// </summary>
	public class MovementController : MonoBehaviour
	{
		/// <summary>
		/// Object speed
		/// </summary>
		public Vector2 speed = new Vector2(1, 1);
		
		/// <summary>
		/// Moving direction
		/// </summary>
		public Vector2 direction = new Vector2(-1, 0);

		/// <summary>
		/// Enable default rigidbody gravity. (no fall speed)
		/// </summary>
		public bool gravity = true;

		//----------------------------------------------------------------------------
		
		private Vector2 movement;

		void Update()
		{
			float fallVelocity = this.speed.y * this.direction.y;
			if(this.gravity)
				fallVelocity = this.rigidbody2D.velocity.y;

			this.movement = new Vector2
			(
				this.speed.x * this.direction.x,
				fallVelocity
			);
		}
		
		void FixedUpdate()
		{
			this.rigidbody2D.velocity = this.movement;
		}
	}
}