using UnityEngine;
using Assets.Scripts.Tokens;

namespace Assets.Scripts.Player
{
    /*
     * This abstract class will be what all player conponents use for the controller to control them
     */
    public abstract class ControllerObject : MonoBehaviour
	{
		// Reference to the player controller
		protected Controller controller;

        // Virtual method for collecting battle tokens
        public abstract void CollectToken(Token token);

        // Property for the controller
        public Controller Controller
		{
			get { return controller; }
            set { controller = value; }
		}

		// Method to broadcast to the controller to all components
		protected void AssignController(Controller controller)
		{
			this.controller = controller;
		}
	}
}
