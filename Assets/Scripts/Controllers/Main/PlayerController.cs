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

		void Start ()
		{
			this.health 	= this.GetComponent<HealthController>();
			this.movement 	= this.GetComponent<MovementController>();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
