using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Processors
{
    public static class SpriteProcessor
    {
        public static bool drawHitBoxes = false;

        public static void Update(float deltaTime, SpriteComponent spriteComponent)
        {
            AnimationProcessor.Update(spriteComponent.AnimationComponent, deltaTime);
        }

        public static void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteComponent spriteComponent, FacingDirections FacingDirection)
        {
            var textureSizeModified = Constants.TILESIZE * spriteComponent.textureModifier;
            var originVectorModified = spriteComponent.textureModifier == 1 ? Vector2.Zero : new Vector2(textureSizeModified/3, textureSizeModified/2);
			var pot = position - Camera.position;

			DrawHitBoxes(spriteBatch, position, spriteComponent);
            spriteBatch.Draw(spriteComponent.Texture, position - Camera.position, AnimationProcessor.GetFrame(spriteComponent.AnimationComponent), Color.White, 0, originVectorModified, 1, SpriteEffects.None, Constants.Sprites.DEFAULT_UNIT_INDEX);
        }

        public static void LoadContent(Game1 game, SpriteComponent spriteComponent)
        {
            spriteComponent.Texture = game.Content.Load<Texture2D>(!string.IsNullOrWhiteSpace(spriteComponent.textureName) ? spriteComponent.textureName : Constants.Unit.DEFAULT_SPRITE);
            spriteComponent.AnimationComponent = new AnimationComponent(spriteComponent,Constants.Animation.DEFAULT_FRAMES_WALKING);
        }

        private static void DrawHitBoxes(SpriteBatch spriteBatch, Vector2 position, SpriteComponent spriteComponent)
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

                Vector2 coor = position - Camera.position;
                spriteBatch.Draw(rect, coor, null, Color.White, 0, originVectorModified, 1, SpriteEffects.None, Constants.Sprites.DEFAULT_UNIT_INDEX);
            }
        }
    }
}
