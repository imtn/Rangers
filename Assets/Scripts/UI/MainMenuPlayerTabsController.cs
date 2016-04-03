using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuPlayerTabsController : MonoBehaviour {

	private MainMenuPlayerInfoBlock infoBlock1, infoBlock2, infoBlock3, infoBlock4;

	/// <summary> The timer to delay adding AI players. </summary>
	private float aiAddTimer;
	/// <summary> Delay before another AI player can be added. </summary>
	private float AIADDDELAY = 0.15f;

	// Use this for initialization
	void Start () {
		infoBlock1 = transform.GetChild(0).GetComponent<MainMenuPlayerInfoBlock>();
		infoBlock2 = transform.GetChild(1).GetComponent<MainMenuPlayerInfoBlock>();
		infoBlock3 = transform.GetChild(2).GetComponent<MainMenuPlayerInfoBlock>();
		infoBlock4 = transform.GetChild(3).GetComponent<MainMenuPlayerInfoBlock>();

		infoBlock1.PlayerAdded();
	}
	
	// Update is called once per frame
	void Update () {
		if(ControllerManager.instance.AddPlayer(ControllerInputWrapper.Buttons.Start)) {
			if(ControllerManager.instance.NumPlayers == 2) {
				infoBlock2.PlayerAdded();
			}
			if(ControllerManager.instance.NumPlayers == 3) {
				infoBlock3.PlayerAdded();
			}
			if(ControllerManager.instance.NumPlayers == 4) {
				infoBlock4.PlayerAdded();
			}
		} else if(aiAddTimer <= 0 && ControllerManager.instance.AddAI(ControllerInputWrapper.Buttons.RightBumper)) {
			if(ControllerManager.instance.NumPlayers == 2) {
				infoBlock2.AIAdded();
			}
			if(ControllerManager.instance.NumPlayers == 3) {
				infoBlock3.AIAdded();
			}
			if(ControllerManager.instance.NumPlayers == 4) {
				infoBlock4.AIAdded();
			}
			aiAddTimer = AIADDDELAY;
		}
		aiAddTimer -= Time.deltaTime;
	}
}
