using TeamUtility.IO;
using UnityEngine;
using Assets.Scripts.Attacks;

namespace Assets.Scripts.Arrows
{
    public class AcidArrow : ArrowProperty
    {
        public override void Effect(PlayerID hitPlayer)
        {
            if(hitPlayer != 0) Data.GameManager.instance.AllPlayers.Find(x => x.ID.Equals(hitPlayer)).gameObject.AddComponent<AcidAttack>();
        }
    } 
}
