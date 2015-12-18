using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Util;
using TeamUtility.IO;

namespace Assets.Scripts.Arrows
{
    public class ArrowController : MonoBehaviour
    {
        private delegate void ArrowEvent();
        private delegate void ArrowHitEvent(PlayerID hitPlayer);
        private event ArrowEvent Init;
        private event ArrowHitEvent Effect;

        private float damage = 35f;
        private PlayerID fromPlayer, hitPlayer;
        private float bounciness = 0;

        // Reference to arrowhead
        [SerializeField]
        private Transform arrowhead;

        // Caching the rigidbody, collider, and collision info
        new private Rigidbody rigidbody;
        private Vector3 prevVelocity;
        new private Collider collider;
        private CollisionInfo colInfo;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            collider = GetComponent<Collider>();
            colInfo = GetComponent<CollisionInfo>();
        }

        public void InitArrow(int types, PlayerID fromPlayer)
        {
            this.fromPlayer = fromPlayer;
            GenerateArrowProperties(types);
            if (Init != null) Init();
        }

        void Update()
        {
            if (rigidbody.velocity != Vector3.zero) transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
            prevVelocity = rigidbody.velocity;

        }

        void OnCollisionEnter(Collision col)
        {
            if (col.transform.tag.Equals("ArrowDestroyer")) return;
            if (col.transform.tag.Equals("Player"))
            {
                Controller controller = col.transform.GetComponent<Controller>();
                controller.LifeComponent.ModifyHealth(-damage);
                hitPlayer = controller.ID;
            }
            // Update collision info for arrow components to use
            colInfo.HitPosition = arrowhead.position;
            colInfo.HitRotation = arrowhead.rotation;
            colInfo.IsTrigger = false;

            if (Effect != null) Effect(hitPlayer);
            if (--bounciness <= 0)
            {
                Destroy(rigidbody);
                Destroy(collider);
                Destroy(this);
            }
            else
            {
                rigidbody.velocity = Vector3.Reflect(prevVelocity, col.contacts[0].normal);
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.transform.tag.Equals("ArrowDestroyer")) return;
            if (col.transform.tag.Equals("Player"))
            {
                Controller controller = col.transform.GetComponent<Controller>();
                controller.LifeComponent.ModifyHealth(-damage);
                hitPlayer = controller.ID;
            }
            // Update collision info for arrow components to use
            colInfo.HitPosition = arrowhead.position;
            colInfo.HitRotation = arrowhead.rotation;
            colInfo.IsTrigger = false;

            if (Effect != null) Effect(hitPlayer);
        }

        // Add all the arrow types and setup the appropriate delegates
        private void GenerateArrowProperties(int types)
        {
            if (types == 0) return;
            for(int i = 0; i < (int)Enums.Arrows.NumTypes; i++)
            {
                // Check to see if the type exists int he current arrow
                if(Bitwise.IsBitOn(types, i))
                {
                    ArrowProperty temp = GetArrowProperty((Enums.Arrows)i);
                    temp.Type = (Enums.Arrows)i;
                    temp.FromPlayer = fromPlayer;        
                    Init += temp.Init;
                    Effect += temp.Effect;
                }
            }
        }

        // Used to add the appropriatre script to the gameobject
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
                    bounciness = 4;
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
