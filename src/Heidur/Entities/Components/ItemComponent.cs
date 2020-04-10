namespace Heidur.Entities.Components
{
	public class ItemComponent
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Equiped { get; set; }
		public int StrengthBonus { get; set; }
		public int DexterityBonus { get; set; }
		public int IntelligenceBonus { get; set; }
		public int ConstitutionBonus { get; set; }
		public int SpiritBonus { get; set; }
		public int DamageBonus { get; set; }
		public int RangeBonus { get; set; }
		public int HPBonus { get; set; }

		public SpriteComponent spriteComponent { get; set; }

		public ItemComponent()
		{
			spriteComponent = new SpriteComponent(Constants.Item.DEFAULT_ITEM_TEXTURE);
			Name = Constants.Item.DEFAULT_NAME;
			Description = Constants.Item.DEFAULT_DESCRIPTION;
			Equiped = false;
			StrengthBonus = 2;
			DexterityBonus = 2;
			IntelligenceBonus = 1;
			ConstitutionBonus = 4;
			SpiritBonus = 0;
			DamageBonus = 1;
			RangeBonus = 0;
			HPBonus = 5;
	}

		public ItemComponent(string name, string description, string textureName,
			int strength, int dexterity, int intelligence, int constitution, int spirit,
			int damage, int range, int hpbonus)
		{
			spriteComponent = new SpriteComponent(textureName);
			Name = name;
			Description = description;
			Equiped = false;
			StrengthBonus = strength;
			DexterityBonus = dexterity;
			IntelligenceBonus = intelligence;
			ConstitutionBonus = constitution;
			SpiritBonus = spirit;
			DamageBonus = damage;
			RangeBonus = range;
			HPBonus = hpbonus;
		}
	}
}
