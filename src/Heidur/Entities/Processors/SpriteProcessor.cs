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
            var textureSizeModified = Constants.TILESIZE * spriteComponent.textureModifier;
            var originVectorModified = spriteComponent.textureModifier == 1 ? Vector2.Zero : new Vector2(textureSizeModified/2, textureSizeModified/2);
            spriteBatch.Draw(spriteComponent.Texture, position - camera.position, new Rectangle(0, 0, textureSizeModified, textureSizeModified), Color.White, 0, originVectorModified, 1, SpriteEffects.None, Constants.Sprites.DEFAULT_UNIT_INDEX);
        }

        public static void LoadContent(Game1 game, SpriteComponent spriteComponent)
        {
            spriteComponent.Texture = game.Content.Load<Texture2D>(!string.IsNullOrWhiteSpace(spriteComponent.textureName) ? spriteComponent.textureName : Constants.Unit.DEFAULT_SPRITE);
        }
    }
}
