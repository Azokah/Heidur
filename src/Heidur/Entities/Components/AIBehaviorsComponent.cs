using Heidur.Helpers;

namespace Heidur.Entities.Components
{
    public class AIBehaviorsComponent
    {
        public float IdleMovementInterval;
        public Clock Clock;

        public AIBehaviorsComponent()
        {
            IdleMovementInterval = 0;
            Clock = new Clock();
        }
    }
}
