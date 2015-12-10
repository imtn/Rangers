using System;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.Timers
{
    // Functions like a normal timer with the added benefit of having the IDs being related to tokens
    public class TokenTimer : Timer
    {
        // Delegates and events to fire once timer times out
        new public delegate void TimerEvent(TokenTimer t);
        new public event TimerEvent TimeOut;

        protected Enums.Arrows tokenType;

        public static float TOKEN_INTERVAL = 5f;

        // Overriding the initialize method. Use the token type.ToString() as id
        public override void Initialize(float interval, string id)
        {
            base.Initialize(interval, id);
            tokenType = (Enums.Arrows)Enum.Parse(typeof(Enums.Arrows), id);
        }

        protected override void FireTimerEvent()
        {
            // If the event has subscribers, fire it
            if (TimeOut != null) TimeOut(this);
        }

        public Enums.Arrows TokenType
        {
            get { return tokenType; }
        }
    } 
}
