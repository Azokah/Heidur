using Heidur.Entities.GameObjects;
using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
	public class MoveDownCommand : ICommand
    {
        public void execute(GameObject player)
        {
            PhysicsProcessor.MoveDown(player.PhysicsComponent);
        }
    }
}
