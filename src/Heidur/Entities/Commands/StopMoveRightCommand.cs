using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
    public class StopMoveRightCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.StopMoveRight(player.physicsComponent);
        }
    }
}
