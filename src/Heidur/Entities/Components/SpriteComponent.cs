using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Components
{
	public class SpriteComponent
    {
        public string TextureName { get; set; }
        public int TextureModifier { get; set; }
		public bool IsAnimated { get; set; }
        public Texture2D Texture { get; set; }
		public AnimationComponent AnimationComponent { get; set; }
	}
}
