using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
    public class StopMoveLeftCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.StopMoveLeft(player.physicsComponent);
        }
    }
}
