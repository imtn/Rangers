using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.Data
{
	public class LoadManager : DataManager
	{
		private static LoadManager instance;

		protected override void Init()
		{
			if(instance == null)
			{
				DontDestroyOnLoad(gameObject);
				instance = this;
			}
			else if (instance != this)
			{
				Destroy(gameObject);
			}
		}

		public static AudioData LoadAudio()
		{
			AudioData data = new AudioData();
#if UNITY_WEBPLAYER

			if(PlayerPrefs.HasKey(audioHash + 0))
			{
				data.SFXVol = PlayerPrefs.GetFloat(audioHash + 0);
				data.MusicVol = PlayerPrefs.GetFloat(audioHash + 1);
			}
			else
			{
				SaveManager.SaveAudio(1f, 1f);
			}
			return data;
#else

			if(File.Exists(audioDataPath))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(audioDataPath, FileMode.Open);

				data = (AudioData)bf.Deserialize(file);

				file.Close();

				return data;
			}
			else
			{
				AudioData newData = new AudioData();
				SaveManager.SaveAudio(1f, 1f);
				return newData;
			}
#endif
		}

		public static VideoData LoadVideo()
		{
			VideoData data = new VideoData();
#if UNITY_WEBPLAYER

			if(PlayerPrefs.HasKey(videoHash + 0))
			{
				data.ResolutionIndex = PlayerPrefs.GetInt(videoHash + 0);
				data.QualityIndex = PlayerPrefs.GetInt(videoHash + 1);
				int full = PlayerPrefs.GetInt(videoHash + 2);
				data.Fullscreen = (full == 1) ? true : false;
			}
			else
			{
				SaveManager.SaveVideo(data.ResolutionIndex, data.QualityIndex, data.Fullscreen);
			}
			return data;
#else

			if(File.Exists(videoDataPath))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(videoDataPath, FileMode.Open);
				
				data = (VideoData)bf.Deserialize(file);
				
				file.Close();
				
				return data;
			}
			else
			{
				VideoData newData = new VideoData();
				SaveManager.SaveVideo(data.ResolutionIndex, data.QualityIndex, data.Fullscreen);
				return newData;
			}
#endif
		}
	}
}