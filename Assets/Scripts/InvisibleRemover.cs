using UnityEngine;
using System.Collections;
using Extensions;

public class InvisibleRemover : MonoBehaviour
{
	private bool hasSpawn = false;
	
	void Start ()
	{
		if(this.PartlyVisible() && renderer.IsVisibleFrom (Camera.main))
		{
			this.hasSpawn = true;
		}
	}
	
	private bool PartlyVisible()
	{
		bool partlyVisible = false;
		partlyVisible |= (this.transform.position.y < Camera.main.transform.position.y);
		partlyVisible |= (this.transform.position.x < Camera.main.transform.position.x);
		
		return partlyVisible;
	}
	
	void Update ()
	{
		if(!this.hasSpawn && this.PartlyVisible() && renderer.IsVisibleFrom(Camera.main))
		{
			this.hasSpawn = true;
		}
		else if(this.hasSpawn == true && renderer.IsVisibleFrom(Camera.main) == false)
		{
			Destroy(this.gameObject);
		}
	}
}