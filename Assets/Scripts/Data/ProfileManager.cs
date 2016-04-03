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

	/// <summary>
	/// Removes the profile with the specified player ID.
	/// </summary>
	/// <param name="id">The ID of the player to remove.</param>
	public void RemoveProfile(PlayerID id) {
		loadedProfiles.Remove(id);
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

	/// <summary>
	/// Gets the ID of the next occupied profile.
	/// </summary>
	/// <returns>The ID of the next occupied profile.</returns>
	/// <param name="id">The current profile ID to get the next profile ID from.</param>
	public PlayerID GetNextProfile(PlayerID id) {
		if (id == PlayerID.Four) {
			return PlayerID.None;
		}
		PlayerID nextID = id;
		do {
			if (nextID == PlayerID.Four) {
				nextID = PlayerID.None;
				break;
			}
			nextID++;
		} while (!ProfileExists(nextID));
		return nextID;
	}
}
