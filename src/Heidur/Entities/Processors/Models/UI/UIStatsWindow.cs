using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Heidur.Entities.Processors.Models.UI
{
	public class UIStatsWindow : IUIWindow
	{
		public List<UITextButton> Components { get; set; }
		public Rectangle WindowRectangle { get; set; }
		public Texture2D WindowTexture { get; set; }
		public bool Enabled { get; set; }

		public UIStatsWindow(Game game)
		{
			Enabled = false;
			WindowRectangle = new Rectangle(Constants.RESOLUTION_WIDTH / 3, 0, Constants.RESOLUTION_WIDTH / 3, Constants.RESOLUTION_HEIGHT / 3);
			Color[] data = new Color[WindowRectangle.Width * WindowRectangle.Height * Constants.DEFAULT_ZOOMING_MODIFIER];
			WindowTexture = new Texture2D(game.GraphicsDevice, WindowRectangle.Width, WindowRectangle.Height);
			for (int i = 0; i < data.Length; ++i)
			{
				data[i] = Color.Gray;
			}
			WindowTexture.SetData(data);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			UIProcessor.DrawWindow(spriteBatch, this);
			foreach(var component in Components)
			{
				UIProcessor.DrawText(spriteBatch, component.TextString, new Vector2(component.Position.X, component.Position.Y), Color.MediumVioletRed);
			}
		}

		public void SetComponents(GameObject unit)
		{
			Components = new List<UITextButton>()
			{
				new UITextButton()
				{
					TextString = "Strength: " + unit.StatsComponent.Strength,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y,
						Convert.ToInt32(UIProcessor.font.MeasureString("Strength: " + unit.StatsComponent.Strength).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Strength: " + unit.StatsComponent.Strength).Y))
				},
				new UITextButton()
				{
					TextString = "Dexterity: " + unit.StatsComponent.Dexterity,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE,
						Convert.ToInt32(UIProcessor.font.MeasureString("Dexterity: " + unit.StatsComponent.Dexterity).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Dexterity: " + unit.StatsComponent.Dexterity).Y))
				},
				new UITextButton()
				{
					TextString = "Intelligence: " + unit.StatsComponent.Intelligence,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 2,
						Convert.ToInt32(UIProcessor.font.MeasureString("Intelligence: " + unit.StatsComponent.Intelligence).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Intelligence: " + unit.StatsComponent.Intelligence).Y))
				},
				new UITextButton()
				{
					TextString = "Constitution: " + unit.StatsComponent.Constitution,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 3,
						Convert.ToInt32(UIProcessor.font.MeasureString("Constitution: " + unit.StatsComponent.Constitution).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Constitution: " + unit.StatsComponent.Constitution).Y))
				},
				new UITextButton()
				{
					TextString = "Spirit: " + unit.StatsComponent.Spirit,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 4,
						Convert.ToInt32(UIProcessor.font.MeasureString("Spirit: " + unit.StatsComponent.Spirit).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Spirit: " + unit.StatsComponent.Spirit).Y))
				},
				new UITextButton()
				{
					TextString = "Damage: " + unit.StatsComponent.Damage,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 5,
						Convert.ToInt32(UIProcessor.font.MeasureString("Damage: " + unit.StatsComponent.Damage).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Damage: " + unit.StatsComponent.Damage).Y))
				},
				new UITextButton()
				{
					TextString = "Experience: " + unit.StatsComponent.Experience,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 6,
						Convert.ToInt32(UIProcessor.font.MeasureString("Experience: " + unit.StatsComponent.Experience).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Experience: " + unit.StatsComponent.Experience).Y))
				},
				new UITextButton()
				{
					TextString = "HP: " + unit.StatsComponent.HP,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 7,
						Convert.ToInt32(UIProcessor.font.MeasureString("HP: " + unit.StatsComponent.HP).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("HP: " + unit.StatsComponent.HP).Y))
				}
			};
		}
	}
}
