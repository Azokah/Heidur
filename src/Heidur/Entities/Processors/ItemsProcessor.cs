using Heidur.Entities.Components;
using Heidur.Entities.GameObjects;
using System.Linq;

namespace Heidur.Entities.Processors
{
	public static class ItemsProcessor
    {
		public static void LoadContent(ItemComponent item)
		{
			SpriteProcessor.GetTexture(item.SpriteComponent);
		}

		public static void Equip(GameObject bearer, ItemComponent item)
        {
			if (bearer.Inventory.Exists(i => i.Name.Equals(item.Name) && !i.Equiped))
			{
				bearer.StatsComponent.ItemStrength += item.StrengthBonus;
				bearer.StatsComponent.ItemDexterity += item.DexterityBonus;
				bearer.StatsComponent.ItemIntelligence += item.IntelligenceBonus;
				bearer.StatsComponent.ItemConstitution += item.ConstitutionBonus;
				bearer.StatsComponent.ItemSpirit += item.SpiritBonus;
				bearer.StatsComponent.ItemRange += item.RangeBonus;
				bearer.StatsComponent.ItemMaxDamage += item.DamageBonus;
				bearer.StatsComponent.ItemHp += item.HPBonus;
				item.Equiped = true;
			}
		}

		public static void Unequip(GameObject bearer, ItemComponent item)
		{
			if (bearer.Inventory.Exists(i => i.Name.Equals(item.Name) && i.Equiped))
			{
				bearer.StatsComponent.ItemStrength -= item.StrengthBonus;
				bearer.StatsComponent.ItemDexterity -= item.DexterityBonus;
				bearer.StatsComponent.ItemIntelligence -= item.IntelligenceBonus;
				bearer.StatsComponent.ItemConstitution -= item.ConstitutionBonus;
				bearer.StatsComponent.ItemSpirit -= item.SpiritBonus;
				bearer.StatsComponent.ItemRange -= item.RangeBonus;
				bearer.StatsComponent.ItemMaxDamage -= item.DamageBonus;
				bearer.StatsComponent.ItemHp -= item.HPBonus;
				item.Equiped = false;
			}
		}

		public static void EquipAll(GameObject bearer)
		{
			foreach(var item in bearer.Inventory)
			{
				Equip(bearer, item);
			}
		}

		public static void UnEquipAll(GameObject bearer)
		{
			foreach (var item in bearer.Inventory)
			{
				Unequip(bearer, item);
			}
		}
	}
}
