using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

public class PrototypingCameraFollow : MonoBehaviour {

	public float speed;

	private Vector3 offset;
	private int numPlayers;
	private float greatestDistance;

	// Use this for initialization
	void Start () {
		numPlayers = GameManager.instance.AllPlayers.Count;
		Debug.Log(numPlayers);
//		offset = transform.position - follow.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		transform.position = Vector3.MoveTowards(transform.position, follow.transform.position + offset, Time.deltaTime*speed);
		Vector3 averagePosition = Vector3.zero;
		for(int i = 0; i < numPlayers; i++) {
			averagePosition += GameManager.instance.AllPlayers[i].transform.position + (Vector3.up*2f);
		}

		averagePosition /= numPlayers;

		for(int i = 0; i < numPlayers; i++) {
			float tempDist = Vector3.Distance(GameManager.instance.AllPlayers[i].transform.position, averagePosition);
			if(tempDist > greatestDistance) {
				tempDist = greatestDistance;
			}
		}

		transform.position = Vector3.MoveTowards(transform.position, new Vector3(averagePosition.x, averagePosition.y, -5*(greatestDistance+1)), Time.deltaTime*speed);

	}
}
