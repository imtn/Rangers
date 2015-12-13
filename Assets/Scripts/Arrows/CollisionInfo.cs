using UnityEngine;

namespace Assets.Scripts.Arrows
{
    public class CollisionInfo : MonoBehaviour
    {
        private Vector3 hitPosition;
        private Quaternion hitRotation;
        private bool isTrigger;

        #region C# Properties
        public Vector3 HitPosition
        {
            get { return hitPosition; }
            set { hitPosition = value; }
        }

        public Quaternion HitRotation
        {
            get { return hitRotation; }
            set { hitRotation = value; }
        }

        public bool IsTrigger
        {
            get { return isTrigger; }
            set { isTrigger = value; }
        }
        #endregion
    }
}
