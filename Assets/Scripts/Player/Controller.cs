using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Timers;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /*
     * This class wil manage all the player's (and enemy's) components,
     * such as movement, data , etc
     * Will also allow the different components to talk to one another
     */
    public class Controller : MonoBehaviour
    {
        protected float shake, maxShake = 0.5f;
        // ID for identifying which player is accepting input
        [SerializeField]
        protected PlayerID id;

        // List of timers for checking effects
        protected List<Timer> effectTimers;

        // Distance from firePoint to player
        protected float distanceToPlayer = 1.5f;

        // Componenets to manage
        protected Parkour parkour;
        protected Life life;
        protected Archery archery;
        protected Profile profile;

        void Start()
        {
            // Initialize the effect timers list
            effectTimers = new List<Timer>();

            // Init all componenets
            InitializePlayerComponents();
        }

        // Assigning references
        protected virtual void InitializePlayerComponents()
        {
            // Add all components to manage
            life = GetComponent<Life>();
            parkour = GetComponent<Parkour>();
            archery = GetComponent<Archery>();
            profile = GetComponent<Profile>();

            // Tell all components this is their controller
            life.Controller = this;
            parkour.Controller = this;
            archery.Controller = this;
            profile.Controller = this;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        #region C# Properties
        public Archery ArcheryComponent
        {
            get { return archery; }
        }
        public Life LifeComponent
        {
            get { return life; }
        }
        public Parkour ParkourComponent
        {
            get { return parkour; }
        }
        public Profile ProfileComponent
        {
            get { return profile; }
        }
        public PlayerID ID
        {
            get { return id; }
        }
        #endregion
    }
}
