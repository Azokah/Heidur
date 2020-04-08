using Heidur.Entities.Items;
using System.Linq;

namespace Heidur.Entities.Processors
{
	public static class ItemsProcessor
    {
        public static void Equip(GameObject bearer, Item item)
        {
            if(bearer.inventory.Where(i => i is Item && ((Item) i).Name.Equals(item.Name)).First() != null)
			{
				bearer.statsComponent.Damage += item.statsComponent.Damage;
				bearer.statsComponent.CurrentHP += item.statsComponent.HP;
				bearer.statsComponent.HP += item.statsComponent.HP;
				item.Equiped = true;
			}
        }

		public static void Unequip(GameObject bearer, Item item)
		{
			if (bearer.inventory.Where(i => i is Item && ((Item)i).Name.Equals(item.Name)).First() != null)
			{
				bearer.statsComponent.Damage -= item.statsComponent.Damage;
				bearer.statsComponent.CurrentHP -= item.statsComponent.HP;
				bearer.statsComponent.HP -= item.statsComponent.HP;
				item.Equiped = false;
			}
		}
	}
}
