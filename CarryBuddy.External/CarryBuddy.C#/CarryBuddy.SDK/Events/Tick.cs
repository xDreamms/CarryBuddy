using CarryBuddy.SDK.Objects;

namespace CarryBuddy.SDK.Events
{
    public class Tick
    {
        private static Tick Instance { get; set; } = new Tick();
        private static Timer Ticker;

        private Tick()
        {
            Ticker = new Timer(1f);
            Ticker.Elapsed += OnTickElapsed;
            Ticker.Start();
            Instance = this;
        }

        public static ToggleResult Toggle(TickElapsed Value)
        {
            if (OnTick != null)
            {
                foreach (TickElapsed s in OnTick.GetInvocationList())
                {
                    if (s == Value)
                    {
                        OnTick -= Value;
                        return ToggleResult.Disabled;
                    }
                }
            }
            OnTick += Value;
            return ToggleResult.Enabled;
        }

        private static event TickElapsed OnTick;

        private static void OnTickElapsed(object Sender, TimerElapsedEventArgs e)
        {
            OnTick?.Invoke();
        }
    }

    public enum ToggleResult
    {
        Disabled,
        Enabled,
    }

    public delegate void TickElapsed();
}
