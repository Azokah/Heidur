using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
    public class MoveRightCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.MoveRight(player.PhysicsComponent);
        }
    }
}
