using UnityEngine;
using System.Collections;
using Assets.Scripts.Util;

public class MapSelector : MonoBehaviour {

	public bool arenaSelector;

	public int currentSelectedMap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextMap() {
		currentSelectedMap = (currentSelectedMap + 1) % (arenaSelector ? ((int)Enums.BattleStages.NumStages) : ((int)Enums.TargetPracticeStages.NumStages));
	}

	public void PrevMap() {
		currentSelectedMap = (currentSelectedMap - 1) % (arenaSelector ? ((int)Enums.BattleStages.NumStages) : ((int)Enums.TargetPracticeStages.NumStages));
		currentSelectedMap = Mathf.Abs(currentSelectedMap);
	}
}
