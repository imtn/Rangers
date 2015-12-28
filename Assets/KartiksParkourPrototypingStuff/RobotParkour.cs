using UnityEngine;
using System.Collections;

public class RobotParkour : MonoBehaviour {

	private bool facingRight = true;
	private bool jumping = false;
	private bool sliding = false;

	public GameObject IKThingy;

	private float slidingTime;
	private float lastMotion;

	public void Locomote(float motion) {

		if(motion > 0) {
			facingRight = true;
		} else if (motion < 0) {
			facingRight = false;
		}
		if(!sliding) {
			if(facingRight && Physics.Raycast(new Ray(transform.position, transform.forward),0.5f,~(1<<9))) {
				GetComponent<Animator>().SetFloat("RunSpeed", Mathf.Min(0,motion));
			} else if(!facingRight && Physics.Raycast(new Ray(transform.position, -transform.forward),0.5f,~(1<<9))) {
				GetComponent<Animator>().SetFloat("RunSpeed", Mathf.Max(0,motion));
			} else {
				GetComponent<Animator>().SetFloat("RunSpeed", motion);
				if(!jumping) {
					transform.Translate(Vector3.forward*motion*Time.deltaTime*8);
				} else {
					transform.Translate(Vector3.forward*motion*Time.deltaTime*4);
				}
			}
			lastMotion = motion;
		} else {
			GetComponent<Animator>().SetFloat("RunSpeed", 0);
		}

	}

	public void Jump() {
		if(!jumping) {
			GetComponent<Animator>().ResetTrigger("Land");
			if(facingRight) {
				GetComponent<Animator>().SetTrigger("Jump");
			} else if (!facingRight) {
				GetComponent<Animator>().SetTrigger("JumpLeft");
			}
			jumping = true;
		}
	}

	void Update() {
		if(GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("WalkRunRight -> Slide")
			|| GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("WalkRunLeft -> SlideLeft")) {
			sliding = true;
			transform.Translate(Vector3.forward*lastMotion*Time.deltaTime*8f);
			GetComponent<Rigidbody>().AddForce(Vector3.down*15f, ForceMode.Acceleration);
		} else if(GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("Slide -> WalkRunRight")) {
			sliding = false;
			transform.Translate(Vector3.forward*Time.deltaTime*8);
		} else if(GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("SlideLeft -> WalkRunLeft")) {
			sliding = false;
			transform.Translate(-Vector3.forward*Time.deltaTime*8);
		} else if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Slide") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SlideLeft")) {
			if(!GetComponent<Animator>().IsInTransition(0)) {
				transform.Translate(Vector3.forward*lastMotion*Time.deltaTime*10);
				GetComponent<Rigidbody>().AddForce(Vector3.down*10f, ForceMode.Acceleration);
			}
		}
	}

	public void SlideOn() {
		GetComponent<Animator>().SetBool("Slide", true);
	}

	public void SlideOff() {
		GetComponent<Animator>().SetBool("Slide", false);
//		slidingTime = 0f;
	}

	public void EnableLegColliders() {
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipLT").GetComponent<Collider>().enabled = true;
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipRT").GetComponent<Collider>().enabled = true;
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipLT/joint_KneeLT").GetComponent<Collider>().enabled = true;
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipRT/joint_KneeRT").GetComponent<Collider>().enabled = true;
	}

	public void DisableLegColliders() {
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipLT").GetComponent<Collider>().enabled = false;
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipRT").GetComponent<Collider>().enabled = false;
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipLT/joint_KneeLT").GetComponent<Collider>().enabled = false;
//		transform.FindChild("U/joint_Char/joint_Pelvis/joint_HipMaster/joint_HipRT/joint_KneeRT").GetComponent<Collider>().enabled = false;
	}

	void OnAnimatorIK() {
		if(Vector3.Distance(transform.position+Vector3.up, IKThingy.transform.position) < 1f) {
			GetComponent<Animator>().SetIKPosition(AvatarIKGoal.RightHand,IKThingy.transform.position + new Vector3(-0.5f,0,0));
			GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.RightHand,1);
			GetComponent<Animator>().SetIKPosition(AvatarIKGoal.LeftHand,IKThingy.transform.position + new Vector3(0.5f,0,0));
			GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
			jumping = false;
//			GetComponent<Rigidbody>().velocity = Vector3.zero;
		} else {
			GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.RightHand,0);
			GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
		}
	}

	public void JumpVelocity() {
		GetComponent<Rigidbody>().velocity = Vector3.up*7f;
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag.Equals("Ground")) {
			GetComponent<Animator>().SetTrigger("Land");
			jumping = false;
		}
	}
}
