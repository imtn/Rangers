using UnityEngine;

namespace Assets.Scripts.Data
{
    /* 
     * This class is the parent for saving data and will hold all the paths necessary to save and load data
     */
	public abstract class DataManager : MonoBehaviour
	{
        // Can't save data to disk on web, so for now using playerprefs instead
#if UNITY_WEBPLAYER
		protected static string audioHash = "Rangers Audio";
		protected static string videoHash = "Rangers Video";
#else
		protected static string audioDataPath;
		protected static string videoDataPath;
        protected static string settingsDataPath;
#endif

        // Call init on awake to initialize everything
		void Awake()
		{
            audioDataPath = Application.persistentDataPath + "/Audio.dat";
            videoDataPath = Application.persistentDataPath + "/Video.dat";
            settingsDataPath = Application.persistentDataPath + "/GameSettings/";

            Init();
		}

        // Abstract method for children to set themselves up
		protected abstract void Init();
	}
}
