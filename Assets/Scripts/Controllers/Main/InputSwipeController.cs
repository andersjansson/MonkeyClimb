using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	public class InputSwipeController : MonoBehaviour
	{
		/// <summary>
		/// Distance needed for a swipe to register.
		/// </summary>
		public float dragDistance = 5;

		//----------------------------------------------------------------------------

		private Vector3 fp; //First finger position
		private Vector3 lp; //Last finger position

		public static bool Left 	{get;private set;}
		public static bool Right 	{get;private set;}
		public static bool Up 		{get;private set;}
		public static bool Down 	{get;private set;}
		public static bool Tap 		{get;private set;}

		void Update()
		{
			InputSwipeController.Left 	= false;
			InputSwipeController.Right 	= false;
			InputSwipeController.Up 	= false;
			InputSwipeController.Down 	= false;
			InputSwipeController.Tap 	= false;

			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Began)
				{
					fp = touch.position;
					lp = touch.position;
				}

				if (touch.phase == TouchPhase.Moved)
				{
					lp = touch.position;
				}

				if (touch.phase == TouchPhase.Ended)
				{
					//First check if it's actually a drag
					if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
					{
						//If the horizontal movement is greater than the vertical movement...
						if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
						{   
							if(lp.x>fp.x) InputSwipeController.Right = true;
							else InputSwipeController.Left = true;
						}
						else
						{
							if (lp.y>fp.y) InputSwipeController.Up = true;
							else InputSwipeController.Down = true;
						}
					}
					else
					{
						InputSwipeController.Tap = true;
					}
				}
			}
		}
	}
}
