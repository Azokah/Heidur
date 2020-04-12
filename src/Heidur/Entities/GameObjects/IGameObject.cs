using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heidur.Entities.GameObjects
{
	public interface IGameObject
    {
        void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map);

        void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
