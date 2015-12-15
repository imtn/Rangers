using UnityEngine;

namespace Assets.Scripts.Util
{
    public class ArrowDestroyer : MonoBehaviour
    {
        void OnTriggerEnter(Collider col)
        {
            if (col.transform.tag.Equals("Arrow")) Destroy(col.gameObject);
        }
    }
}