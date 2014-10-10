using UnityEngine;
using System.Collections;

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

		//----------------------------------------------------------------------------
		
		private Vector2 movement;

		void Update()
		{
			this.movement = new Vector2
			(
				this.speed.x * this.direction.x,
				this.speed.y * this.direction.y
			);
		}
		
		void FixedUpdate()
		{
			this.rigidbody2D.velocity = this.movement;
		}
	}
}