using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using System.Threading;
using Controllers.Main;

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
		private Transform lastPrefab;

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
			this.spawner.pause = false;
			if(GameController.Pause)
			{
				this.spawner.pause = true;
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
			if (this.spawnPrefab.Length == 0)
			{
				Debug.LogError("No spawnPrefab have been set, please check the inspector.");
				return;
			}

			this.spawnedObjects.RemoveAll(item => item == null);
			if(this.spawnedObjects.Count < this.maxCount)
			{
				int index = 0;
				Transform tempPrefab = this.spawnPrefab[0];
				if (this.spawnPrefab.Length > 1)
				{
					List<Transform> tempPrefabs = this.spawnPrefab.OfType<Transform>().ToList();
					if(this.lastPrefab != null)
					{
						tempPrefabs.Remove(this.lastPrefab);
					}

					index = Random.Range (0, tempPrefabs.Count);

					tempPrefab = tempPrefabs[index];
					this.lastPrefab = tempPrefab;
				}

				var spawnedTransform = Instantiate(tempPrefab) as Transform;
				if(!this.usePrefabTransform)
					spawnedTransform.position = this.transform.position;
				else
				{
					Vector3 difference = new Vector3(
						0,
						this.transform.position.y - spawnedTransform.position.y,
						0);

					spawnedTransform.position += difference;
				}

				//this.spawnPrefab[index].renderer.bounds.Intersects

				this.spawnedObjects.Add(spawnedTransform);
			}

			spawner = this.gameObject.DoSomethingLater(this.Spawn,this.randomSpawnRate());
		}
	}
}
