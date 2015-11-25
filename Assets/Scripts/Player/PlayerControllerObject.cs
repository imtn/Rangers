using UnityEngine;
using System.Collections;

/*
 * This abstract class will be what all player conponents use for the controller to control them
 */
namespace Assets.Scripts.Player
{
	public abstract class PlayerControllerObject : MonoBehaviour
	{
		//reference to the player controller
		protected PlayerController controller;

		//abstract methods children need to implement
		public abstract void Run();
		public abstract void FixedRun();

		//getter for the controller
		public PlayerController Controller
		{
			get { return controller; }
            set { controller = value; }
		}

		//method to broadcast to the controller to all components
		protected void AssignController(PlayerController controller)
		{
			this.controller = controller;
		}
	}
}
