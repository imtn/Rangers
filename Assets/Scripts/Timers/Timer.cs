using UnityEngine;
using System;

namespace Assets.Scripts.Timers
{
    // Timer class that can fire events
    public abstract class Timer : MonoBehaviour
    {
        // Delegates and events to fire once timer times out
        public delegate void TimerEvent(Timer t);
        public event TimerEvent TimeOut;

        // Interval is how long the timer will count for
        // Timer is the current time being counted
        protected float interval, timer = 0f;
        // Whether or not the timer is running
        protected bool on = false;
        // ID for identifying timers after they have started
        protected string id = "";

        // Initializing the timer and turning it on
        public virtual void Initialize(float interval, string id)
        {
            this.interval = interval;
            timer = 0f;
            this.id = id;
            on = true;
        }

        void Update()
        {
            UpdateTimer();
        }

        // How the timer counts
        protected virtual void UpdateTimer()
        {
            if (on)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    timer = interval;
                    FireTimerEvent();
                    Destroy(this);
                }
            }
        }

        // Resetting the timer, also turns it back on
        public virtual void Reset()
        {
            Initialize(interval, id);
        }

        protected virtual void FireTimerEvent()
        {
            // If the event has subscribers, fire it
            if (TimeOut != null)
            {
                TimeOut(this);
            }
        }

        #region C# Properties
        public bool Enabled
        {
            get { return on; }
            set { on = value; }
        }
        public string ID
        {
            get { return id; }
        }
        #endregion

        public override string ToString()
        {
            return timer.ToString();
        }

        public string ToString(int places = 2)
        {
            return Math.Round(timer, places).ToString();
        }
    }
}
