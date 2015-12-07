using UnityEngine;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{ 
    /*
     * Class that handles player specific components of the controller
     * Uses input
     */
    public class PlayerController : Controller
    {
        // ID for identifying which player is accepting input
        [SerializeField]
        private PlayerID id;

        protected Profile profile;
        private bool fire;

        // Overriding the controller initialize
        protected override void InitializePlayerComponents()
        {
            // Call the base initialize
            base.InitializePlayerComponents();
            // Add the extra profile component
            profile = gameObject.AddComponent<Profile>();
        }

        void Update()
        {
            if (InputManager.GetAxis("Vertical", id) != 0) parkour.MoveVertical();
            if (InputManager.GetAxis("Horizontal", id) != 0) parkour.MoveHorizontal();
            if (InputManager.GetAxis("Fire", id) > 0)
            {
                fire = true;
            }
            else if (fire && InputManager.GetAxis("Fire", id) == 0)
            {
                archery.Fire();
                fire = false;
            }
        }

        #region C# Properties
        public Profile ProfileComponent
        {
            get { return profile; }
            set { profile = value; }
        }
        public PlayerID ID
        {
            get { return id; }
        }
        #endregion
    }
}
