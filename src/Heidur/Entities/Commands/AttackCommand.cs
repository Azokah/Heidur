using Heidur.Entities.Processors;
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
            StatsProcessor.Attack(player.statsComponent, player.physicsComponent);
        }
    }
}
