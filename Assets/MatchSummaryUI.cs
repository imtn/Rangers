using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchSummaryUI : MonoBehaviour {

	public Text congratsText;

	// Use this for initialization
	void Start () {
		congratsText.text = ProfileManager.instance.GetProfile(MatchSummaryManager.winner).Name + " Wins!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
