using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Util;

namespace Assets.Scripts.Tokens
{
    public class ArrowToken : Token
    {
        [SerializeField]
        private Enums.Arrows type;

        protected override void TokenCollected(PlayerController controller)
        {
            controller.AttackComponent.CollectToken(this);
        }

        public Enums.Arrows Type
        {
            get { return type; }
        }
	}
}
