using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
	public class ShowInventoryCommand : ICommand
    {
        public void execute(GameObject player)
        {
			UIProcessor.ShowInventory(player);
        }
    }
}
