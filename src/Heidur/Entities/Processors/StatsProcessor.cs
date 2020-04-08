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
    }
}
