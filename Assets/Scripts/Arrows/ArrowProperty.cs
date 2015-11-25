using UnityEngine;

namespace Assets.Scripts.Arrows
{
    public abstract class ArrowProperty : MonoBehaviour
    {
        // How much damage a single arrow will do
        protected float baseDamage = 10;

        // Constructor
        public ArrowProperty() { }

        // Runs at start
        public abstract void Init();
        // Runs when arrow hits or passes through something as applicable
        public abstract void Effect();
	}
}
