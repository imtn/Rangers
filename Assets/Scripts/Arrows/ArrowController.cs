using UnityEngine;
using Assets.Scripts.Level;
using Assets.Scripts.Player;
using Assets.Scripts.Util;
using TeamUtility.IO;

namespace Assets.Scripts.Arrows
{
    /// <summary>
    /// Controls the different components of the arrow and activates all the effects upon inpact.
    /// </summary>
    public class ArrowController : MonoBehaviour
    {
        // Init and Effect events for the different types of arrows
        private delegate void ArrowEvent();
        private delegate void ArrowHitEvent(PlayerID hitPlayer);
        private event ArrowEvent Init;
        private event ArrowHitEvent Effect;

        // Layers that should not activate the arrow's effects
        [SerializeField]
        private LayerMask doNotActivate;

        // Damage to be dealt when hit by an arrow
        private float damage = 35f;
        // Player IDs for passing along information
        private PlayerID fromPlayer, hitPlayer;
        // For ricochet arrows
        private float bounciness = 0;

        // Reference to arrowhead
        [SerializeField]
        private Transform arrowhead;

        // Caching the rigidbody, collider, and collision info
        new private Rigidbody rigidbody;
        private Vector3 prevVelocity;
        new private Collider collider;
        private CollisionInfo colInfo;

        // Initialze all necessary components
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
			collider = GetComponentInChildren<Collider>();
            colInfo = GetComponent<CollisionInfo>();
        }

        /// <summary>
        /// Initializes the arrow by adding all the necesary components.
        /// </summary>
        /// <param name="types">The types of arrow components to be added. Comes from the different tokens the player has collected.</param>
        /// <param name="fromPlayer">ID of the player shooting the arrow.</param>
        public void InitArrow(int types, PlayerID fromPlayer)
        {
            // Update the player info
            this.fromPlayer = fromPlayer;
            // Initializing this arrow
            GenerateArrowProperties(types);
            // Call the init event for all arrow componenets
            if (Init != null) Init();
        }

        void Update()
        {
            // Point the arrow the direction it is travelling
            if (rigidbody != null && rigidbody.velocity != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
                // Cache the previous velocity
                prevVelocity = rigidbody.velocity;
            }
        }

        // Arrow hits something
        void OnCollisionEnter(Collision col)
        {
            // Check to see a layer of the object should not activate the effects
            if ((doNotActivate.value & (1 << col.gameObject.layer)) != 0) return;
            // If the arrow his a player
			if (col.transform.root.tag.Equals("Player"))
            {
                // Damage the player hit
                Controller controller = col.transform.GetComponent<Controller>();
                controller.LifeComponent.ModifyHealth(-damage, fromPlayer);
                hitPlayer = controller.ID;
            }
			else if(col.transform.root.tag.Equals("Target"))
            {
                col.gameObject.GetComponent<Target>().TargetHit(fromPlayer);
            }
            // Update collision info for arrow components to use
            colInfo.HitPosition = arrowhead.position;
            colInfo.HitRotation = arrowhead.rotation;
            colInfo.IsTrigger = false;

            // Call the effect of each arrow component
            if (Effect != null) Effect(hitPlayer);
            // Check bounciness for ricochet arrows
            if (--bounciness <= 0)
            {
                Destroy(rigidbody);
                Destroy(collider);
				Destroy(transform.FindChild("Model").GetComponent<TrailRenderer>());
				GameObject g = new GameObject();
				transform.parent = g.transform;
				g.transform.parent = col.transform;
				Destroy(this.gameObject,1f);
                Destroy(this);
            }
            else
            {
                // Reflect the arrow to bounce off object
                rigidbody.velocity = Vector3.Reflect(prevVelocity, col.contacts[0].normal);
            }
        }

        // Arrow goes through something
        void OnTriggerEnter(Collider col)
        {
            // Check to see a layer of the object should not activate the effects
            if ((doNotActivate.value & (1 << col.gameObject.layer)) != 0) return;
            // If the arrow his a player
			if (col.transform.root.tag.Equals("Player"))
            {
				Controller controller = col.transform.root.GetComponent<Controller>();
                controller.LifeComponent.ModifyHealth(-damage, fromPlayer);
                hitPlayer = controller.ID;
            }
			else if (col.transform.root.tag.Equals("Target"))
            {
                col.gameObject.GetComponent<Target>().TargetHit(fromPlayer);
            }
            // Update collision info for arrow components to use
            colInfo.HitPosition = arrowhead.position;
            colInfo.HitRotation = arrowhead.rotation;
            colInfo.IsTrigger = false;

            // Call the effect of each arrow component
            if (Effect != null) Effect(hitPlayer);
        }

        /// <summary>
        /// Add all the arrow types and setup the appropriate delegates.
        /// </summary>
        /// <param name="types">The types of components to initialize.</param>
        private void GenerateArrowProperties(int types)
        {
            // Somehow the arrow is comprised of nothing
            if (types == 0) return;
            for(int i = 0; i < (int)Enums.Arrows.NumTypes; i++)
            {
                // Check to see if the type exists int he current arrow
                if(Bitwise.IsBitOn(types, i))
                {
                    // Add an arrow property and update the delegates
                    ArrowProperty temp = GetArrowProperty((Enums.Arrows)i);
                    temp.Type = (Enums.Arrows)i;
                    temp.FromPlayer = fromPlayer;        
                    Init += temp.Init;
                    Effect += temp.Effect;
                }
            }
        }

        /// Used to add the appropriatre script to the gameobject
        private ArrowProperty GetArrowProperty(Enums.Arrows type)
        {
            switch(type)
            {
                case Enums.Arrows.Fireball:
                    return gameObject.AddComponent<FireballArrow>();
                case Enums.Arrows.Ice:
                    return gameObject.AddComponent<IceArrow>();
                case Enums.Arrows.Thunder:
                    return gameObject.AddComponent<ThunderArrow>();
                case Enums.Arrows.Acid:
                    return gameObject.AddComponent<AcidArrow>();
                case Enums.Arrows.Ricochet:
                    bounciness = RicochetArrow.bounces;
                    return gameObject.AddComponent<RicochetArrow>();
                case Enums.Arrows.Ghost:
                    return gameObject.AddComponent<GhostArrow>();
                case Enums.Arrows.Gravity:
                    return gameObject.AddComponent<GravityArrow>();
                default:
                    return gameObject.AddComponent<NormalArrow>();
            }
        }
    }
}
