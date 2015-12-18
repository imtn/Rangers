using UnityEngine;
using Assets.Scripts.Attacks;
using Assets.Scripts.Data;
using TeamUtility.IO;

namespace Assets.Scripts.Arrows
{
    public abstract class SpawnerProperty : ArrowProperty
    {
        protected GameObject spawnEffect;

        public override void Init()
        {
            base.Init();
            spawnEffect = AttackManager.instance.GetEffect(type);
        }

        public override void Effect(PlayerID hitPlayer)
        {
            if (spawnEffect != null)
            {
                GameObject g = (GameObject)Instantiate(spawnEffect, colInfo.HitPosition, colInfo.HitRotation);
                //g.GetComponent<SpawnAttack>().UpdatePlayerInfo(fromPlayer, hitPlayer);
            }
            else Debug.Log("Arrow of type: " + type.ToString() + " could not load an effect");
        }
    }
}
