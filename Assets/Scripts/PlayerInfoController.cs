using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Data;

public class PlayerInfoController : MonoBehaviour 
{

	private GameObject timerUI;
	private string prevTimeText;

	private float startingAnimationSpeed = 2f;
	private float startingAnimGoalValue;

	private GameObject PlayerInfoBlocksContainer;

	private GameObject PlayerInfoBlock1, PlayerInfoBlock2, PlayerInfoBlock3, PlayerInfoBlock4;

	// Use this for initialization
	void Start () 
	{
		timerUI = transform.FindChild("TimerContainer").FindChild("TimerText").gameObject;
		PlayerInfoBlocksContainer = transform.FindChild("PlayerInfoBlocksContainer").gameObject;
		PlayerInfoBlock1 = PlayerInfoBlocksContainer.transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ControllerManager.instance.NumPlayers > 1 && PlayerInfoBlock2 == null) 
		{
			PlayerInfoBlock2 = (GameObject)(GameObject.Instantiate(PlayerInfoBlock1,Vector3.zero,Quaternion.identity));
			PlayerInfoBlock2.GetComponent<RectTransform>().SetParent(PlayerInfoBlock1.transform.parent,false);
			PlayerInfoBlock2.GetComponent<RectTransform>().anchoredPosition = new Vector2(PlayerInfoBlock1.GetComponent<RectTransform>().sizeDelta.x/2f,0f);
			PlayerInfoBlock1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-PlayerInfoBlock1.GetComponent<RectTransform>().sizeDelta.x/2f,0f);
			PlayerInfoBlock2.GetComponent<InGamePlayerInfoUI>().id = PlayerID.Two;
		}
		if(ControllerManager.instance.NumPlayers > 2 && PlayerInfoBlock3 == null) 
		{
			PlayerInfoBlock3 = (GameObject)(GameObject.Instantiate(PlayerInfoBlock1,Vector3.zero,Quaternion.identity));
			PlayerInfoBlock3.GetComponent<RectTransform>().SetParent(PlayerInfoBlock1.transform.parent,false);
			PlayerInfoBlock3.GetComponent<RectTransform>().anchoredPosition = new Vector2(PlayerInfoBlock1.GetComponent<RectTransform>().sizeDelta.x,0f);
			PlayerInfoBlock2.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f,0f);
			PlayerInfoBlock1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-PlayerInfoBlock1.GetComponent<RectTransform>().sizeDelta.x,0f);
			PlayerInfoBlock3.GetComponent<InGamePlayerInfoUI>().id = PlayerID.Three;
		}


		//Handles time UI updating
		if(GameManager.instance.CurrentTime != -1f) {
			int tempVal = (int)GameManager.instance.CurrentTime;
			int tempValMod = tempVal%60;
			timerUI.GetComponent<Text>().text = ((int)(tempVal/60f)) + ":" + (tempValMod < 10 && tempValMod > 0 ? "0" + tempValMod : (tempValMod == 0 ? "00" : tempValMod+""));
			if(!timerUI.GetComponent<Text>().text.Equals(prevTimeText)) {
				foreach(DelayedTextCopy dtc in timerUI.transform.GetComponentsInChildren<DelayedTextCopy>())
					dtc.CopyText();
			}
			if(tempVal < 20) {
				if(tempVal % 2 == 0) timerUI.GetComponent<Text>().color = Color.red;
				else timerUI.GetComponent<Text>().color = Color.white;
			}
			if(tempVal < 10) {
				timerUI.transform.localScale = Vector3.one*(Mathf.Sin(Time.time*2f)+2)*0.5f;
				timerUI.GetComponent<Text>().color = Color.red;
			}
			prevTimeText = timerUI.GetComponent<Text>().text;
		} else {
			timerUI.transform.parent.gameObject.SetActive(false);
		}

	}
}
