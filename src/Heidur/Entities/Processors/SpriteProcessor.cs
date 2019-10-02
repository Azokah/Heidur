using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Processors
{
    public static class SpriteProcessor
    {
        public static bool drawHitBoxes = false;

        public static void Update(float deltaTime, SpriteComponent spriteComponent)
        {
            // Sprites do nothing yet, here updates animation i guess
        }

        public static void Draw(Camera camera, SpriteBatch spriteBatch, Vector2 position, SpriteComponent spriteComponent)
        {
            var textureSizeModified = Constants.TILESIZE * spriteComponent.textureModifier;
            var originVectorModified = spriteComponent.textureModifier == 1 ? Vector2.Zero : new Vector2(textureSizeModified/3, textureSizeModified/2);

            DrawHitBoxes(camera, spriteBatch, position, spriteComponent);
            spriteBatch.Draw(spriteComponent.Texture, position - camera.position, new Rectangle(0, 0, textureSizeModified, textureSizeModified), Color.White, 0, originVectorModified, 1, SpriteEffects.None, Constants.Sprites.DEFAULT_UNIT_INDEX);
        }

        public static void LoadContent(Game1 game, SpriteComponent spriteComponent)
        {
            spriteComponent.Texture = game.Content.Load<Texture2D>(!string.IsNullOrWhiteSpace(spriteComponent.textureName) ? spriteComponent.textureName : Constants.Unit.DEFAULT_SPRITE);
        }

        private static void DrawHitBoxes(Camera camera, SpriteBatch spriteBatch, Vector2 position, SpriteComponent spriteComponent)
        {
            if (drawHitBoxes)
            {
                var textureSizeModified = Constants.TILESIZE * spriteComponent.textureModifier;
                var originVectorModified = spriteComponent.textureModifier == 1 ? Vector2.Zero : new Vector2(textureSizeModified / 2, textureSizeModified / 2);

                Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, textureSizeModified, textureSizeModified);
                Color[] data = new Color[textureSizeModified * textureSizeModified];
                for (int i = 0; i < data.Length; ++i)
                {
                    data[i] = Color.Fuchsia;
                }

                rect.SetData(data);

                Vector2 coor = position - camera.position;
                spriteBatch.Draw(rect, coor, null, Color.White, 0, originVectorModified, 1, SpriteEffects.None, Constants.Sprites.DEFAULT_UNIT_INDEX);
            }
        }
    }
}
