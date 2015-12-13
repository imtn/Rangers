using UnityEngine;
using Assets.Scripts.Util;
using TeamUtility.IO;

namespace Assets.Scripts.Arrows
{
    public abstract class ArrowProperty : MonoBehaviour
    {
        // How much damage a single arrow will do
        protected float baseDamage = 10;
        // Type of arrow this component is
        protected Enums.Arrows type;
        // The collision info for the children to use
        protected CollisionInfo colInfo;
        // The player who the ID belongs to
        protected PlayerID fromPlayer;

        // Runs at start
        public virtual void Init()
        {
            colInfo = GetComponent<CollisionInfo>();
        }
        // Runs when arrow hits or passes through something as applicable
        public abstract void Effect();

        #region C# Properties
        public Enums.Arrows Type
        {
            get { return type; }
            set { type = value; }
        }
        public PlayerID FromPlayer
        {
            get { return fromPlayer; }
            set { fromPlayer = value; }
        }
        #endregion
    }
}
