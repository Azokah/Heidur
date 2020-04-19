using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Processors.Models.UI
{
	public interface IUIWindow
	{
		Rectangle WindowRectangle { get; set; }
		Texture2D WindowTexture { get; set; }

		void Draw(SpriteBatch spriteBatch);
	}
}
