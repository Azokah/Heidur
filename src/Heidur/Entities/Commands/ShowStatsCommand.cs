using Heidur.Entities.Processors;

namespace Heidur.Entities.Commands
{
	public class ShowStatsCommand : ICommand
    {
        public void execute(GameObject player)
        {
			UIProcessor.ShowStats(player, true);
        }
    }
}
