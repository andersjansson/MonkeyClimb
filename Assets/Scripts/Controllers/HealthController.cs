using UnityEngine;
using System.Collections;
using Controllers.Main;

namespace Controllers
{
	/// <summary>
	/// Handle hitpoints and damages
	/// </summary>
	public class HealthController : MonoBehaviour
	{
		/// <summary>
		/// Total hitpoints
		/// </summary>
		public int hp = 1;
		
		/// <summary>
		/// Enemy or player?
		/// </summary>
		public bool isEnemy = true;
		
		//----------------------------------------------------------------------------

		/// <summary>
		/// Inflicts damage and check if the object should be destroyed
		/// </summary>
		/// <param name="damageCount"></param>
		public void Damage(int damageCount)
		{
			if(this.gameObject != null)
			{
				this.hp -= damageCount;
				if(this.hp <= 0)
				{
					Destroy(this.gameObject);
				}
			}
		}
		
		void OnTriggerEnter2D(Collider2D otherCollider)
		{
			// Is this a obstacle?
			ObstacleController obstacle = otherCollider.gameObject.GetComponent<ObstacleController>();
			if (obstacle != null)
			{
				var health = otherCollider.gameObject.GetComponent<HealthController>();
				if(this.isEnemy && health.isEnemy) return;

				Destroy(otherCollider.gameObject);
				this.Damage(1);
				GameOverController.ShowGameOver = true;
				AudioController.Play("FXSound",7);
				Debug.Log("FOUND! - Test Game Over.");
			}
		}
	}
}
