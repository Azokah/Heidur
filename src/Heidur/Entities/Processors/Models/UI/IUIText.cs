using Microsoft.Xna.Framework;

namespace Heidur.Entities.Processors.Models.UI
{
	public interface IUIText
	{
		string TextString { get; set; }
		Rectangle Position { get; set; }
	}
}
