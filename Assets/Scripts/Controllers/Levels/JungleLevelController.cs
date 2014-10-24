using UnityEngine;
using System.Collections;
using Controllers.Main;
using Utilities;

namespace Controllers.Level
{
	public class JungleLevelController : MonoBehaviour
	{
		void Start ()
		{
			GameController.SetLevelCollider ("Level/Middlegrounds/Middlegrounds - Main/TreeTrunk1");
			AudioController.Play ("ButtonSound",5,forward:this.StartSound);
		}

		void StartSound()
		{
			AudioController.Play("BackgroundSound",2);
		}
	}
}
