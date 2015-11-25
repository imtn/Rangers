using UnityEngine;

namespace Assets.Scripts.Arrows
{
    public class GhostArrow : ArrowProperty
    {
        public override void Init()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        public override void Effect() { }
    } 
}
