using Heidur.Entities.Processors;
using Heidur.Entities.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Commands
{
    public class AttackCommand : ICommand
    {
        public void execute(GameObject player)
        {
            player.skillSet.Where(s => s is MeleeSkill).FirstOrDefault().Execute(player);
        }
    }
}
