using UnityEngine;
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
        // ID for identifying which player is accepting input
        [SerializeField]
        protected PlayerID id;

        // Componenets to manage
        protected Parkour parkour;
        protected Life life;
        protected Archery archery;
        protected Profile profile;

        void Start()
        {
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
