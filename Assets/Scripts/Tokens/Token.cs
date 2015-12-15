using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts.Tokens
{
    /*
     * Tokens will be collected by players to add effects. Effects do not stack
     */
    public abstract class Token : MonoBehaviour
    {
        // Tokens will be collected via trigger
        void OnTriggerEnter(Collider col)
        {
            TokenCollected(col.GetComponent<Controller>());
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

        // Token will use the Controller to get the appropriate component
        protected abstract void TokenCollected(Controller controller);
	}
}
