using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
    public class StopMoveUpCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.StopMoveUp(player.physicsComponent);
        }
    }
}
