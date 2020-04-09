using Heidur.Entities.Components;
using System;

namespace Heidur.Entities.Processors
{
	public static class StatsProcessor
    {
        public static void Update(float deltaTime, StatsComponent statsComponent)
        {
            statsComponent.Clock += deltaTime;
        }

        public static bool CheckIfAlive(StatsComponent statsComponent)
        {
            return (statsComponent.CurrentHP > 0);
        }

        public static void TakeDamage(StatsComponent statsComponent, int damage)
        {
            statsComponent.CurrentHP -= damage;
        }

        public static void GainExperience(StatsComponent statsComponent, int experience)
        {
            Console.WriteLine($"You gained {experience} experience points!");
            statsComponent.Experience += experience;
			CheckLevel(statsComponent);
        }

		public static void CheckLevel(StatsComponent statsComponent)
		{
			var nextLevel = GetLevelAdvancement(statsComponent.Level);
			if (statsComponent.Experience >= nextLevel)
			{
				statsComponent.Level++;
				PerformDefaultAdvancement(statsComponent);
				AudioProcessor.PlaySoundEffect(Constants.SoundEffects.FXSounds.LEVEL_UP);
			}
		}

		private static int GetLevelAdvancement(int level)
		{
			var firstNumber = 0;
			var secondNumber = Constants.Leveling.DEFAULT_LEVELING_ADVANCEMENT;

			int result = firstNumber + secondNumber;
			for(var l = 1; l < level; l++)
			{
				firstNumber = secondNumber;
				secondNumber = result;
				result = firstNumber + secondNumber;
			}

			return result;
		}

		private static void PerformDefaultAdvancement(StatsComponent statsComponent)
		{
			RemoveBonuses(statsComponent);

			statsComponent.Strength += statsComponent.Strength + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Strength);
			statsComponent.Constitution += statsComponent.Constitution + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Constitution);
			statsComponent.Dexterity += statsComponent.Dexterity + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Dexterity);
			statsComponent.Intelligence += statsComponent.Intelligence + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Intelligence);
			statsComponent.Spirit += statsComponent.Spirit + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Spirit);

			ApplyBonuses(statsComponent);
			CalculateStats(statsComponent);
		}

		public static void CalculateStats(StatsComponent statsComponent)
		{
			statsComponent.Range = statsComponent.Dexterity + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Dexterity);
			statsComponent.Damage = (statsComponent.Strength * 2) + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Strength);
			statsComponent.CurrentHP = statsComponent.HP = (statsComponent.Constitution * 3) + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.Constitution);
			statsComponent.IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * statsComponent.Dexterity;
		}

		public static void ApplyBonuses(StatsComponent statsComponent)
		{
			statsComponent.Strength += statsComponent.ItemStrength;
			statsComponent.Dexterity += statsComponent.ItemDexterity;
			statsComponent.Intelligence += statsComponent.ItemIntelligence;
			statsComponent.Constitution += statsComponent.ItemConstitution;
			statsComponent.Spirit += statsComponent.ItemSpirit;
			statsComponent.Damage += statsComponent.ItemDamage;
			statsComponent.HP += statsComponent.ItemHp;
			statsComponent.Range += statsComponent.ItemRange;
		}

		public static void RemoveBonuses(StatsComponent statsComponent)
		{
			statsComponent.Strength -= statsComponent.ItemStrength;
			statsComponent.Dexterity -= statsComponent.ItemDexterity;
			statsComponent.Intelligence -= statsComponent.ItemIntelligence;
			statsComponent.Constitution -= statsComponent.ItemConstitution;
			statsComponent.Spirit -= statsComponent.ItemSpirit;
			statsComponent.Damage -= statsComponent.ItemDamage;
			statsComponent.HP -= statsComponent.ItemHp;
			statsComponent.Range -= statsComponent.ItemRange;
		}
	}
}
