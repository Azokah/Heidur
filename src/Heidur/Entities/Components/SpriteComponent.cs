using Microsoft.Xna.Framework.Graphics;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Components
{
    public class SpriteComponent
    {
        public string textureName { get; set; }
        public int textureModifier { get; set; }
        public Texture2D Texture { get; set; }
        public AnimationComponent AnimationComponent { get; set; }

        public SpriteComponent()
        {
            textureModifier = 1;
            textureName = string.Empty;
        }
    }
}
