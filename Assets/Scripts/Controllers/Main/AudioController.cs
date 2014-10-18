using UnityEngine;
using System.Collections;

namespace Controllers.Main
{	
	public class AudioController : MonoBehaviour
	{
		public static void LoopMenuMusic()
		{
			GameObject audioObject = GameObject.Find("PersistentData/Sounds/BackgroundMenuMusic");
			if(audioObject != null && !audioObject.audio.isPlaying)
			{
				audioObject.audio.loop = true;
				audioObject.audio.Play();
			}
		}

		public static void PlayButtonClick()
		{
			GameObject audioObject = GameObject.Find("PersistentData/Sounds/MenuButtonSound");
			if(audioObject != null && !audioObject.audio.isPlaying)
			{
				audioObject.audio.Play();
			}
		}
	}
}

