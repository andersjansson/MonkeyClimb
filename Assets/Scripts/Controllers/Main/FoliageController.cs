using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	public class FoliageController : MonoBehaviour
	{
		private MovementController movement;

		void Start()
		{
			this.movement = this.GetComponent<MovementController>();
		}

		void Update ()
		{
			this.movement.enabled = true;
			if(GameController.Pause)
			{
				this.movement.enabled = false;
				this.rigidbody2D.velocity = Vector2.zero;
			}
		}
	}
}
