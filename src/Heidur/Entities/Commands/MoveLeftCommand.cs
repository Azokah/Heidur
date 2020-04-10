using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
    public class MoveLeftCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.MoveLeft(player.PhysicsComponent);
        }
    }
}
