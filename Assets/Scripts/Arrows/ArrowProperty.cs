using UnityEngine;
using Assets.Scripts.Util;

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
        #endregion
    }
}
