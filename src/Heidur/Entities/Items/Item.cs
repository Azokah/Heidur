using Heidur.Entities.Components;
using Heidur.Entities.Processors;

namespace Heidur.Entities.Items
{
	public class Item : IItem
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Equiped { get; set; }
		public StatsComponent statsComponent { get; set; }
		public SpriteComponent spriteComponent { get; set; }
		//Should inherint from gameobject?

		public Item()
		{
			statsComponent = new StatsComponent(0, 9, 25, 0, 0);
			spriteComponent = new SpriteComponent(Constants.Item.DEFAULT_ITEM_TEXTURE);
			Name = Constants.Item.DEFAULT_NAME;
			Description = Constants.Item.DEFAULT_DESCRIPTION;
			Equiped = false;
		}

		public Item(string name, string description, string textureName)
		{
			statsComponent = new StatsComponent();
			spriteComponent = new SpriteComponent(textureName);
			Name = name;
			Description = description;
			Equiped = false;
		}

		public void LoadContent(Game1 game)
		{
			SpriteProcessor.LoadContent(game, spriteComponent);
		}
	}
}
