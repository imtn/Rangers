using UnityEngine;

namespace Assets.Scripts.Player
{
    /*
     * This class wil manage all the player's (and enemy's) components,
     * such as movement, data , etc
     * Will also allow the different components to talk to one another
     */
    public class Controller : MonoBehaviour
    {
        // Componenets to manage
        protected Parkour parkour;
        protected Life life;
        protected Archery archery;

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

            // Tell all components this is their controller
            life.Controller = this;
            parkour.Controller = this;
            archery.Controller = this;
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
        #endregion
    }
}
