using UnityEngine;

namespace Assets.Scripts.Timers
{
    // Timer used for counting down
    public class CountdownTimer : Timer
    {
        // Delegates and events to fire once timer times out
        new public delegate void TimerEvent(CountdownTimer t);
        new public event TimerEvent TimeOut;

        public override void Initialize(float interval, string id)
        {
            base.Initialize(interval, id);
            timer = interval;
        }

        protected override void UpdateTimer()
        {
            if (on)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 0;
                    // If the event has subscribers, fire it
                    if (TimeOut != null) TimeOut(this);
                    Destroy(this);
                }
            }
        }
    }
}
