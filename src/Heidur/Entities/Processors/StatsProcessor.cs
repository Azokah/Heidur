using Heidur.Entities.Components;
using Microsoft.Xna.Framework;

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
			AdvanceStats(statsComponent);
		}

		public static void InitializeStats(StatsComponent statsComponent)
		{
			statsComponent.Range = statsComponent.BaseDexterity + Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.BaseDexterity);
			statsComponent.MaxDamage = statsComponent.BaseStrength;
			statsComponent.MinDamage = statsComponent.BaseStrength;
			statsComponent.CurrentHP = statsComponent.HP = Helpers.RandomNumbersHelper.ReturnRandomNumber(1, statsComponent.BaseConstitution);
			statsComponent.IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * (statsComponent.BaseDexterity);
		}

		public static void AdvanceStats(StatsComponent statsComponent)
		{
			statsComponent.Range += Helpers.RandomNumbersHelper.ReturnRandomNumber(statsComponent.BaseDexterity);
			statsComponent.CurrentHP = statsComponent.HP = statsComponent.HP + Helpers.RandomNumbersHelper.ReturnRandomNumber(1, statsComponent.BaseConstitution);
			statsComponent.IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * (statsComponent.BaseDexterity + statsComponent.ItemDexterity);
		}
	}
}
