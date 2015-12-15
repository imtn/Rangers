using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Util;

namespace Assets.Scripts.Data
{
    public class TokenSpawner : MonoBehaviour
    {
        public static TokenSpawner instance;
        [SerializeField]
        private List<GameObject> tokens;

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
        }

        public void Init(Dictionary<Enums.Tokens, Enums.Frequency> tokenDict)
        {
            TokenSpawnPoint[] spawnPoints = FindObjectsOfType<TokenSpawnPoint>();
            if (spawnPoints.Length == 0) return;

            tokens = new List<GameObject>();
            foreach(Enums.Tokens key in tokenDict.Keys)
            {
                GameObject go = GameManager.instance.AllTokens.Find(x => x.name.StartsWith(key.ToString()));
                if (go != null)
                {
                    Enums.Frequency freq = tokenDict[key];
                    for (int i = 0; i < (int)freq; i++)
                    {
                        GameObject spawnToken;
                        spawnToken = Instantiate(go);
                        tokens.Add(spawnToken);
                        spawnToken.SetActive(false);
                    }
                }
                else Debug.Log("Key: " + key.ToString() + " is null");
            }
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                spawnPoints[i].Init();
            }
        }

        public GameObject GetToken()
        {
            GameObject temp;
            for (int i = 0; i < tokens.Count; i++)
            {
                int r = i + (int)(Random.Range(0f, 1f) * (tokens.Count - i));
                temp = tokens[r];
                tokens[r] = tokens[i];
                tokens[i] = temp;
            }
            temp = tokens.Find(x => !x.gameObject.activeSelf);
            return temp;
        }

        #region C# Properties
        public List<GameObject> Tokens
        {
            get { return tokens; }
        }
        #endregion
    }
}
