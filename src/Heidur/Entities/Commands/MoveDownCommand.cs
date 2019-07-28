using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Commands
{
    public class MoveDownCommand : ICommand
    {
        public void execute(IUnit player)
        {
            player.MoveDown();
        }
    }
}
