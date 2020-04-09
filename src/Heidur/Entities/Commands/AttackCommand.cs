using Heidur.Entities.Skills;
using System.Linq;

namespace Heidur.Entities.Commands
{
	public class AttackCommand : ICommand
    {
        public void execute(GameObject player)
        {
            player.SkillSet.Where(s => s is MeleeSkill).FirstOrDefault().Execute(player, player.PhysicsComponent.objective);
        }
    }
}
