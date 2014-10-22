using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Utilities;
using Models;

namespace Controllers.Main
{	
	public class AudioController : MonoBehaviour
	{
		private static Dictionary<string,AudioSource> instance;
		private static AudioClip[] clips;
		public 	static DelayedExecution.WaitController wait;

		static AudioController()
		{
			AudioController.instance = new Dictionary<string,AudioSource>();
		}

		void Awake()
		{
			GameObject soundsObject = GameObject.Find("PersistentData/Sounds");

			if(soundsObject != null)
			{
				var clips = soundsObject.GetComponent<SoundClips>();
				AudioController.clips = clips.sounds;
				
				AudioController.Set("BackgroundSound",true);
				AudioController.Set("ButtonSound");
			}
		}

		public static void Set(string name, bool loop = false)
		{
			GameObject audioObject = GameObject.Find("PersistentData/Sounds/" + name);
			if (audioObject != null && !AudioController.instance.ContainsKey(name))
			{
				audioObject.audio.loop = loop;
				AudioController.instance.Add(name,audioObject.audio);
			}
		}

		public static void PlayIfPaused(string key)
		{
			AudioController.Play (key, once: true);
		}

		public static void Play(string key, int index = -1, bool once = false, Action forward = null)
		{
			if (!AudioController.instance.ContainsKey(key)) return;

			AudioSource audio = AudioController.instance [key].audio;
			if(once && audio.isPlaying) return;

			if(index > -1)
			{
				audio.clip = AudioController.clips[index];
			}

			audio.Play();
			if(forward != null)
			{
				AudioController.wait = audio.gameObject.DoSomethingLater(forward,audio.clip.length);
			}
		}

		public static void Pause(string key)
		{
			AudioController.Stop (key, true);
		}

		public static void Stop(string key, bool pause = false)
		{
			if (!AudioController.instance.ContainsKey(key)) return;

			AudioSource audio = AudioController.instance [key].audio;
			if(pause)
			{
				audio.Pause();
				return;
			}

			audio.Stop();
		}
	}
}

