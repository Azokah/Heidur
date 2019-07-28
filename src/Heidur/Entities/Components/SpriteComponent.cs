using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Components
{
    public class SpriteComponent : IComponent
    {
        public Texture2D Texture { get; set; }

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            // Sprites do nothing
        }

        public void Draw(Camera camera, SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(this.Texture, position - camera.position, Color.White);
        }

        public void LoadContent(Game1 game)
        {
            this.Texture = game.Content.Load<Texture2D>(Constants.Unit.DEFAULT_SPRITE);
        }
    }
}
