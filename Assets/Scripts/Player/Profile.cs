using System;
using Assets.Scripts.Tokens;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Handles all of the profile data related to the player
    /// </summary>
    public class Profile : ControllerObject
    {
        /// <summary>
        /// Overriding the collect token method from player controller object
        /// </summary>
        /// <param name="token">The token that was collected</param>
        public override void CollectToken(Token token)
        {
            throw new NotImplementedException();
        }
    }
}