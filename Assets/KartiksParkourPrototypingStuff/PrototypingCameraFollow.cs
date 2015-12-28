using UnityEngine;
using System.Collections;

public class PrototypingCameraFollow : MonoBehaviour {

	public GameObject follow;
	public float speed;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - follow.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.MoveTowards(transform.position, follow.transform.position + offset, Time.deltaTime*speed);
	}
}
