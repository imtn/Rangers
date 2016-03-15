using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;

public class RobotBodyPart : MonoBehaviour 
{

	public GameObject copy;
	private Rigidbody rb;
	private BoxCollider bc;
	public PlayerID pid;
	private bool respawning;

	/// <summary> The speed that the body part is moving at. </summary>
	private float moveSpeed;

	// Use this for initialization
	void Start () 
	{
		//gets playerID from parent
		pid = transform.root.GetComponent<Controller>().ID;

		//creates copy and disables
		copy = (GameObject)GameObject.Instantiate(this.gameObject,transform.position,transform.rotation);
		Destroy(copy.GetComponent<RobotBodyPart>());
		rb = copy.AddComponent<Rigidbody>();
		bc = copy.AddComponent<BoxCollider>();
		copy.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(respawning)
		{
			copy.transform.position = Vector3.MoveTowards(copy.transform.position, transform.position, Time.deltaTime*(moveSpeed+Vector3.Distance(copy.transform.position,transform.position)));
			copy.transform.rotation = Quaternion.RotateTowards(copy.transform.rotation, transform.rotation, Time.deltaTime*90f);
			moveSpeed += 0.3f;
			if(Vector3.Distance(copy.transform.position,transform.position) < 0.01f)
			{ 
				respawning = false;
				GetComponent<MeshRenderer>().enabled = true;
				copy.gameObject.SetActive(false);
			}
		}
	}

	public void DestroyBody() 
	{
		respawning = false;
		//move the body parts to where the players body is/was
		//I don't know why I have to check to see if copy is null but for some reason some of them are null and idk why
		if(copy != null) 
		{
			bc.enabled = true;
			rb.isKinematic = false;
			GetComponent<MeshRenderer>().enabled = false;
			copy.gameObject.SetActive(true);
			copy.transform.position = transform.position;
			copy.transform.rotation = transform.rotation;
		}
	}

	public void RespawnBody()
	{
		if(copy != null)
		{
			bc.enabled = false;
			rb.isKinematic = true;
			respawning = true;
			moveSpeed = 1;
		}
	}
}
