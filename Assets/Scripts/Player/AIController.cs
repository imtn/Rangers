using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
	/// <summary>
	/// Interface for AI to control a character.
	/// </summary>
	public class AIController : Controller {

		/// <summary>
		/// The speed that the character is moving at.
		/// </summary>
		[SerializeField]
		private float runSpeed = 0;

		/// <summary>
		/// Whether the character is jumping.
		/// </summary>
		[SerializeField]
		private bool jump = false;
		/// <summary>
		/// Whether the character is sliding.
		/// </summary>
		[SerializeField]
		private bool slide = false;

		/// <summary>
		/// Whether the character is aiming a shot.
		/// </summary>
		[SerializeField]
		private bool aiming = false;
		/// <summary>
		/// Whether the character was aiming its shot on the last tick.
		/// </summary>
		[SerializeField]
		private bool wasAiming = false;
		/// <summary>
		/// Vector in the direction that the character is aiming.
		/// </summary>
		[SerializeField]
		private Vector3 aim = Vector3.zero;
		
		// Update is called once per frame
		void Update () {

			if (jump) {
				parkour.Jump();
			}

			if (slide) {
				parkour.SlideOn();
			} else {
				parkour.SlideOff();
			}

			if (aiming) {
				archery.UpdateFirePoint(Vector3.Normalize(aim));
				wasAiming = true;
			} else if (wasAiming) {
				wasAiming = false;
				archery.Fire();
			} else {
				archery.AimUpperBodyWithLegs();
			}
		}

		void FixedUpdate() {
			if(life.Health > 0) {
				parkour.Locomote(runSpeed);
			}
		}
	}
}