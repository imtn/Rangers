using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts.Attacks
{
	/// <summary>
	/// Attack the simulates an explosion and damages and sends affected objects flying
	/// </summary>
    public class FireballAttack : SpawnAttack
    {
		private float size = 0f, maxSize = 10f, sizeDelta = 10f;
		new protected float damage = 20f;

		/// <summary>
		/// Layers that are not affected by the explosion
		/// </summary>
		[SerializeField]
		private LayerMask doNotActivate;
        
        void Update()
        {
			// Grow the explosion
            size += sizeDelta * Time.deltaTime;
			transform.localScale = new Vector3 (size, size, size);
			if (size >= maxSize) Destroy(gameObject);
        }

        void OnTriggerEnter(Collider col)
        {
			if ((doNotActivate.value & (1 << col.gameObject.layer)) != 0) return;

			// Hit the player and damage
			if (col.transform.tag.Equals ("Player"))
			{
				Controller controller = col.transform.GetComponent<Controller>();
				controller.LifeComponent.ModifyHealth(-damage);
				hitPlayer = controller.ID;
			}
			// Apply an explosion force to the object hit
			col.GetComponent<Rigidbody> ().AddExplosionForce (200f, transform.position, 10);
        }
    } 
}
