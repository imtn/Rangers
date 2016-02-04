using UnityEngine;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class that handles player specific components of the controller
    /// Uses input
    /// </summary>
    public class PlayerController : Controller
    {
		//has the player drawn the bow back, and is ready to fire?
		private bool fire;

		//did the joystick overshoot the deadzone, triggering a fire?
		private bool definitelyFire;

		//used to help check for overshooting the joystick deadzone
		Vector3 prevAim = Vector3.zero;

		//locking the maximum fire rate for anyone spamming the joystick or any accidental input
		private const float MAX_FIRE_RATE = 0.5f;
		private float fireRateTimer = 0;

        void Update()
        {
			//updating fireRateTimer
			fireRateTimer += Time.deltaTime;

			//keeping track of this every frame to help prevent accidental fires or mis-aiming
			Vector3 aim = Vector3.Normalize(Vector3.Normalize(new Vector3(
				-InputManager.GetAxis("LookHorizontal_P" + (int)id, id),
				-InputManager.GetAxis("LookVertical_P" + (int)id, id),
				0))) * distanceToPlayer;

			//checking to see if the joystick overshot the deadzone, and setting a boolean appropriately
			definitelyFire = false;
			if((prevAim.x != 0 && prevAim.y != 0) && (Mathf.Sign(prevAim.x) != Mathf.Sign(aim.x) || Mathf.Sign(prevAim.y) != Mathf.Sign(aim.y))) {
				definitelyFire = true;
			}

			//updating the previous aim variable
			prevAim = aim;

			if (InputManager.GetButtonDown("Jump_P" + (int)id, id)) parkour.Jump();
			if (InputManager.GetButtonDown("Crouch_P" + (int)id, id)) parkour.SlideOn();
			if (InputManager.GetButtonUp("Crouch_P" + (int)id, id)) parkour.SlideOff();

            // Checking to see if the player can fire by checking the following:
			// is the fire rate timer past the max fire rate
			// are we firing due to a joystick error? (definitelyFire)
			// are we firing due to a regular release of the joystick (fire ...)
			if (fireRateTimer > MAX_FIRE_RATE &&
					(definitelyFire ||
					(fire && Mathf.Abs(InputManager.GetAxis("LookHorizontal_P" + (int)id, id)) < 0.1f && Mathf.Abs(InputManager.GetAxis("LookVertical_P" + (int)id, id)) <= 0.1f)))
            {
                archery.Fire();
                fire = false;
				definitelyFire = false;
				fireRateTimer = 0;
            }
            else if(Mathf.Abs(InputManager.GetAxis("LookHorizontal_P" + (int)id, id)) >= 0.5f || Mathf.Abs(InputManager.GetAxis("LookVertical_P" + (int)id, id)) >= 0.5f)
            {
				//if the joystick is pushed past the 50% mark in any direction, start aiming the bow
                archery.UpdateFirePoint(aim);
                fire = true;
            }
			else
			{
				//if the joystick isn't pushed in any direction then align the upper body with the legs
				archery.AimUpperBodyWithLegs();
			}
        }

		void FixedUpdate() {
			//This has to happen every fixed update as of now, can't think of a better way to handle it --kartik
			if(life.Health > 0) {
				parkour.Locomote(InputManager.GetAxis("Horizontal_P" + (int)id, id));
			}
		}
    }
}
