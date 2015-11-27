using UnityEngine;
using Assets.Scripts.Util;

namespace Assets.Scripts.Arrows
{
    public class Token : MonoBehaviour
    {
        [SerializeField]
        private Enums.Arrows type;

        void OnTriggerEnter(Collider col)
        {
            col.GetComponent<Player.PlayerAttack>().CollectToken(this);
            Destroy(gameObject);
        }

        public Enums.Arrows Type
        {
            get { return type; }
        }
	}
}
