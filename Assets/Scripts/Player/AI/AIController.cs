using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

namespace Assets.Scripts.Player.AI
{
	/// <summary> Interface for AI to control a character. </summary>
	public class AIController : Controller
    {
		private IPolicy policy;

		/// <summary> The speed that the character is moving at. </summary>
		[SerializeField]
		public float runSpeed = 0;

		/// <summary> Whether the character is jumping. </summary>
		[SerializeField]
		public bool jump = false;
		/// <summary> Whether the character is sliding. </summary>
		[SerializeField]
		public bool slide = false;

		/// <summary> Whether the character is aiming a shot. </summary>
		[SerializeField]
		public bool aiming = false;
		/// <summary> Whether the character was aiming its shot on the last tick. </summary>
		private bool wasAiming = false;
		/// <summary> Vector in the direction that the character is aiming. </summary>
		[SerializeField]
		public Vector3 aim = Vector3.zero;

		/// <summary> The opponent of this character. </summary>
		public Controller opponent;

		/// <summary> Initializes the AI policy to use. </summary>
		void Start()
		{
			policy = new StandShoot();
			foreach (Controller controller in GameManager.instance.AllPlayers)
			{
				if (controller != this)
				{
					opponent = controller;
					break;
				}
			}
		}
		
		/// <summary> Moves the agent every tick. </summary>
		void Update()
		{
			policy.ChooseAction(this);

			if (jump)
			{
				parkour.Jump();
			}

			if (slide)
			{
				parkour.SlideOn();
			}
			else
			{
				parkour.SlideOff();
			}

			if (aiming)
			{
				archery.UpdateFirePoint(Vector3.Normalize(aim));
				wasAiming = true;
			}
			else if (wasAiming)
			{
				wasAiming = false;
				archery.Fire();
			}
			else
			{
				archery.AimUpperBodyWithLegs();
			}
		}

		/// <summary> Updates the player's running movement. </summary>
		void FixedUpdate()
		{
			if (life.Health > 0)
			{
				parkour.Locomote(runSpeed);
			}
		}
	}
}