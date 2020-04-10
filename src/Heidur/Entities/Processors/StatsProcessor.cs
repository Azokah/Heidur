using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
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

        public static void GainExperience(GameObject unit, int experience)
        {
			UIProcessor.SetFloatingText(Constants.UI.DEFAULT_FLOATING_TEXT_DURATION, "EXP +" + experience, unit.PhysicsComponent.position, Color.YellowGreen);
			unit.StatsComponent.Experience += experience;
			CheckLevel(unit);
        }

		public static void CheckLevel(GameObject unit)
		{
			var nextLevel = GetLevelAdvancement(unit.StatsComponent.Level);
			if (unit.StatsComponent.Experience >= nextLevel)
			{
				unit.StatsComponent.Level++;
				PerformDefaultAdvancement(unit.StatsComponent);
				AudioProcessor.PlaySoundEffect(Constants.SoundEffects.FXSounds.LEVEL_UP);
				UIProcessor.SetFloatingText(Constants.UI.DEFAULT_FLOATING_TEXT_DURATION, "Level UP!", unit.PhysicsComponent.position, Color.YellowGreen);
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
			statsComponent.LearningPoints += Constants.Stats.DEFAULT_LEARNINGPOINTS_ADVANCEMENT;
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
