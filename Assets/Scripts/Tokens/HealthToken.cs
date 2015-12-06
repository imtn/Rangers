using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Util;

namespace Assets.Scripts.Tokens
{
    /*
     * Functions like a health pickup. Adds health to character who collides with it
     */
    public class HealthToken : Token
    {
        [SerializeField]
        private float health;

        // Override the TokenCollected method and tell the Life component to collect the token
        protected override void TokenCollected(Controller controller)
        {
            controller.LifeComponent.CollectToken(this);
        }

        #region C# Properties
        public float Health
        {
            get { return health; }
        }
        #endregion
    }
}
