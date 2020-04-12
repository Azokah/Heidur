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
			StatsProcessor.RemoveBonuses(bearer.StatsComponent);
            if(bearer.Inventory.Where(i => i.Name.Equals(item.Name) && !i.Equiped).First() != null)
			{
				bearer.StatsComponent.ItemStrength += item.StrengthBonus;
				bearer.StatsComponent.ItemDexterity += item.DexterityBonus;
				bearer.StatsComponent.ItemIntelligence += item.IntelligenceBonus;
				bearer.StatsComponent.ItemConstitution += item.ConstitutionBonus;
				bearer.StatsComponent.ItemSpirit += item.SpiritBonus;
				bearer.StatsComponent.ItemRange += item.RangeBonus;
				bearer.StatsComponent.ItemDamage += item.DamageBonus;
				bearer.StatsComponent.ItemHp += item.HPBonus;
				item.Equiped = true;
			}
			StatsProcessor.ApplyBonuses(bearer.StatsComponent);
			StatsProcessor.CalculateStats(bearer.StatsComponent);
		}

		public static void Unequip(GameObject bearer, ItemComponent item)
		{
			StatsProcessor.RemoveBonuses(bearer.StatsComponent);
			if (bearer.Inventory.Where(i => i.Name.Equals(item.Name) && i.Equiped).First() != null)
			{
				bearer.StatsComponent.ItemStrength -= item.StrengthBonus;
				bearer.StatsComponent.ItemDexterity -= item.DexterityBonus;
				bearer.StatsComponent.ItemIntelligence -= item.IntelligenceBonus;
				bearer.StatsComponent.ItemConstitution -= item.ConstitutionBonus;
				bearer.StatsComponent.ItemSpirit -= item.SpiritBonus;
				bearer.StatsComponent.ItemRange -= item.RangeBonus;
				bearer.StatsComponent.ItemDamage -= item.DamageBonus;
				bearer.StatsComponent.ItemHp -= item.HPBonus;
				item.Equiped = false;
			}
			StatsProcessor.ApplyBonuses(bearer.StatsComponent);
			StatsProcessor.CalculateStats(bearer.StatsComponent);
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
