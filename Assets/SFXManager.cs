using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {

	public AudioClip[] whoosh;

	public AudioClip affirm;

	public static SFXManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		if(instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
