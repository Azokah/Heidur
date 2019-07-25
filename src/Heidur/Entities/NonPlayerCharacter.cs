using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public class NonPlayerCharacter : Unit
    {
        public new void Init()
        {
            base.Init();
            
            Random random = new Random(Guid.NewGuid().GetHashCode());
            this.position = new Vector2(random.Next(Constants.Map.DEFAULT_MAP_WIDTH) * Constants.TILESIZE, random.Next(Constants.Map.DEFAULT_MAP_HEIGHT) * Constants.TILESIZE);
            destination = position;
        }
    }
}
