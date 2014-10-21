using UnityEngine;
using System.Collections;
using Extensions;

public class StaticSpriteController : MonoBehaviour
{
	private bool hasSpawn = false;

	void Update ()
	{
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
