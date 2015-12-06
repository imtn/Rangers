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
        protected Profile profile;

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
            if (InputManager.GetAxis("Vertical") != 0) parkour.MoveVertical();
            if (InputManager.GetAxis("Horizontal") != 0) parkour.MoveHorizontal();
            if (InputManager.GetButtonDown("Fire")) archery.Fire();
        }

        #region C# Properties
        public Profile ProfileComponent
        {
            get { return profile; }
            set { profile = value; }
        }
        #endregion
    }
}
