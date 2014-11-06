using UnityEngine;
using System.Collections;
using Controllers.Main;
using Utilities;

namespace Controllers.Level
{
	public class JungleLevelController : MonoBehaviour
	{
		private GameObject skyboxPart1;
		private bool cloudFarSpawned = false;

		void Start ()
		{
			GameController.SetLevelCollider ("Render/Main Camera/MovementArea");
			AudioController.Play ("ButtonSound",5,forward:this.StartSound);

			this.skyboxPart1 = GameObject.Find("Level/Skyboxes/SkyboxJunglePart1");
		}

		void Update ()
		{
			if(!this.cloudFarSpawned && this.skyboxPart1 != null)
			{
				if(this.skyboxPart1.transform.position.y + this.skyboxPart1.renderer.bounds.size.y/2f  < Camera.main.transform.position.y)
				{
					GameObject cloudSpawner = GameObject.Find("Scroller/SpawnerClouds - Far");
					if(cloudSpawner != null)
					{
						cloudSpawner.GetComponent<SpawnController>().enabled = true;
						this.cloudFarSpawned = true;
					}
				}
			}
		}

		private void StartSound()
		{
			AudioController.Play("BackgroundSound",2);
		}
	}
}
