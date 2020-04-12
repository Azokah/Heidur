using Heidur.Entities.Components;
using Heidur.Entities.Processors;
using Heidur.Helpers;

namespace Heidur.Entities.Factories
{
	public static class SpriteFactory
	{
		public static SpriteComponent GetNewAnimatedSprite(string textureName)
		{
			var spriteComponent = new SpriteComponent()
			{
				TextureName = textureName,
				IsAnimated = true,
				TextureModifier = 1,
				//Texture = SpriteProcessor.GetTexture(textureName)
			};

			spriteComponent.AnimationComponent = AnimationFactory.GetNewAnimationComponent(spriteComponent);
			return spriteComponent;
		}

		public static SpriteComponent GetNewStaticSprite(string textureName)
		{
			var spriteComponent = new SpriteComponent()
			{
				TextureName = textureName,
				IsAnimated = false,
				TextureModifier = 1
			};

			return spriteComponent;
		}
	}
}
