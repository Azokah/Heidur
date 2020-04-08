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
        }
    }
}
