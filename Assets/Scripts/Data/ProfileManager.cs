using UnityEngine;
using System.Collections.Generic;

public class ProfileManager : MonoBehaviour {

	private Dictionary<PlayerID,ProfileData> loadedProfiles;

	public static ProfileManager instance;

	// Use this for initialization
	void Start () {
		if(instance == null) {
			instance = this;
			loadedProfiles = new Dictionary<PlayerID, ProfileData>();
		} else if (instance != this) {
			Destroy(this);
		}
	}

	public void AddProfile(ProfileData data, PlayerID id = PlayerID.One) {
		loadedProfiles.Add(id,data);
	}

	public ProfileData GetProfile(PlayerID id) {
		return loadedProfiles[id];
	}

	public bool ProfileExists(PlayerID id) {
		return loadedProfiles.ContainsKey(id);
	}

    public int NumSignedIn()
    {
        return loadedProfiles.Count;
    }
}
