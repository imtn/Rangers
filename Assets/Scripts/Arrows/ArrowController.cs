using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Util;

namespace Assets.Scripts.Arrows
{
    public class ArrowController : MonoBehaviour
    {
        private delegate void ArrowEvent();
        private event ArrowEvent Init, Effect;

        private float damage = 35f;

        // Reference to arrowhead
        [SerializeField]
        private Transform arrowhead;

        // Caching the rigidbody, collider, and collision info
        new private Rigidbody rigidbody;
        new private Collider collider;
        private CollisionInfo colInfo;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            collider = GetComponent<Collider>();
            colInfo = GetComponent<CollisionInfo>();
        }

        public void InitArrow(int types)
        {
            GenerateArrowProperties(types);
            if (Init != null) Init();
        }

        void Update()
        {
            if (rigidbody.velocity != Vector3.zero) transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
        }

        void OnCollisionEnter(Collision col)
        {
            if(col.transform.tag.Equals("Player"))
            {
                Controller controller = col.transform.GetComponent<Controller>();
                controller.LifeComponent.ModifyHealth(-damage);
            }
            // Update collision info for arrow components to use
            colInfo.HitPosition = arrowhead.position;
            colInfo.HitRotation = arrowhead.rotation;

            if (Effect != null) Effect();
            Destroy(rigidbody);
            Destroy(collider);
            Destroy(this);
        }

        void OnTriggerEnter(Collider col)
        {
            // Update collision info for arrow components to use
            colInfo.HitPosition = arrowhead.position;
            colInfo.HitRotation = arrowhead.rotation;

            if (Effect != null) Effect();
        }

        // Add all the arrow types and setup the appropriate delegates
        private void GenerateArrowProperties(int types)
        {
            if (types == 0) return;
            for(int i = 0; i < (int)Enums.Arrows.NumTypes; i++)
            {
                // Check to see if the type exists int he current arrow
                if (((1 << i) & types) > 0)
                {
                    ArrowProperty temp = GetArrowProperty((Enums.Arrows)i);
                    temp.Type = (Enums.Arrows)i;              
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
                case Enums.Arrows.Poison:
                    return gameObject.AddComponent<AcidArrow>();
                case Enums.Arrows.Ricochet:
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
