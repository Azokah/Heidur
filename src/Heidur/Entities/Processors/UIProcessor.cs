﻿using Heidur.Entities.Managers.Models;
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
		public static List<UIFloatingText> floatingTextList = new List<UIFloatingText>();
		public static Clock internalClock = new Clock();

		public static void LoadContent(Game game)
		{
			font = game.Content.Load<SpriteFont>(Constants.UI.DEFAULT_UI_FONT);
			crosshair = game.Content.Load<Texture2D>(Constants.UI.DEFAULT_CROSSHAIR_SPRITE);
		}

		public static void Draw(SpriteBatch spriteBatch, GameObject player)
		{
			spriteBatch.DrawString(font, player.statsComponent.CurrentHP.ToString() + "/" + player.statsComponent.HP.ToString(), Constants.UI.DEFAULT_UI_POSITION, Constants.UI.DEFAULT_UI_COLOR);
			spriteBatch.DrawString(font, "EXP: " + player.statsComponent.Experience.ToString(), Constants.UI.DEFAULT_UI_POSITION + Constants.UI.DEFAULT_UI_POSITION_INCREMENT_Y, Constants.UI.DEFAULT_UI_COLOR);
			spriteBatch.DrawString(font, "Level: " + player.statsComponent.Level.ToString(), Constants.UI.DEFAULT_UI_POSITION + Constants.UI.DEFAULT_UI_POSITION_INCREMENT_Y * 2, Constants.UI.DEFAULT_UI_COLOR);
			if (player.physicsComponent.objective != null)
			{
				spriteBatch.Draw(crosshair, (player.physicsComponent.objective.physicsComponent.position - Camera.position) * Constants.DEFAULT_ZOOMING_MODIFIER, Color.White);
			}

			foreach (var floatingText in floatingTextList)
			{
				spriteBatch.DrawString(font, floatingText.text, floatingText.position, floatingText.color);
			}
		}

		public static void Update(float delta)
		{
			internalClock.Update(delta);

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
				position = (position-Camera.position)*Constants.DEFAULT_ZOOMING_MODIFIER,
				color = color
			});
		}
	}
}
