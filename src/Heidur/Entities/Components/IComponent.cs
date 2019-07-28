using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Components
{
    public interface IComponent
    {
        void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map);
    }
}
