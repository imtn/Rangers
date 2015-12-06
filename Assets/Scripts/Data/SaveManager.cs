using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.Data
{
    /*
     * This class will save all the data for the game
     */
	public class SaveManager : DataManager
	{
        // Use a singleton instance to make sure there is only one
        public static SaveManager instance;

        // Sets up singleton instance. Will remain if one does not already exist in scene
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

        // Saves the audio settings for this game
		public static void SaveAudio(AudioData data)
		{
#if UNITY_WEBPLAYER
            // Set appropriate hash values
			PlayerPrefs.SetFloat(audioHash + 0, data.SFXVol);
			PlayerPrefs.SetFloat(audioHash + 1, data.MusicVol);
            PlayerPrefs.SetFloat(audioHash + 2, data.VoiceVol);
#else
            // Create a new save file
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(audioDataPath);

			bf.Serialize(file, data);
			file.Close();
#endif
		}

        // Saves the video settings for this game
        public static void SaveVideo(VideoData data)
		{
#if UNITY_WEBPLAYER
            // Set appropriate hash values
			PlayerPrefs.SetInt(videoHash + 0, data.ResolutionIndex);
			PlayerPrefs.SetInt(videoHash + 1, data.QualityIndex);
			int full = data.Fullscreen ? 1 : 0;
			PlayerPrefs.SetInt(videoHash + 2, full);
#else
            // Create a new save file
            BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(videoDataPath);
			
			bf.Serialize(file, data);
			file.Close();
#endif
		}
	}
}
