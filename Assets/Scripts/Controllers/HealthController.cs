using UnityEngine;
using System.Collections;

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

		}
	}
}
