using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Commands
{
    public class MoveLeftCommand : ICommand
    {
        public void execute(GameObject player)
        {
            player.physicsComponent.MoveLeft();
        }
    }
}
