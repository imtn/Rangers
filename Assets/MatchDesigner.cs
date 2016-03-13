using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchDesigner : MonoBehaviour {

	public ValueModifierUI kills, stock, time;


//	private int killLimit, stockLimit;
//
//	private float timeLimit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Gets the current game settings set up by the current match designer.
	/// </summary>
	/// <returns>The game settings</returns>
	public GameSettings GetSettings() {
		GameSettings settings = new GameSettings();
		settings.Type = Assets.Scripts.Util.Enums.GameType.Deathmatch;
		settings.KillLimit = kills.value;
		return settings;
	}
}
