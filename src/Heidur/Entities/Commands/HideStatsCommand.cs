using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
	public class HideStatsCommand : ICommand
    {
        public void execute(GameObject player)
        {
			UIProcessor.ShowStats(player, false);
        }
    }
}
