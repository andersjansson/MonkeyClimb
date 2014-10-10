using UnityEngine;
using System.Collections;

namespace Controllers.Menus
{
	public class StartMenuController : MonoBehaviour {


		void Start () {
		
		}

		void OnGUI()
		{
			//Utilities.GUIScale.AutoResize(1920, 1200);
		}

		void Update () {

			bool continueButton = false;

			continueButton |= Input.GetButtonDown("Fire1");
			continueButton |= Input.GetButtonDown("Fire2");
			continueButton |= Input.GetButtonDown("Exit");

			if(continueButton)
			{
				Application.LoadLevel("MainMenu");
			}
		
		}
	}
}