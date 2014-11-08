using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	public class CloudController : MonoBehaviour
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
				this.rigidbody2D.velocity = new Vector2(0f,0f);
			}
		}
	}
}