using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Timers;

namespace Assets.Scripts.Attacks
{
    public class AcidAttack : SpawnAttack
    {
        RepetitionTimer t;
        new protected float damage = 5;
        private float damageInterval = 1f;
        private int numHits = 6;
        private Controller controller;

        void Start()
        {
            AcidAttack[] currentAttacks = gameObject.GetComponents<AcidAttack>();
            if(currentAttacks.Length > 1)
            {
                for(int i  = 0; i < currentAttacks.Length; i++)
                {
                    if(currentAttacks[i] != this) currentAttacks[i].Timer.Reset();
                }
                Destroy(this);
            }
            else
            {
                controller = GetComponent<Controller>();
                t = gameObject.AddComponent<RepetitionTimer>();
                t.Initialize(damageInterval, "Acid Attack", numHits);
                t.TimeOut += new RepetitionTimer.TimerEvent(DamagePlayer);
                t.FinalTick += FinalHit;
            }
        }

        private void DamagePlayer(RepetitionTimer t)
        {
            controller.LifeComponent.ModifyHealth(-damage, fromPlayer);
        }

        private void FinalHit(RepetitionTimer t)
        {
            Destroy(this);
        }

        #region C# Properties
        public RepetitionTimer Timer
        {
            get { return t; }
        }
        #endregion
    }
}