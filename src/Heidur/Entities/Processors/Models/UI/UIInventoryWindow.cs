using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Heidur.Entities.Processors.Models.UI
{
	public class UIInventoryWindow : IUIWindow
	{
		public List<UITextButton> Components { get; set; }
		public Rectangle WindowRectangle { get; set; }
		public Texture2D WindowTexture { get; set; }
		public bool Enabled { get; set; }

		public UIInventoryWindow(Game game)
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
					TextString = "Inventory: ",
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y,
						Convert.ToInt32(UIProcessor.font.MeasureString("Inventory: ").X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Inventory: ").Y))
				}
			};

			var counter = 2;
			unit.Inventory.ForEach(item =>
			{
				Components.Add(new UITextButton()
				{
					TextString = item.Name,
					Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * counter,
						Convert.ToInt32(UIProcessor.font.MeasureString(item.Name).X),
						Convert.ToInt32(UIProcessor.font.MeasureString(item.Name).Y))
				});

				Components.Add(new UITextButton()
				{
					TextString = "- Equip",
					Position = new Rectangle(
						WindowRectangle.X + Convert.ToInt32(UIProcessor.font.MeasureString(item.Name).X),
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * counter,
						Convert.ToInt32(UIProcessor.font.MeasureString("- Equip").X),
						Convert.ToInt32(UIProcessor.font.MeasureString("- Equip").Y)),
					Action = () =>
					{
						if (!item.Equiped)
						{
							ItemsProcessor.Equip(unit, item);
						}
					}
				});

				Components.Add(new UITextButton()
				{
					TextString = "- Unequip",
					Position = new Rectangle(
						WindowRectangle.X + Convert.ToInt32(UIProcessor.font.MeasureString(item.Name + "- Equip").X),
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * counter,
						Convert.ToInt32(UIProcessor.font.MeasureString("- Unequip").X),
						Convert.ToInt32(UIProcessor.font.MeasureString("- Unequip").Y)),
					Action = () =>
					{
						if (item.Equiped)
						{
							ItemsProcessor.Unequip(unit, item);
						}
					}
				});

				counter++;
			});

			Components.Add(new UITextButton()
			{
				TextString = "Close window",
				Position = new Rectangle(
						WindowRectangle.X,
						WindowRectangle.Y + Constants.UI.DEFAULT_UI_FONT_SIZE * counter,
						Convert.ToInt32(UIProcessor.font.MeasureString("Close window").X),
						Convert.ToInt32(UIProcessor.font.MeasureString("Close window").Y)),
				Action = () =>
				{
					Enabled = false;
				}
			});

			var minWidth = 0;
			Components.ForEach(c => 
			{
				minWidth = minWidth < c.Position.X + c.Position.Width - WindowRectangle.X ?
				c.Position.X + c.Position.Width - WindowRectangle.X :
				minWidth;
			});

			WindowRectangle = new Rectangle(
				WindowRectangle.X,
				WindowRectangle.Y,
				minWidth,
				(Components.Count + 1) * Constants.UI.DEFAULT_UI_FONT_SIZE);
		}
	}
}
