using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Util;

public class MapSelector : MonoBehaviour {

	public bool arenaSelector;

	public int currentSelectedMap;

	public Text mapTitle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(-1000*currentSelectedMap,0f),Time.deltaTime*Mathf.Abs((transform.localPosition.x+(1000*currentSelectedMap)))*2f);
	}

	public void NextMap() {
		currentSelectedMap = (currentSelectedMap + 1) % (arenaSelector ? ((int)Enums.BattleStages.NumStages) : ((int)Enums.TargetPracticeStages.NumStages));
		mapTitle.text = (arenaSelector ? ((Enums.BattleStages)currentSelectedMap).ToString() : ((Enums.TargetPracticeStages)currentSelectedMap).ToString());
		mapTitle.transform.GetChild(0).GetComponent<Text>().text = (arenaSelector ? ((Enums.BattleStages)currentSelectedMap).ToString() : ((Enums.TargetPracticeStages)currentSelectedMap).ToString());
		mapTitle.transform.GetChild(1).GetComponent<Text>().text = (arenaSelector ? ((Enums.BattleStages)currentSelectedMap).ToString() : ((Enums.TargetPracticeStages)currentSelectedMap).ToString());
	}

	public void PrevMap() {
		currentSelectedMap = (currentSelectedMap - 1) % (arenaSelector ? ((int)Enums.BattleStages.NumStages) : ((int)Enums.TargetPracticeStages.NumStages));
		currentSelectedMap = Mathf.Abs(currentSelectedMap);
		mapTitle.text = (arenaSelector ? ((Enums.BattleStages)currentSelectedMap).ToString() : ((Enums.TargetPracticeStages)currentSelectedMap).ToString());
		mapTitle.transform.GetChild(0).GetComponent<Text>().text = (arenaSelector ? ((Enums.BattleStages)currentSelectedMap).ToString() : ((Enums.TargetPracticeStages)currentSelectedMap).ToString());
		mapTitle.transform.GetChild(1).GetComponent<Text>().text = (arenaSelector ? ((Enums.BattleStages)currentSelectedMap).ToString() : ((Enums.TargetPracticeStages)currentSelectedMap).ToString());
	}
}
