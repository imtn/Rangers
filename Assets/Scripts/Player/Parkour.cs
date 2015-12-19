using UnityEngine;
using Assets.Scripts.Tokens;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Handles all of the movement a character can do
    /// </summary>
	public class Parkour : ControllerObject
	{
        /// <summary>
        /// Vertical charatcer movement
        /// </summary>
		public void MoveVertical()
        {
            transform.Translate(new Vector3(0, InputManager.GetAxis("Vertical_P" + (int)((PlayerController)controller).ID, ((PlayerController)controller).ID), 0) * Time.deltaTime * 3);
        }

        /// <summary>
        /// Horizontal character movement
        /// </summary>
        public void MoveHorizontal()
        {
            transform.Translate(new Vector3(InputManager.GetAxis("Horizontal_P" + (int)((PlayerController)controller).ID, ((PlayerController)controller).ID), 0, 0) * Time.deltaTime * 3);
        }

        /// <summary>
        /// Overriding the collect token method from player controller object
        /// </summary>
        /// <param name="token">The token that was collected</param>
        public override void CollectToken(Token token) { }
    }
}
