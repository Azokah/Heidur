using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Heidur.Entities.Processors.Models.UI
{
	public class UITextButton : IUIText, IUIAction
	{
		public string TextString { get; set; }
		public Vector2 Position { get; set; }
		public Action Action { get; set; }

		public void Execute()
		{
			Action();
		}
	}
}
