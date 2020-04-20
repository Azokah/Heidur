using Heidur.Entities.GameObjects;
using Heidur.Entities.Skills;
using System.Linq;

namespace Heidur.Entities.Commands
{
	public class SpellAttackCommand : ICommand
    {
        public void execute(GameObject player)
        {
            player.SkillSet.Where(s => s is SpellSkill).FirstOrDefault().Execute(player, player.PhysicsComponent.objective);
        }
    }
}
