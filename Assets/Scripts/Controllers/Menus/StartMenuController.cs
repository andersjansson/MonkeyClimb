using UnityEngine;
using System.Collections;
using Utilities;
using Controllers.Main;

namespace Controllers.Menus
{
	public class StartMenuController : MonoBehaviour
	{
		void Start()
		{
	
		}

		void Update ()
		{
			bool continueButton = false;

			continueButton |= Input.GetButtonDown("Fire1");
			continueButton |= Input.GetButtonDown("Fire2");
			continueButton |= Input.GetButtonDown("Exit");

			if(continueButton)
			{
				AudioController.Play("ButtonSound",4,true,this.MainMenu);
			}
		}

		private void MainMenu()
		{
			CameraFade.StartAlphaFade( Color.black, false, 1f, 0f, () => { Application.LoadLevel("MainMenu"); } );
		}
	}
}