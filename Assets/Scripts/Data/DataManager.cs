using UnityEngine;
using System;

namespace Assets.Scripts.Data
{
	public abstract class DataManager : MonoBehaviour
	{
#if UNITY_WEBPLAYER
		protected static string audioHash = "Rangers Audio";
		protected static string videoHash = "Rangers Video";
#else
		protected static string audioDataPath = Application.persistentDataPath + "/Audio.dat";
		protected static string videoDataPath = Application.persistentDataPath + "/Video.dat";
#endif

		void Awake()
		{
			Init();
		}

		protected abstract void Init();
	}

	[Serializable]
	public class VideoData
	{
		private int resolutionIndex;
		private int qualityIndex;
		private bool fullScreen;

		public VideoData()
		{
			resolutionIndex = 0;
			qualityIndex = 0;
			fullScreen = false;
		}

		public VideoData(int resolutionIndex, int qualityIndex, bool fullScreen)
		{
			this.resolutionIndex = resolutionIndex;
			this.qualityIndex = qualityIndex;
			this.fullScreen = fullScreen;
		}

		public int ResolutionIndex
		{
			get { return resolutionIndex; }
			set { resolutionIndex = value; }
		}
		public int QualityIndex
		{
			get { return qualityIndex; }
			set { qualityIndex = value; }
		}
		public bool Fullscreen
		{
			get { return fullScreen; }
			set { fullScreen = value; }
		}
	}

	[Serializable]
	public class AudioData
	{
		private float sfxVol;
		private float musicVol;

		public AudioData()
		{
			sfxVol = 1f;
			musicVol = 1f;
		}

		public AudioData(float sfxVol, float musicVol)
		{
			this.sfxVol = sfxVol;
			this.musicVol = musicVol;
		}
		
		public float SFXVol
		{
			get { return sfxVol; }
			set { sfxVol = value; }
		}
		public float MusicVol
		{
			get { return musicVol; }
			set { musicVol = value; }
		}
	}
}
