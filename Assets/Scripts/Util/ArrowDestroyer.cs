using UnityEngine;

namespace Assets.Scripts.Util
{
    /// <summary>
    /// Destroys arrows that enter it so that they do not fly offscreen forever
    /// </summary>
    public class ArrowDestroyer : MonoBehaviour
    {
        void OnTriggerEnter(Collider col)
        {
            if (col.transform.tag.Equals("Arrow")) Destroy(col.gameObject);
        }
    }
}