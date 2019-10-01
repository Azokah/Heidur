using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Processors
{
    public static class SpriteProcessor
    {
        public static void Update(float deltaTime, SpriteComponent spriteComponent)
        {
            // Sprites do nothing yet, here updates animation i guess
        }

        public static void Draw(Camera camera, SpriteBatch spriteBatch, Vector2 position, SpriteComponent spriteComponent)
        {
            spriteBatch.Draw(spriteComponent.Texture, position - camera.position, Color.White);
        }

        public static void LoadContent(Game1 game, SpriteComponent spriteComponent)
        {
            spriteComponent.Texture = game.Content.Load<Texture2D>(Constants.Unit.DEFAULT_SPRITE);
        }
    }
}
