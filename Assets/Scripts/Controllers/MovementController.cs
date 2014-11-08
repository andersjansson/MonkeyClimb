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
		/// Move toward a target
		/// </summary>
		public GameObject target;

		/// <summary>
		/// Move toward a player
		/// </summary>
		public bool targetPlayer;

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

		void Start()
		{
			if(targetPlayer)
			{
				this.target = GameObject.FindGameObjectWithTag("Player");
			}

			if(this.target != null)
			{
				this.direction = (this.target.transform.position - this.transform.position).normalized;
				this.direction.x = this.direction.x * this.speed.x;
				this.direction.y = this.direction.y * this.speed.y;

				this.transform.LookAt(target.transform);
			}
		}

		void Update()
		{
			if(this.target != null)
			{
				this.movement = this.direction;
				return;
			}

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