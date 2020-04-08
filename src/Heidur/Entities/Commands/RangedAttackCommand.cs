using Heidur.Entities.Skills;
using System.Linq;

namespace Heidur.Entities.Commands
{
	public class RangedAttackCommand : ICommand
    {
        public void execute(GameObject player)
        {
            player.skillSet.Where(s => s is RangedSkill).FirstOrDefault().Execute(player);
        }
    }
}
