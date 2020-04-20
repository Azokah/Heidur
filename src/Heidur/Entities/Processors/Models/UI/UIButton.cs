using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Heidur.Entities.Processors.Models.UI
{
	public class UIButton : IUISprite, IUIAction, IUIPosition
	{
		public Texture2D Sprite { get; set; }
		public Rectangle Position { get; set; }
		public Action Action { get; set; }

		public void Execute()
		{
			Action?.Invoke();
		}
	}
}
