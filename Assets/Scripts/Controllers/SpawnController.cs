using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using System.Threading;

namespace Controllers
{
	public class SpawnController : MonoBehaviour
	{
		/// <summary>
		/// The prefab to spawn.
		/// </summary>
		public Transform[] spawnPrefab;

		/// <summary>
		/// Use prefab's transform position instead.
		/// </summary>
		public bool usePrefabTransform = false;

		/// <summary>
		/// The minimum spawn rate in seconds.
		/// </summary>
		public float minSpawnRate = 0f;

		/// <summary>
		/// The spawn rate in seconds.
		/// </summary>
		public float spawnRate = 3f;

		/// <summary>
		/// Max amount of alive objects.
		/// </summary>
		public int maxCount = 1;

		/// <summary>
		/// Time in seconds for the spawner to start.
		/// </summary>
		public float startFrom = -1f;
		

		//----------------------------------------------------------------------------

		public DelayedExecution.WaitController spawner;
		private List<Transform> spawnedObjects;

		void Start()
		{
			float startFrom = this.startFrom;
			if(this.startFrom < 0f)
				startFrom = this.randomSpawnRate();

			this.spawnedObjects = new List<Transform>();
			spawner = this.gameObject.DoSomethingLater(this.Spawn,startFrom);
		}

		void Update()
		{
			
			bool pause = false;
			pause |= Input.GetButtonDown("Pause");
			
			if(pause)
			{
				this.spawner.pause = !spawner.pause;
			}

		}

		private float randomSpawnRate()
		{
			float spawnRate = this.spawnRate;
			if(this.minSpawnRate > 0f)
			{
				spawnRate = Random.Range(this.minSpawnRate,this.spawnRate);
			}

			return spawnRate;
		}
		
		private void Spawn()
		{
			this.spawnedObjects.RemoveAll(item => item == null);
			if(this.spawnedObjects.Count < this.maxCount)
			{
				var spawnPrefab = this.spawnPrefab[Random.Range(0,this.spawnPrefab.Length)];
				var spawnedTransform = Instantiate(spawnPrefab) as Transform;


				if(!this.usePrefabTransform)
					spawnedTransform.position = this.transform.position;
				else
				{
					Vector3 difference = new Vector3(
						0,
						spawnedTransform.position.y - this.transform.position.y,
						0);

					spawnedTransform.position -= difference;
				}

				this.spawnedObjects.Add(spawnedTransform);
			}

			spawner = this.gameObject.DoSomethingLater(this.Spawn,this.randomSpawnRate());
		}
	}
}
