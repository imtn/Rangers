using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Class will load in data from player prefs or from disk
    /// </summary>
    public class LoadManager : DataManager
	{
        /// <summary>
        ///  Use a singleton instance to make sure there is only one
        /// </summary>
		public static LoadManager instance;

        // Sets up singleton instance. Will remain if one does not already exist in scene
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

        /// <summary>
        /// Loads the audio data for this game
        /// </summary>
        /// <returns>The audio settings saved to disk or player prefs</returns>
		public static AudioData LoadAudio()
		{
            // Get a default audiodata in case none exists
			AudioData data = new AudioData();
#if UNITY_WEBPLAYER
            // If there is data related to audio, get those values
			if(PlayerPrefs.HasKey(audioHash + 0))
			{
				data.SFXVol = PlayerPrefs.GetFloat(audioHash + 0);
				data.MusicVol = PlayerPrefs.GetFloat(audioHash + 1);
                data.VoiceVol = PlayerPrefs.GetFloat(audioHash + 2);
			}
            // Otherwise save the default data
			else
			{
				SaveManager.SaveAudio(new AudioData());
			}
			return data;
#else
            // If a file exists
            if (File.Exists(audioDataPath))
			{
                // Open the file and get all the data from the file to load
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(audioDataPath, FileMode.Open);

				data = (AudioData)bf.Deserialize(file);

				file.Close();

				return data;
			}
            // No file exists, so save the default data
			else
			{
				SaveManager.SaveAudio(data);
				return data;
			}
#endif
		}

        /// <summary>
        /// Loads the video data for this game
        /// </summary>
        /// <returns>The video settings saved to disk or player prefs</returns>
		public static VideoData LoadVideo()
		{
            // Get a default videodata in case none exists
            VideoData data = new VideoData();
#if UNITY_WEBPLAYER
            // If there is data related to video, get those values
			if(PlayerPrefs.HasKey(videoHash + 0))
			{
				data.ResolutionIndex = PlayerPrefs.GetInt(videoHash + 0);
				data.QualityIndex = PlayerPrefs.GetInt(videoHash + 1);
				int full = PlayerPrefs.GetInt(videoHash + 2);
				data.Fullscreen = (full == 1) ? true : false;
			}
            // Otherwise save the default data
			else
			{
				SaveManager.SaveVideo(new VideoData());
			}
			return data;
#else
            // If a file exists
            if (File.Exists(videoDataPath))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(videoDataPath, FileMode.Open);
				
				data = (VideoData)bf.Deserialize(file);
				
				file.Close();
				
				return data;
			}
            // No file exists, so save the default data
            else
            {
				SaveManager.SaveVideo(data);
				return data;
			}
#endif
		}

        /// <summary>
        /// Loads the game settings from a certain file
        /// </summary>
        /// <param name="extension">The extension where the desired settings are saved</param>
        /// <returns>The certain game settings at a specific location</returns>
        public static GameSettings LoadGameSettings(string extension)
        {
            // Get a default settings in case none exists
            GameSettings data = new GameSettings();
            // If a file exists
            if (File.Exists(settingsDataPath + extension))
            {
                // Open the file and get all the data from the file to load
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(settingsDataPath + extension, FileMode.Open);

                data = (GameSettings)bf.Deserialize(file);

                file.Close();

                return data;
            }
            // No file exists, so save the default data
            else
            {
                SaveManager.SaveGameSettings(data, extension);
                return data;
            }
        }
    }
}