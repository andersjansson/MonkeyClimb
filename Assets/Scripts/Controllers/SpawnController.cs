﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace Controllers
{
	public class SpawnController : MonoBehaviour
	{
		/// <summary>
		/// The prefab to spawn.
		/// </summary>
		public Transform spawnPrefab;

		/// <summary>
		/// The spawn rate in seconds.
		/// </summary>
		public float spawnRate = 3f;

		/// <summary>
		/// Max amount of alive objects.
		/// </summary>
		public int maxCount = 1;

		//----------------------------------------------------------------------------

		public DelayedExecution.WaitController spawner;
		private List<Transform> spawnedObjects;

		void Start()
		{
			spawner = this.gameObject.DoSomethingLater(this.Spawn,this.spawnRate);
			this.spawnedObjects = new List<Transform>();
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
		
		private void Spawn()
		{
			this.spawnedObjects.RemoveAll(item => item == null);
			if(this.spawnedObjects.Count < this.maxCount)
			{
				var spawnedTransform = Instantiate(this.spawnPrefab) as Transform;
				spawnedTransform.position = this.transform.position;

				this.spawnedObjects.Add(spawnedTransform);
			}

			spawner = this.gameObject.DoSomethingLater(this.Spawn,this.spawnRate);
		}
	}
}
