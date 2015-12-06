using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Util;

namespace Assets.Scripts.Tokens
{
    /*
     * Allows the characters to collect different types of arrows
     */
    public class ArrowToken : Token
    {
        [SerializeField]
        private Enums.Arrows type;

        // Override the TokenCollected method and tell the Archery component to collect the token
        protected override void TokenCollected(Controller controller)
        {
            controller.ArcheryComponent.CollectToken(this);
        }

        #region C# Properties
        public Enums.Arrows Type
        {
            get { return type; }
        }
        #endregion
    }
}
