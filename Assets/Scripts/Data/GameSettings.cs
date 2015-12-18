using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Util;

/*
 * Class for saving game settings
 */
[Serializable]
public class GameSettings
{
    public const string persistentExtension = "PrevSettings.dat";
    public const float DEFAULT_TIME = 5f, DEFAULT_KILLS = 15f, DEFAULT_STOCK = 5f, MAX_TIME = 99f, MAX_KILLS = 99f, MAX_STOCK = 99f, MAX_ARROWS = 99f;
    private float timeLimit, killLimit, stockLimit, arrowLimit, damageModifier, gravityModifier, speedModifier, tokenSpawnFreq, playerSpawnFreq;
    private bool timeLimitEnabled;
    private Enums.GameType type;
    private Dictionary<Enums.Tokens, Enums.Frequency> enabledTokens;
    private List<Enums.Tokens> defaultTokens;

    #region Constructors
    // Default settings
    public GameSettings()
    {
        type = Enums.GameType.Stock;
        timeLimit = Mathf.Infinity;
        killLimit = Mathf.Infinity;
        stockLimit = DEFAULT_STOCK;
        arrowLimit = Mathf.Infinity;
        damageModifier = 1f;
        gravityModifier = 1f;
        speedModifier = 1f;
        tokenSpawnFreq = 5f;
        playerSpawnFreq = 3f;
        timeLimitEnabled = false;
        enabledTokens = new Dictionary<Enums.Tokens, Enums.Frequency>();
        for(int i = 0; i < (int)Enums.Tokens.NumTypes; i++)
        {
            enabledTokens.Add((Enums.Tokens)i, Enums.Frequency.Abundant);
        }
        defaultTokens = new List<Enums.Tokens>();
}
    #endregion

    public void UpdateKillSettings()
    {
        type = Enums.GameType.Kills;
        killLimit = DEFAULT_KILLS;
        stockLimit = Mathf.Infinity;
    }

    public void UpdateStockSettings()
    {
        type = Enums.GameType.Stock;
        killLimit = Mathf.Infinity;
        stockLimit = DEFAULT_STOCK;
    }

    #region C# Properties
    public float TimeLimit
    {
        get { return timeLimit; }
        set { timeLimit = value; }
    }
    public float KillLimit
    {
        get { return killLimit; }
        set { killLimit = value; }
    }
    public float StockLimit
    {
        get { return stockLimit; }
        set { stockLimit = value; }
    }
    public float ArrowLimit
    {
        get { return arrowLimit; }
        set { arrowLimit = value; }
    }
    public float DamageModifier
    {
        get { return damageModifier; }
        set { damageModifier = value; }
    }
    public float GravityModifier
    {
        get { return gravityModifier; }
        set { gravityModifier = value; }
    }
    public float SpeedModifier
    {
        get { return speedModifier; }
        set { speedModifier = value; }
    }
    public float TokenSpawnFreq
    {
        get { return tokenSpawnFreq; }
        set { tokenSpawnFreq = value; }
    }
    public float TokePlayerSpawnFreq
    {
        get { return playerSpawnFreq; }
        set { playerSpawnFreq = value; }
    }
    public bool TimeLimitEnabled
    {
        get { return timeLimitEnabled; }
        set { timeLimitEnabled = value; }
    }
    public Enums.GameType Type
    {
        get { return type; }
        set { type = value; }
    }
    public Dictionary<Enums.Tokens, Enums.Frequency> EnabledTokens
    {
        get { return enabledTokens; }
        set { enabledTokens = value; }
    }
    public List<Enums.Tokens> DefaultTokens
    {
        get { return defaultTokens; }
        set { defaultTokens = value; }
    }
    #endregion
}
