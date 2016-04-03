using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuPlayerTabsController : MonoBehaviour {

	private MainMenuPlayerInfoBlock[] infoBlocks = new MainMenuPlayerInfoBlock[4];

	/// <summary> The timer to delay adding AI players. </summary>
	private float aiAddTimer;
	/// <summary> Delay before another AI player can be added. </summary>
	private float AIADDDELAY = 0.15f;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < infoBlocks.Length; i++) {
			infoBlocks[i] = transform.GetChild(i).GetComponent<MainMenuPlayerInfoBlock>();
		}

		infoBlocks[0].PlayerAdded();
	}
	
	// Update is called once per frame
	void Update () {
		if(ControllerManager.instance.AddPlayer(ControllerInputWrapper.Buttons.Start)) {
			infoBlocks[ControllerManager.instance.NumPlayers - 1].PlayerAdded();
		}
		int removedPlayer = ControllerManager.instance.AllowPlayerRemoval(ControllerInputWrapper.Buttons.Back);
		if(removedPlayer >= 1) {
			infoBlocks[removedPlayer - 1].PlayerRemoved();
		}
		if(aiAddTimer <= 0) {
			if(ControllerManager.instance.AddAI(ControllerInputWrapper.Buttons.RightBumper)) {
				infoBlocks[ControllerManager.instance.NumPlayers - 1].AIAdded();
				aiAddTimer = AIADDDELAY;
			}
			removedPlayer = ControllerManager.instance.AllowAIRemoval(ControllerInputWrapper.Buttons.LeftBumper);
			if(removedPlayer >= 1) {
				infoBlocks[removedPlayer - 1].PlayerRemoved();
				aiAddTimer = AIADDDELAY;
			}
		}

		aiAddTimer -= Time.deltaTime;
	}

	/// <summary>
	/// Gets the block with the given index.
	/// </summary>
	/// <returns>The block with the given index./returns>
	/// <param name="blockIndex">The index of the block to get.</param>
	public MainMenuPlayerInfoBlock GetBlock(int blockIndex) {
		return infoBlocks[blockIndex];
	}
}
