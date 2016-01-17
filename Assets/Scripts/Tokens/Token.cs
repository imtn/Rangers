using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts.Tokens
{
    /// <summary>
    /// Tokens will be collected by players to add effects. Effects do not stack
    /// </summary>
    public abstract class Token : MonoBehaviour
    {
        // Tokens will be collected via trigger
        void OnTriggerEnter(Collider col)
        {
			TokenCollected(col.transform.root.GetComponent<Controller>());
            // Set inactive since we are pooling
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Token will use the Controller to get the appropriate component
        /// </summary>
        /// <param name="controller">The controller that is collecting the token</param>
        protected abstract void TokenCollected(Controller controller);
	}
}
