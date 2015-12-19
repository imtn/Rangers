using UnityEngine;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class that handles player specific components of the controller
    /// Uses input
    /// </summary>
    public class PlayerController : Controller
    {
        private bool fire;

        void Update()
        {
            if (InputManager.GetAxis("Vertical_P" + (int)id, id) != 0) parkour.MoveVertical();
            if (InputManager.GetAxis("Horizontal_P" + (int)id, id) != 0) parkour.MoveHorizontal();
            // Updating the indicator of which direction the player is going to fire
            if (InputManager.GetAxis("LookHorizontal_P" + (int)id, id) == 0 && InputManager.GetAxis("LookVertical_P" + (int)id, id) == 0)
            {
                archery.UpdateFirePoint(Vector3.Normalize(Vector3.right + new Vector3(Random.Range(-shake, shake), Random.Range(-shake, shake), 0f)) * distanceToPlayer);
            }
            else
            {
                archery.UpdateFirePoint(Vector3.Normalize(Vector3.Normalize(new Vector3(
                                          InputManager.GetAxis("LookHorizontal_P" + (int)id, id) + (Random.Range(-shake, shake)),
                                          InputManager.GetAxis("LookVertical_P" + (int)id, id) + (Random.Range(-shake, shake)),
                                          0))) * distanceToPlayer);
            }
            if (InputManager.GetAxis("Fire_P" + (int)id, id) > 0)
            {
                fire = true;
                shake = 0.1f;
            }
            else if (fire && InputManager.GetAxis("Fire_P" + (int)id, id) == 0)
            {
                archery.Fire();
                fire = false;
                shake = 0f;
            }
        }
    }
}
