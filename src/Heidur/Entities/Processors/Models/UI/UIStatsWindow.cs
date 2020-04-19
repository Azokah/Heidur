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
				UIProcessor.DrawText(spriteBatch, component.TextString, new Vector2(component.Position.X, component.Position.Y), Color.GreenYellow);
			}
		}

		public void SetComponents(GameObject unit)
		{
			Components = new List<UITextButton>()
			{
				new UITextButton()
				{
					TextString = "Strength: " + unit.StatsComponent.GetStrength(),
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y,
						Convert.ToInt32(UIProcessor.font.MeasureString("Strength: " + unit.StatsComponent.GetStrength()).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Strength: " + unit.StatsComponent.GetStrength()).Y))
				},
				new UITextButton()
				{
					TextString = "Dexterity: " + unit.StatsComponent.GetDexterity(),
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE,
						Convert.ToInt32(UIProcessor.font.MeasureString("Dexterity: " + unit.StatsComponent.GetDexterity()).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Dexterity: " + unit.StatsComponent.GetDexterity()).Y))
				},
				new UITextButton()
				{
					TextString = "Intelligence: " + unit.StatsComponent.GetIntelligence(),
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 2,
						Convert.ToInt32(UIProcessor.font.MeasureString("Intelligence: " + unit.StatsComponent.GetIntelligence()).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Intelligence: " + unit.StatsComponent.GetIntelligence()).Y))
				},
				new UITextButton()
				{
					TextString = "Constitution: " + unit.StatsComponent.GetConstitution(),
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 3,
						Convert.ToInt32(UIProcessor.font.MeasureString("Constitution: " + unit.StatsComponent.GetConstitution()).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Constitution: " + unit.StatsComponent.GetConstitution()).Y))
				},
				new UITextButton()
				{
					TextString = "Spirit: " + unit.StatsComponent.GetSpirit(),
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 4,
						Convert.ToInt32(UIProcessor.font.MeasureString("Spirit: " + unit.StatsComponent.GetSpirit()).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Spirit: " + unit.StatsComponent.GetSpirit()).Y))
				},
				new UITextButton()
				{
					TextString = "Damage: " + unit.StatsComponent.GetMinDamage() + "/" + unit.StatsComponent.GetMaxDamage(),
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 5,
						Convert.ToInt32(UIProcessor.font.MeasureString("Damage: " + unit.StatsComponent.GetMinDamage() + "/" + unit.StatsComponent.GetMaxDamage()).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Damage: " + unit.StatsComponent.GetMinDamage() + "/" + unit.StatsComponent.GetMaxDamage()).Y))
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
					TextString = "Learning points: " + unit.StatsComponent.LearningPoints,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 7,
						Convert.ToInt32(UIProcessor.font.MeasureString("Learning points: " + unit.StatsComponent.LearningPoints).X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Learning points: " + unit.StatsComponent.LearningPoints).Y))
				},
				new UITextButton()
				{
					TextString = "Close window",
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * 8,
						Convert.ToInt32(UIProcessor.font.MeasureString("Close window").X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Close window").Y)),
					Action = () =>
					{
						Enabled = false;
					}
				}
			};
			WindowRectangle = new Rectangle(WindowRectangle.X, WindowRectangle.Y, WindowRectangle.Width, (Components.Count + 1) * Constants.UI.DEFAULT_UI_FONT_SIZE);
		}
	}
}
