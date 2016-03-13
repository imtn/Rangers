using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;
using Assets.Scripts.Util;

public class PermanentArrowTypeTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.instance.GetPlayer(PlayerID.One).ArcheryComponent.ArrowTypes = 
			Bitwise.SetBit(GameManager.instance.GetPlayer(PlayerID.One).ArcheryComponent.ArrowTypes, (int)Enums.Arrows.Fireball);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
