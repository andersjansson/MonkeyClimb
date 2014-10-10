using UnityEngine;
using System.Collections;

namespace Controllers.Main
{
	public class PersistentDataController : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void Awake()
		{
			DontDestroyOnLoad (this.gameObject);
		}
	}
}
