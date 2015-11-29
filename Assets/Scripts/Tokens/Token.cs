using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts.Tokens
{
    public abstract class Token : MonoBehaviour
    {
        // Tokens will be colected via trigger
        void OnTriggerEnter(Collider col)
        {
            TokenCollected(col.GetComponent<PlayerController>());
            Destroy(gameObject);
        }

        // Token will use the PlayerController to get the appropriate component
        protected abstract void TokenCollected(PlayerController controller);
	}
}
