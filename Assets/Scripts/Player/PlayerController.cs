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
        
        private bool fire;

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
    }
}
