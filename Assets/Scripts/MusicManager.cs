using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] tracks;
	private AudioSource player;
	private int currentTrack = 0;

	// Use this for initialization
	void Start () {
		player = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!player.isPlaying || ControllerManager.instance.GetButtonDown(ControllerInputWrapper.Buttons.RightStickClick)) {
			player.clip = tracks[(++currentTrack)%tracks.Length];
			player.Play();
		}
	}
}
