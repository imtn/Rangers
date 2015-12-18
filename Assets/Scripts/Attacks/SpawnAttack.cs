using UnityEngine;
using TeamUtility.IO;

namespace Assets.Scripts.Attacks
{
    public class SpawnAttack : MonoBehaviour
    {
        protected float damage = 10f;

        protected PlayerID fromPlayer, hitPlayer;

        public void UpdatePlayerInfo(PlayerID fromPlayer, PlayerID hitPlayer)
        {
            this.fromPlayer = fromPlayer;
            this.hitPlayer = hitPlayer;
        }

        #region C# Properties
        public float Damage
        {
            get { return damage; }
        }
        public PlayerID FromPlayer
        {
            get { return fromPlayer; }
        }
        public PlayerID HitPlayer
        {
            get { return hitPlayer; }
        }
        #endregion
    }
}