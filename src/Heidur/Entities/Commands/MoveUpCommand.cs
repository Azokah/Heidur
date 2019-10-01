using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
    public class MoveUpCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.MoveUp(player.physicsComponent);
        }
    }
}
