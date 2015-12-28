using UnityEngine;
using System.Collections;
using TeamUtility.IO;

public class PrototypingGamepadParkour : MonoBehaviour {

	private float charmotion = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(InputManager.GetButtonDown("Jump")) {
			GetComponent<RobotParkour>().Jump();
		}
		if(InputManager.GetButtonDown("Cancel")) {
			GetComponent<RobotParkour>().SlideOn();
		}
		if(InputManager.GetButtonUp("Cancel") || !InputManager.GetButton("Cancel")) {
			GetComponent<RobotParkour>().SlideOff();
		}

		charmotion = Mathf.MoveTowards(charmotion, InputManager.GetAxis("Horizontal"), Time.deltaTime*4f);

		GetComponent<RobotParkour>().Locomote(charmotion);

	}
}
