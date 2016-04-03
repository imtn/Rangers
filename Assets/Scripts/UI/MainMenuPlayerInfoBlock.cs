using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuPlayerInfoBlock : MonoBehaviour {

	public PlayerID playerID;

	private Text tagText;
	//private Image tagBG;
	private GameObject pressToJoin;
	private GameObject pressToOpen;
	private GameObject nameCreator;
	private Image playerNumIndicator;


	// Use this for initialization
	void Start () {
		tagText = transform.FindChild("TagBox").FindChild("PlayerTag").GetComponent<Text>();
		//tagBG = transform.FindChild("TagBox").GetComponent<Image>();
		pressToJoin = transform.FindChild("PressToJoin").gameObject;
		pressToOpen = transform.FindChild("StartToOpen").gameObject;
		nameCreator = transform.FindChild("NameCreator").gameObject;
		playerNumIndicator = transform.FindChild("Player" + (int)playerID + "Indicator").GetChild((int)playerID - 1).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(nameCreator.activeInHierarchy) {
			if(ControllerManager.instance.GetButtonDown(ControllerInputWrapper.Buttons.Start,playerID)
				&& tagText.text.Length > 0 && tagText.text.ToCharArray()[tagText.text.Length-1] != ' ') {
				ProfileManager.instance.AddProfile(new ProfileData(tagText.text), playerID);
				HideNameCreator();
				playerNumIndicator.color = Color.white;
			}
		}
	}

	public void PlayerAdded() {
		if(ProfileManager.instance.ProfileExists(playerID)) {
			SetTag(ProfileManager.instance.GetProfile(playerID).Name);
			HidePressToJoinGraphic();
			playerNumIndicator.color = Color.white;
		} else {
			ShowNameCreator();
		}
	}

	/// <summary>
	/// Adds an AI player to the block.
	/// </summary>
	public void AIAdded() {
		SetTag("AI " + (int)playerID);
		ProfileManager.instance.AddProfile(new ProfileData(tagText.text), playerID);
		HidePressToJoinGraphic();
		playerNumIndicator.color = Color.white;
	}

	/// <summary>
	/// Removes the player from the block.
	/// </summary>
	public void PlayerRemoved() {
		SetTag("####");
		ProfileManager.instance.RemoveProfile(playerID);
		ShowPressToJoinGraphic();
		playerNumIndicator.color = Color.red;
	}

	/// <summary>
	/// Shows the join graphic on the block.
	/// </summary>
	public void ShowPressToJoinGraphic() {
		pressToJoin.SetActive(true);
		pressToOpen.SetActive(false);
	}

	public void HidePressToJoinGraphic() {
		pressToJoin.SetActive(false);
		pressToOpen.SetActive(true);
	}

	public void SetTag(string text) {
		tagText.text = text;
	}

	public void ShowNameCreator() {
		nameCreator.SetActive(true);
		pressToJoin.SetActive(false);
		SetTag("");
	}

	public void HideNameCreator() {
		nameCreator.SetActive(false);
		pressToOpen.SetActive(true);
	}

	/// <summary>
	/// Checks if a name is currently being chosen in the block.
	/// </summary>
	/// <returns>Whether a name is currently being chosen in the block.</returns>
	public bool ChoosingName() {
		return nameCreator.activeInHierarchy;
	}
}
