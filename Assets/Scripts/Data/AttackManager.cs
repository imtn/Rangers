using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Util;

namespace Assets.Scripts.Data
{
    public class AttackManager : MonoBehaviour
    {
        // Use a singleton instance to make sure there is only one
        public static AttackManager instance;

        // List of possible attack effect prefabs
        [SerializeField]
        private List<GameObject> effectPrefabs;

        // Sets up singleton instance. Will remain if one does not already exist in scene
        void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            if(effectPrefabs == null) effectPrefabs = new List<GameObject>();
        }

        // Gets the prefab based on the arrow type
        public GameObject GetEffect(Enums.Arrows type)
        {
            // Will check null in the script that gets this object
            return effectPrefabs.Find(x => x.name.StartsWith(type.ToString()));
        }
    } 
}
