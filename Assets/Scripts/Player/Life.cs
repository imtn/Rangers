using Assets.Scripts.Tokens;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /*
     * Handles all the components related to in game Life
     * such as lives, health, respawning, etc
     */
	public class Life : ControllerObject
	{
        // Max health a character can have
        public const float MAX_HEALTH = 100f;

        // Amount of health a player has
        private float health;

        // Overriding the collect token method from player controller object
        public override void CollectToken(Token token)
        {
            // Handle what type of token was collected
            if (token.GetType().Equals(typeof(HealthToken)))
            {
                // Add health back to the player
                health = Mathf.Clamp((health + ((HealthToken)token).Health), 0, MAX_HEALTH);
            }
        }

        #region C# Properties
        public float Health
        {
            get { return health; }
            set { health = value; }
        }
        #endregion
    }
}
