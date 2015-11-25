using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerAttack : PlayerControllerObject
	{
        [SerializeField]
        private GameObject arrowPrefab;
        public Transform firePoint;

        public int types = 1;

		public override void Run ()
		{
            if (Input.GetButtonDown("Jump")) Fire();
		}

		public override void FixedRun ()
		{
			throw new System.NotImplementedException ();
		}

        private void Fire()
        {
            GameObject arrow = (GameObject)Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            arrow.GetComponent<Rigidbody>().AddRelativeForce(arrow.transform.right * 10, ForceMode.Impulse);
            arrow.GetComponent<Arrows.ArrowController>().InitArrow(types);
        }
	}
}
