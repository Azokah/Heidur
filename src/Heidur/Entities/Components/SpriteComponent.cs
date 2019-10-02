using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Components
{
    public class SpriteComponent
    {
        public string textureName { get; set; }
        public int textureModifier { get; set; }
        public Texture2D Texture { get; set; }


        public SpriteComponent()
        {
            textureModifier = 1;
            textureName = string.Empty;
        }
    }
}
