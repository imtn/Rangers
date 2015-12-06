using UnityEngine;
using Assets.Scripts.Tokens;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /*
     * Handles all of the movement a character can do
     */
	public class Parkour : ControllerObject
	{
        // Vertical charatcer movement
		public void MoveVertical()
        {
            transform.Translate(new Vector3(0, InputManager.GetAxis("Vertical"), 0) * Time.deltaTime * 3);
        }

        // Horizontal character movement
        public void MoveHorizontal()
        {
            transform.Translate(new Vector3(InputManager.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * 3);
        }

        // Overriding the collect token method from player controller object
        public override void CollectToken(Token token) { }
    }
}
