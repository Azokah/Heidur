using Heidur.Entities.Components;

namespace Heidur.Entities.Factories
{
	public static class ItemFactory
	{
		public static ItemComponent GetNewItem()
		{
			return GetNewItem(Constants.Item.DEFAULT_NAME, Constants.Item.DEFAULT_DESCRIPTION, Constants.Item.DEFAULT_ITEM_SWORD_TEXTURE,
				2, 2, 1, 4, 0, 1, 1, 0, 5);
		}

		public static ItemComponent GetNewItem(string name, string description, string textureName,
			int strength, int dexterity, int intelligence, int constitution, int spirit,
			int damage, int minDamage, int range, int hpbonus)

		{
			return new ItemComponent() {
				SpriteComponent = new SpriteComponent()
				{
					TextureName = textureName,
					IsAnimated = false
				},
				Name = name,
				Description = description,
				Equiped = false,
				StrengthBonus = strength,
				DexterityBonus = dexterity,
				IntelligenceBonus = intelligence,
				ConstitutionBonus = constitution,
				SpiritBonus = spirit,
				DamageBonus = damage,
				RangeBonus = range,
				HPBonus = hpbonus
			};
		}
	}
}
