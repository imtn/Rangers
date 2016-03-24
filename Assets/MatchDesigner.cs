using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Util;

public class MatchDesigner : MonoBehaviour {

	public ValueModifierUI kills, stock, time;
	public Text matchType;

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
		settings.KillLimit = kills.value;
		settings.StockLimit = stock.value;
		settings.TimeLimit = time.value;
		settings.Type = (Enums.GameType)System.Enum.Parse(typeof(Enums.GameType),matchType.text);
		return settings;
	}
}
