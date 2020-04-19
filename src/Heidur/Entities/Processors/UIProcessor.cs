using Heidur.Entities.Processors.Models.UI;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Heidur.Entities.Processors
{
	public static class UIProcessor
    {
		public static SpriteFont font = null;
		public static Texture2D crosshair = null;
		public static UIStatsWindow statsWindow = null;
		public static List<UIFloatingText> floatingTextList = new List<UIFloatingText>();
		public static Clock internalClock = new Clock();

		public static void LoadContent(Game game)
		{
			font = game.Content.Load<SpriteFont>(Constants.UI.DEFAULT_UI_FONT);
			Color[] data = new Color[(Constants.TILESIZE * Constants.TILESIZE) * Constants.DEFAULT_ZOOMING_MODIFIER];
			crosshair = new Texture2D(game.GraphicsDevice, Constants.TILESIZE, Constants.TILESIZE);
			for (int i = 0; i < data.Length; ++i)
			{
				if (i <= Constants.TILESIZE * Constants.DEFAULT_ZOOMING_MODIFIER * 2)
				{
					data[i] = Color.Red;
				}
				else if (i >= (Constants.TILESIZE * Constants.TILESIZE * Constants.DEFAULT_ZOOMING_MODIFIER) - Constants.TILESIZE * Constants.DEFAULT_ZOOMING_MODIFIER * 2)
				{
					data[i] = Color.Red;
				}
				else if (i%Constants.TILESIZE * Constants.DEFAULT_ZOOMING_MODIFIER <= 2 )
				{
					data[i] = Color.Red;
				}
				else if (i % Constants.TILESIZE * Constants.DEFAULT_ZOOMING_MODIFIER >= Constants.TILESIZE * Constants.DEFAULT_ZOOMING_MODIFIER - 2)
				{
					data[i] = Color.Red;
				}
			}
				
			crosshair.SetData(data);
			statsWindow = new UIStatsWindow(game);

		}

		public static void Draw(SpriteBatch spriteBatch, GameObject player)
		{
			spriteBatch.DrawString(font, player.StatsComponent.CurrentHP.ToString() + "/" + player.StatsComponent.HP.ToString(), Constants.UI.DEFAULT_UI_POSITION, Constants.UI.DEFAULT_UI_COLOR);
			spriteBatch.DrawString(font, "Level: " + player.StatsComponent.Level.ToString(), Constants.UI.DEFAULT_UI_POSITION + Constants.UI.DEFAULT_UI_POSITION_INCREMENT_Y, Constants.UI.DEFAULT_UI_COLOR);
			if (player.PhysicsComponent.objective != null)
			{
				spriteBatch.Draw(crosshair, (player.PhysicsComponent.objective.PhysicsComponent.position - Camera.position) * Constants.DEFAULT_ZOOMING_MODIFIER, Color.White);
			}

			foreach (var floatingText in floatingTextList)
			{
				spriteBatch.DrawString(font, floatingText.text, (floatingText.position - Camera.position) * Constants.DEFAULT_ZOOMING_MODIFIER, floatingText.color);
			}

			if (statsWindow.Enabled)
			{
				statsWindow.Draw(spriteBatch);
			}
		}

		public static void DrawText(SpriteBatch spriteBatch, string text, Vector2 position, Color color)
		{
			spriteBatch.DrawString(font, text, position, color);
		}

		public static void DrawWindow(SpriteBatch spriteBatch, IUIWindow window)
		{
			spriteBatch.Draw(window.WindowTexture, window.WindowRectangle, Color.White);
		}

		public static void Update(float delta)
		{
			internalClock.Update(delta);
			floatingTextList.ForEach(t => t.position.Y--);

			foreach (var item in floatingTextList.Where(e => e.finalTimestamp < internalClock.Value).ToList())
			{
				floatingTextList.Remove(item);
			}
		}

		public static void SetFloatingText(float msDuration, string text, Vector2 position, Color color)
		{
			floatingTextList.Add(new UIFloatingText()
			{
				finalTimestamp = internalClock.Value + msDuration,
				text = text,
				position = position,
				color = color
			});
		}

		public static void ShowStats(GameObject player, bool stats)
		{
			statsWindow.SetComponents(player);
			statsWindow.Enabled = stats;
		}
	}
}
