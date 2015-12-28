using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Level;
using Assets.Scripts.Player;
using Assets.Scripts.Timers;
using Assets.Scripts.Util;
using TeamUtility.IO;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Manager to control everything as the top of the pyramid
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Use a singleton instance to make sure there is only one
        /// </summary>
        public static GameManager instance;

        // List of all the controllers of the players
        private List<Controller> controllers;

        // List of all the types of tokens available
        [SerializeField]
        private List<GameObject> allTokens;
        private Dictionary<Enums.Tokens, Enums.Frequency> tokens;

        // Match timer (optional)
        private Timer matchTimer;

        // Current game settings to abide by
        private GameSettings currentGameSettings;

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

            controllers = new List<Controller>();
        }

        void Start()
        {
            // Call Init
            InitializeMatch();
        }

        /// <summary>
        /// Initializes the match when one is started
        /// </summary>
        private void InitializeMatch()
        {
            // Find all the players
            Controller[] findControllers = FindObjectsOfType<Controller>();
            for (int i = 0; i < findControllers.Length; i++)
            {
                controllers.Add(findControllers[i]);
            }
            // Load the last settings used
            //currentGameSettings = LoadManager.LoadGameSettings(GameSettings.persistentExtension);
            currentGameSettings = LoadManager.LoadGameSettingsXML("Test");
            // Check for targets
            currentGameSettings.Type = Enums.GameType.Target;
            // Initialize the tokens
            TokenSpawner.instance.Init(currentGameSettings.EnabledTokens);

            if (currentGameSettings.Type.Equals(Enums.GameType.Target))
            {
                currentGameSettings.TargetsInLevel = FindObjectsOfType<Target>().Length;
                matchTimer = gameObject.AddComponent<Timer>();
                matchTimer.Initialize(Mathf.Infinity, "Match Timer");
            }
        }

        /// <summary>
        /// Handles a target being destroyed and checks to see if the game is over
        /// </summary>
        /// <param name="fromPlayer">The player that hit the target</param>
        public void TargetDestroyed(PlayerID fromPlayer)
        {
            if (--currentGameSettings.TargetsInLevel <= 0) GameOver();
        }

        /// <summary>
        /// Handles what happens when the game is over
        /// </summary>
        private void GameOver()
        {
            Debug.Log("Match concluded");
        }

        /// <summary>
        /// Sets up the player so it can respawn.
        /// </summary>
        /// <param name="id">The ID of the player that died</param>
        public void Respawn(PlayerID id)
        {
            // Find the dead player
            Controller deadPlayer = controllers.Find(x => x.ID.Equals(id));
            if(deadPlayer != null)
            {
                // Initialize the respawn timer
                CountdownTimer t = gameObject.AddComponent<CountdownTimer>();
                t.Initialize(3f, deadPlayer.ID.ToString());
                t.TimeOut += new CountdownTimer.TimerEvent(ResawnHelper);
            }
        }

        /// <summary>
        /// Target for the respawn timer to run on timeout.
        /// </summary>
        /// <param name="t">The timer that is firing the event</param>
        private void ResawnHelper(CountdownTimer t)
        {
            // Find the dead player again
            Controller deadPlayer = controllers.Find(x => x.ID.Equals(System.Enum.Parse(typeof(PlayerID), t.ID)));
            if (deadPlayer != null)
            {
                // Find an appropriate spawning pod (set to default for now)
                deadPlayer.transform.position = Vector3.zero;
                // Let the player revive itself
                deadPlayer.LifeComponent.Respawn();
            }
        }

        #region C# Properties
        /// <summary>
        /// List of all the tokens prefabs
        /// </summary>
        public List<GameObject> AllTokens
        {
            get { return allTokens; }
        }
        /// <summary>
        /// Current game settings to check rules against
        /// </summary>
        public GameSettings CurrentGameSettings
        {
            get { return currentGameSettings; }
            set { currentGameSettings = value; }
        }
        /// <summary>
        /// All the players in the current game
        /// </summary>
        public List<Controller> AllPlayers
        {
            get { return controllers; }
        }
        #endregion
    }
}
