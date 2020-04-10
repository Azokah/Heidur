using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
    public class StopMoveDownCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.StopMoveDown(player.PhysicsComponent);
        }
    }
}
