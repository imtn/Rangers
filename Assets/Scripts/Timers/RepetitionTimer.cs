using UnityEngine;
using Assets.Scripts.Util;

namespace Assets.Scripts.Timers
{
    public class RepetitionTimer : Timer
    {
        // Delegates and events to fire once timer times out
        new public delegate void TimerEvent(RepetitionTimer t);
        new public event TimerEvent TimeOut;

        private Enums.RepetitionTimerSettings type;
        private int repeat = 0;

        // Override the initialization for timers
        public override void Initialize(float interval, string id)
        {
            // Call base
            base.Initialize(interval, id);
            // Repeat will be unused
            repeat = 0;
            // Timer will repeat forever
            type = Enums.RepetitionTimerSettings.Unlimited;
        }

        // Initializing the timer and turning it on
        public void Initialize(float interval, string id, int repeat = 0)
        {
            // Call base
            base.Initialize(interval, id);
            // Timer will repeat a limited number of times
            type = Enums.RepetitionTimerSettings.Limited;
            // Timer will repeat based on the number that was passed in
            this.repeat = repeat;
        }

        // How the timer counts
        protected override void UpdateTimer()
        {
            if (on)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    timer = interval;
                    // If the event has subscribers, fire it
                    if (TimeOut != null) TimeOut(this);
                    timer = 0;
                    if (type.Equals(Enums.RepetitionTimerSettings.Limited))
                    {
                        if (--repeat <= 0) Destroy(this);
                    }
                }
            }
        }
    }
}
