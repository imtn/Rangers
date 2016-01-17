using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Util;

namespace Assets.Scripts.Tokens
{
    /// <summary>
    /// Allows the characters to collect different types of arrows
    /// </summary>
    public class ArrowToken : Token
    {
        [SerializeField]
        private Enums.Arrows type;

        /// <summary>
        ///  Override the TokenCollected method and tell the Archery component to collect the token
        /// </summary>
        /// <param name="controller">The controller that is doing the collecting</param>
        protected override void TokenCollected(Controller controller)
        {
			controller.ArcheryComponent.CollectToken(this);
        }

        #region C# Properties
        /// <summary>
        /// Type of arrow associated with the token
        /// </summary>
        public Enums.Arrows Type
        {
            get { return type; }
        }
        #endregion
    }
}
