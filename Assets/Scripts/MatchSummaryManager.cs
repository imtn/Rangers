using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MatchSummaryManager : MonoBehaviour {

	public static PlayerID winner;

	public static List<PlayerID> others;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}

	void OnLevelWasLoaded(int level) {
		if (SceneManager.GetActiveScene().name.Equals("MatchSummary")) {
			GameObject winnerObj = GameObject.Find("Player_Cosmetic_Winner");
			winnerObj.GetComponent<CosmeticPlayer>().id = winner;

			GameObject p2 = GameObject.Find("Player_Cosmetic (1)");
			GameObject p3 = GameObject.Find("Player_Cosmetic (2)");
			GameObject p4 = GameObject.Find("Player_Cosmetic (3)");
			
			p2.GetComponent<CosmeticPlayer>().id = others[0];

			if(others.Count > 1) {
				p3.GetComponent<CosmeticPlayer>().id = others[1];
			} else {
				p3.SetActive(false);
			}

			if(others.Count > 2) {
				p4.GetComponent<CosmeticPlayer>().id = others[2];
			} else {
				p4.SetActive(false);
			}

		} else {
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
