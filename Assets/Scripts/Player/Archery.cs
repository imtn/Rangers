using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Timers;
using Assets.Scripts.Tokens;
using Assets.Scripts.Util;

/// <summary>
/// This class handles all the shooting that can be done by actors
/// </summary>
namespace Assets.Scripts.Player
{
	public class Archery : ControllerObject
	{
        [SerializeField]
        private GameObject arrowPrefab;
        [SerializeField]
        private Transform firePoint;

		private bool upperBodyFacingRight = true;

        // All the token timers running
        private List<TokenTimer> timers;

        // The current types of arrows to fire
        private int types = 1;

		// Force with which the arrow will be shot
		// based on how long the player has been aiming in approximately the same direction
		private float strength;

		private const float MAX_STRENGTH = 1;

		// So that the arrow fires realistically from the bow --kartik
		public Transform bowPosition;


        void Awake()
        {
            timers = new List<TokenTimer>();
			firePoint.localPosition = Vector3.right;
        }

        // Fires an arrow
        public void Fire()
        {
			GameObject arrow = (GameObject)Instantiate(arrowPrefab, firePoint.position + (Vector3.up*0.5f), firePoint.rotation);
			arrow.GetComponent<Rigidbody>().AddRelativeForce((firePoint.position - bowPosition.position) * 20 * (strength+0.1f), ForceMode.Impulse);
            arrow.GetComponent<Arrows.ArrowController>().InitArrow(types, controller.ID);
			strength = 0;
        }

        /// <summary>
        /// Sets the firepoint for the player
        /// </summary>
        /// <param name="position">Position where the firepoint is set to</param>
        public void UpdateFirePoint(Vector3 position)
        {
			if(Vector3.Distance(firePoint.localPosition, position) < 0.05f) {
				IncreaseStrength();
			}
            firePoint.localPosition = position;
        }

		private void IncreaseStrength() {
			strength = Mathf.Min(MAX_STRENGTH,strength+(Time.deltaTime));
		}

		public void UpdateBodyAim() {
			bowPosition.localRotation = Quaternion.identity;
			float angle = Mathf.Atan((firePoint.position.y-bowPosition.position.y)/(firePoint.position.x-bowPosition.position.x))*Mathf.Rad2Deg;
			if(firePoint.position.x < bowPosition.position.x) {
				upperBodyFacingRight = false;
			} else {
				upperBodyFacingRight = true;
			}

			if(upperBodyFacingRight && GetComponent<Parkour>().FacingRight) {
				bowPosition.Rotate(new Vector3(0f,0f,Mathf.Max(angle,-45f)), Space.World);
				UpdateTorsoAim(Mathf.Clamp01(strength));
			} else if(!upperBodyFacingRight && !GetComponent<Parkour>().FacingRight) {
				bowPosition.Rotate(new Vector3(0f,0f,Mathf.Min(angle,45f)), Space.World);
				UpdateTorsoAim(Mathf.Clamp01(strength));
			} else if(upperBodyFacingRight && !GetComponent<Parkour>().FacingRight) {
				bowPosition.Rotate(new Vector3(0f,180f,Mathf.Min(-angle,45f)), Space.World);
				UpdateTorsoAim(-Mathf.Clamp01(strength));
			} else if(!upperBodyFacingRight && GetComponent<Parkour>().FacingRight) {
				bowPosition.Rotate(new Vector3(0f,180f,Mathf.Max(-angle,-45f)), Space.World);
				UpdateTorsoAim(-Mathf.Clamp01(strength));
			}

			GetComponent<Animator>().SetFloat("BowStrength",strength);

		}


		void LateUpdate() {
			UpdateBodyAim();
		}

		public void AimUpperBodyWithLegs() {
			if(GetComponent<Parkour>().FacingRight) {
				firePoint.localPosition = Vector3.right;
			} else {
				firePoint.localPosition = Vector3.left;
			}
		}

		private void UpdateTorsoAim(float val) {
			if(val > 0) {
				bowPosition.Rotate(new Vector3(0f,Mathf.Max(0.5f, val)*90f,0f), Space.Self);
			} else if (val < 0) {
				bowPosition.Rotate(new Vector3(0f,Mathf.Max(0.5f, -val)*90f,0f), Space.Self);
			}
		}

        /// <summary>
        /// Called by colliding with a Token (from Token's OnTriggerEnter)
        /// </summary>
        /// <param name="token">Token that was collected</param>
        public override void CollectToken(Token token)
        {
            // Handle what type of token was collected
            if (token.GetType().Equals(typeof(ArrowToken)))
            {
                // Find the running timer associated with the token
                TokenTimer t = timers.Find(i => i.ID.Equals(((ArrowToken)token).Type.ToString()));
                // If the token has not been collected yet
                if (t == null)
                {
                    // Add a new Token Timer and initialize it
                    TokenTimer tt = gameObject.AddComponent<TokenTimer>();
                    tt.Initialize(TokenTimer.TOKEN_INTERVAL, ((ArrowToken)token).Type.ToString());
                    // Make sure that the token is removed from the component when the timer times out
                    tt.TimeOut += new TokenTimer.TimerEvent(RemoveToken);
                    types = Bitwise.SetBit(types, (int)tt.TokenType);
                    timers.Add(tt);
                }
                else
                {
                    // Token has already been collected so we just need to reset the timer
                    t.Reset();
                }
            }
        }

        // Removes the token from the types the player has collected
        private void RemoveToken(TokenTimer tt)
        {
            // Clear the appropriate token bit and remove the timer from the list of running timers
            types = Bitwise.ClearBit(types, (int)tt.TokenType);
            TokenTimer t = timers.Find(i => i.ID.Equals(tt.TokenType.ToString()));
            timers.Remove(t);
        }

        /// <summary>
        /// Removes all active tokens from the player so shooting an arrow is only the normal arrow
        /// </summary>
        public void ClearAllTokens()
        {
            foreach (TokenTimer t in timers)
            {
                types = Bitwise.ClearBit(types, (int)t.TokenType);
                Destroy(t);
            }
            timers.Clear();
        }

		public float StrengthPercentage {
			get {
				return strength/MAX_STRENGTH;
			}
		}

		public bool UpperBodyFacingRight {
			get {
				return upperBodyFacingRight;
			}
		}
	}
}
