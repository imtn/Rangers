using UnityEngine;
using Assets.Scripts.Tokens;

/*
 * This abstract class will be what all player conponents use for the controller to control them
 */
namespace Assets.Scripts.Player
{
	public abstract class PlayerControllerObject : MonoBehaviour
	{
		// Reference to the player controller
		protected PlayerController controller;

		// Abstract methods children need to implement
		public abstract void Run();
		public abstract void FixedRun();

        // Virtual method for collecting battle tokens
        public virtual void CollectToken(Token token) { }

        // Property for the controller
        public PlayerController Controller
		{
			get { return controller; }
            set { controller = value; }
		}

		// Method to broadcast to the controller to all components
		protected void AssignController(PlayerController controller)
		{
			this.controller = controller;
		}
	}
}
