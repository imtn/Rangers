using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Util;
using Assets.Scripts.Data;

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
            if (controller.ArcheryComponent.CanCollectToken() && !Util.Bitwise.IsBitOn(controller.ArcheryComponent.ArrowTypes, (int)type))
            {
				if (GameManager.instance.CurrentGameSettings.Variant == Enums.GameVariant.TokensForEveryone) {
					Debug.Log ("Tokens for everyone");
					foreach (Controller TFEPlayerController in GameManager.instance.AllPlayers) {
						TFEPlayerController.ArcheryComponent.CollectToken (this);
					}
				} else {
					controller.ArcheryComponent.CollectToken (this);
					// Set inactive since we are pooling
					gameObject.SetActive (false);
				}
			}				
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
