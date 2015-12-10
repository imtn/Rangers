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
            if (InputManager.GetAxis("Vertical_P" + (int)id, id) != 0) parkour.MoveVertical();
            if (InputManager.GetAxis("Horizontal_P" + (int)id, id) != 0) parkour.MoveHorizontal();
            if (InputManager.GetAxis("Fire_P" + (int)id, id) > 0)
            {
                fire = true;
            }
            else if (fire && InputManager.GetAxis("Fire_P" + (int)id, id) == 0)
            {
                archery.Fire();
                fire = false;
            }
        }
    }
}
