namespace Heidur.Helpers
{
    public class Clock
    {
        public float Value;
        public float lastTick;

        public Clock()
        {
            Value = 0;
            lastTick = 0;
        }

        public void Update(float deltaTime)
        {
            Value += deltaTime;
        }

        public bool isIntervalTicked(float interval)
        {
            if (Value > lastTick)
            {
                lastTick = Value + interval;
                return true;
            }

            return false;
        }
    }
}
