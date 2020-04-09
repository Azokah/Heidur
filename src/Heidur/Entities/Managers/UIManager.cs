using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Heidur.Entities.Managers
{
	public class UIManager
	{
		public SpriteFont font;
		public Texture2D crosshair;

		public void LoadContent(Game game)
		{
			font = game.Content.Load<SpriteFont>(Constants.UI.DEFAULT_UI_FONT);
			crosshair = game.Content.Load<Texture2D>(Constants.UI.DEFAULT_CROSSHAIR_SPRITE);
		}

		public void Draw(SpriteBatch spriteBatch, GameObject player)
		{
			spriteBatch.DrawString(font, player.statsComponent.CurrentHP.ToString() + "/" + player.statsComponent.HP.ToString(), Constants.UI.DEFAULT_UI_POSITION, Constants.UI.DEFAULT_UI_COLOR);
			spriteBatch.DrawString(font, "EXP: " + player.statsComponent.Experience.ToString(), Constants.UI.DEFAULT_UI_POSITION + Constants.UI.DEFAULT_UI_POSITION_INCREMENT_Y, Constants.UI.DEFAULT_UI_COLOR);
			spriteBatch.DrawString(font, "Level: " + player.statsComponent.Level.ToString(), Constants.UI.DEFAULT_UI_POSITION + Constants.UI.DEFAULT_UI_POSITION_INCREMENT_Y * 2, Constants.UI.DEFAULT_UI_COLOR);
			if (player.physicsComponent.objective != null)
			{
				spriteBatch.Draw(crosshair, (player.physicsComponent.objective.physicsComponent.position - Camera.position) * Constants.DEFAULT_ZOOMING_MODIFIER, Color.White);
			}
		}
	}
}
