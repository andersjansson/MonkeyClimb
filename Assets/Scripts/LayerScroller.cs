using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extensions;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class LayerScroller : MonoBehaviour
{
	/// <summary>
	/// Scrolling speed
	/// </summary>
	public Vector2 speed = new Vector2(2, 2);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	/// <summary>
	/// Movement should be applied to camera
	/// </summary>
	public bool isLinkedToCamera = false;
	
	/// <summary>
	/// Background is infinite
	/// </summary>
	public bool isLooping = false;
	
	//----------------------------------------------------------------------------
	
	private List<Transform> backgroundParts;
	
	void Start()
	{
		if(this.isLooping)
		{
			// Get all the children of the layer with a renderer
			backgroundParts = new List<Transform>();
			
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				
				// Add only the visible children
				if (child.renderer != null)
				{
					backgroundParts.Add(child);
				}
			}
			
			// Sort by position. (Unfinished)
			// Note: Get the children from left to right.
			// We would need to add a few conditions to handle
			// all the possible scrolling directions.
			backgroundParts = backgroundParts.OrderBy(
				t => t.position.x
				).ToList();
		}
	}
	
	void Update()
	{
		Vector3 movement = new Vector3(
			this.speed.x * this.direction.x,
			this.speed.y * this.direction.y,
			0);
		
		movement *= Time.deltaTime;
		this.transform.Translate(movement);
		
		if (this.isLinkedToCamera)
		{
			Camera.main.transform.Translate(movement);
		}
		
		if (this.isLooping)
		{
			// Get the first object.
			// The list is ordered from left (x position) to right.
			Transform firstChild = this.backgroundParts.FirstOrDefault();
			
			if (firstChild != null)
			{
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				if (firstChild.position.x < Camera.main.transform.position.x)
				{
					// If the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if(firstChild.renderer.IsVisibleFrom(Camera.main) == false)
					{
						// Get the last child position.
						Transform lastChild 	= this.backgroundParts.LastOrDefault();
						Vector3 lastPosition 	= lastChild.transform.position;
						Vector3 lastSize 		= (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
						
						// Set the position of the recyled one to be AFTER
						// the last child.
						// Note: Only work for horizontal scrolling currently.
						firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);
						
						// Set the recycled child to the last position
						// of the backgroundPart list.
						this.backgroundParts.Remove(firstChild);
						this.backgroundParts.Add(firstChild);
					}
				}
			}
		}
	}
}
