using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Components
{
	public class SpriteComponent
    {
        public string TextureName { get; set; }
        public int TextureModifier { get; set; }
        public Texture2D Texture { get; set; }
        public AnimationComponent AnimationComponent { get; set; }

        public SpriteComponent()
        {
            TextureModifier = 1;
            TextureName = string.Empty;
        }

		public SpriteComponent(string textureName)
		{
			TextureModifier = 1;
			this.TextureName = textureName;
		}
	}
}
