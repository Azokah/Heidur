using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Heidur.Entities.Processors
{
	public static class SpriteProcessor
    {
        public static bool drawHitBoxes = false;
		public static Dictionary<string, Texture2D> textureAtlas = new Dictionary<string, Texture2D>();


		public static void Update(float deltaTime, SpriteComponent spriteComponent)
        {
            AnimationProcessor.Update(spriteComponent.AnimationComponent, deltaTime);
        }

		public static void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteComponent spriteComponent)
		{
			var textureSizeModified = Constants.TILESIZE * spriteComponent.TextureModifier;
			var originVectorModified = spriteComponent.TextureModifier == 1 ? Vector2.Zero : new Vector2(textureSizeModified / 3, textureSizeModified / 2);
			var pot = position - Camera.position;

			DrawHitBoxes(spriteBatch, position, spriteComponent);
			if (spriteComponent.IsAnimated)
			{
				spriteBatch.Draw(spriteComponent.Texture, position - Camera.position, AnimationProcessor.GetFrame(spriteComponent.AnimationComponent), Color.White, 0, originVectorModified, 1, SpriteEffects.None, Constants.Sprites.DEFAULT_UNIT_INDEX);
			}
			else
			{
				spriteBatch.Draw(spriteComponent.Texture, position - Camera.position, null, Color.White, 0, originVectorModified, 1, SpriteEffects.None, Constants.Sprites.DEFAULT_UNIT_INDEX);
			}

		}

		public static void LoadContent(Game1 game)
		{
			foreach(var texture in Constants.Sprites.TEXTURES_LIST)
			{
				textureAtlas.Add(texture, game.Content.Load<Texture2D>(texture));
			}
			
		}

		public static void GetTexture(SpriteComponent spriteComponent)
        {
			spriteComponent.Texture = GetTexture(spriteComponent.TextureName);
		}

		public static Texture2D GetTexture(string textureName)
		{
			return textureAtlas.ContainsKey(textureName) ? textureAtlas[textureName] : textureAtlas[Constants.Sprites.MISSING_TEXTURE];
		}

		private static void DrawHitBoxes(SpriteBatch spriteBatch, Vector2 position, SpriteComponent spriteComponent)
        {
            if (drawHitBoxes)
            {
                var textureSizeModified = Constants.TILESIZE * spriteComponent.TextureModifier;
                var originVectorModified = spriteComponent.TextureModifier == 1 ? Vector2.Zero : new Vector2(textureSizeModified / 2, textureSizeModified / 2);

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
