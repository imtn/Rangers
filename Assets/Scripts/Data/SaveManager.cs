using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.Data
{
	public class SaveManager : DataManager
	{
		public static SaveManager instance;

		protected override void Init()
		{
			if(instance == null)
			{
				DontDestroyOnLoad(gameObject);
				instance = this;
			}
			else if(instance != this)
			{
				Destroy(gameObject);
			}
		}

		public static void SaveAudio(float sfxVol, float musicVol)
		{
#if UNITY_WEBPLAYER
			PlayerPrefs.SetFloat(audioHash + 0, sfxVol);
			PlayerPrefs.SetFloat(audioHash + 1, musicVol);
#else
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(audioDataPath);

			AudioData data = new AudioData(sfxVol, musicVol);

			bf.Serialize(file, data);
			file.Close();
#endif
		}

		public static void SaveVideo(int resolutionIndex, int qualityIndex, bool fullscreen)
		{
#if UNITY_WEBPLAYER
			PlayerPrefs.SetInt(videoHash + 0, resolutionIndex);
			PlayerPrefs.SetInt(videoHash + 1, qualityIndex);
			int full = _fullscreen ? 1 : 0;
			PlayerPrefs.SetInt(videoHash + 2, full);
#else
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(videoDataPath);
			
			VideoData data = new VideoData(resolutionIndex, qualityIndex, fullscreen);

			bf.Serialize(file, data);
			file.Close();
#endif
		}
	}
}
