using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public interface IGameObject
    {
        void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map);

        void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
