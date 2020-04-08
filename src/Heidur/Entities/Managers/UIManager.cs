using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Managers
{
	public class UIManager
	{
		public SpriteFont font;

		public void LoadContent(Game game)
		{
			font = game.Content.Load<SpriteFont>(Constants.UI.DEFAULT_UI_FONT);
		}

		public void Draw(SpriteBatch spriteBatch, StatsComponent statsComponent)
		{
			spriteBatch.DrawString(font, statsComponent.CurrentHP.ToString() + "/" + statsComponent.HP.ToString(), Constants.UI.DEFAULT_UI_POSITION, Constants.UI.DEFAULT_UI_COLOR);
			spriteBatch.DrawString(font, "EXP: " + statsComponent.Experience.ToString(), Constants.UI.DEFAULT_UI_POSITION + Constants.UI.DEFAULT_UI_POSITION_INCREMENT_Y, Constants.UI.DEFAULT_UI_COLOR);
		}
	}
}
