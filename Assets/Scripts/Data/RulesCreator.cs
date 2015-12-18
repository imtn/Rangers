using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Util;

namespace Assets.Scripts.Data
{
    public class RulesCreator : MonoBehaviour
    {
        public string fileName;

        [Space]
        public Enums.GameType type;

        [Space]
        public bool timeLimitEnabled;
        [Range(0, GameSettings.MAX_TIME)]
        public int timeLimit = (int)GameSettings.DEFAULT_TIME;

        [Space]
        [Range(0, GameSettings.MAX_KILLS)]
        public int killLimit = (int)GameSettings.DEFAULT_KILLS;
        [Range(0, GameSettings.MAX_STOCK)]
        public int stockLimit = (int)GameSettings.DEFAULT_STOCK;

        [Space]
        [Range(0, GameSettings.MAX_TIME)]
        public int arrowLimit = 0;

        [Space]
        [Range(0.1f, 10f)]
        public float damageModifier = 1f, gravityModifier = 1f, speedModifier = 1f;

        [Space]
        [Range(0.1f, 180f)]
        public float tokenSpawnFreq = 3f;
        [Range(0.1f, 10f)]
        public float playerSpawnFreq = 5f;

        [Space]
        public List<Enums.Tokens> tokens;
        public List<Enums.Frequency> freqs;
        private Dictionary<Enums.Tokens, Enums.Frequency> enabledTokens;

        [Space]
        public List<Enums.Tokens> defaultTokens;

        void Start()
        {
            if (fileName == "") return;
            GameSettings g = new GameSettings();

            g.Type = type;

            g.TimeLimitEnabled = timeLimitEnabled;
            g.TimeLimit = (timeLimit == 0 ? Mathf.Infinity : timeLimit);
            g.KillLimit = (killLimit == 0 ? Mathf.Infinity : killLimit);
            g.StockLimit = (stockLimit == 0 ? Mathf.Infinity : stockLimit);
            g.ArrowLimit = (arrowLimit == 0 ? Mathf.Infinity : arrowLimit);
            g.DamageModifier = damageModifier;
            g.GravityModifier = gravityModifier;
            g.SpeedModifier = speedModifier;
            g.TokenSpawnFreq = tokenSpawnFreq;
            g.TokePlayerSpawnFreq = playerSpawnFreq;

            enabledTokens = new Dictionary<Enums.Tokens, Enums.Frequency>();
            for(int i = 0; i < tokens.Count; i++)
            {
                enabledTokens.Add(tokens[i], freqs[i]);
            }
            g.EnabledTokens = enabledTokens;
            g.DefaultTokens = defaultTokens;

            SaveManager.SaveGameSettings(g, fileName + ".dat");
        }
    }
}
