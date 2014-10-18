using UnityEngine;
using System.Collections;
using Extensions;

namespace Controllers.Main
{
	public class LeafController : MonoBehaviour
	{
		private MovementController moveController;

		private bool hasSpawn = false;
		private bool moveLeft = false;

		private float speed = 0.01f;
		private float rotation = 0f;

		void Start ()
		{
			this.moveController = this.GetComponent<MovementController>();
			this.GetComponent<SpriteRenderer>().color = new Color(1f, Random.Range(0.7f,1f), 1f);
		}

		void Update ()
		{
			if(moveLeft)
			{
				if(this.speed < -0.1f)
				{
					moveLeft = false;
				}

				this.speed -= 0.1f * Time.deltaTime;
			}
			else
			{
				if(this.speed > 0.1f)
				{
					moveLeft = true;
				}

				this.speed += 0.1f * Time.deltaTime;
			}


			//transform.Rotate(Vector3.left,Time.deltaTime);
			//this.transform.rotation = Quaternion.AngleAxis(180f-this.speed*200, Vector3.forward);

			this.rotation += 40f * Time.deltaTime;

			this.transform.rotation = Quaternion.Euler (this.speed * 200, this.rotation, 180f - this.speed * 200);

			this.moveController.speed = new Vector2 (this.speed, 0f);

			if(this.hasSpawn == false && renderer.IsVisibleFrom(Camera.main) == true)
			{
				this.hasSpawn = true;
			}
			else if(this.hasSpawn == true && renderer.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
