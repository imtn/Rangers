using UnityEngine;
using Assets.Scripts.Data;

namespace Assets.Scripts.Arrows
{
    public abstract class SpawnerArrow : ArrowProperty
    {
        protected GameObject spawnEffect;

        public override void Effect()
        {
            if(spawnEffect != null) Instantiate(spawnEffect, colInfo.HitPosition, colInfo.HitRotation);
            else Debug.Log("Arrow of type: " + type.ToString() + " could not load an effect");
        }

        public override void Init()
        {
            base.Init();
            spawnEffect = AttackManager.instance.GetEffect(type);
        }
    }
}
