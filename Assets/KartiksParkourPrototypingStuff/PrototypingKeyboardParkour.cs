using UnityEngine;
using System.Collections;

public class PrototypingKeyboardParkour : MonoBehaviour {

	private float charmotion = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)) {
			charmotion = Mathf.MoveTowards(charmotion, -1, Time.deltaTime*2f);
			if(charmotion > 0) {
				charmotion = Mathf.MoveTowards(charmotion, -1, Time.deltaTime*2f);
			}
		} else if (Input.GetKey(KeyCode.D)) {
			charmotion = Mathf.MoveTowards(charmotion, 1, Time.deltaTime*2f);
			if(charmotion < 0) {
				charmotion = Mathf.MoveTowards(charmotion, 1, Time.deltaTime*2f);
			}
		} else {
			charmotion = Mathf.MoveTowards(charmotion, 0, Time.deltaTime*4f);
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
//			GetComponent<RobotParkour>().Jump();
		}

//		GetComponent<RobotParkour>().Locomote(charmotion);

	}
}
