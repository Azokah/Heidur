using Microsoft.Xna.Framework;
using System;

namespace Heidur.Entities.Processors.Models.UI
{
	public class UITextButton : IUIText, IUIAction
	{
		public string TextString { get; set; }
		public Rectangle Position { get; set; }
		public Action Action { get; set; }

		public void Execute()
		{
			Action();
		}
	}
}
