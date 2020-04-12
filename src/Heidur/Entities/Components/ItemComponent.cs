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

		public SpriteComponent SpriteComponent { get; set; }
	}
}
