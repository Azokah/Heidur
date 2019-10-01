using Heidur.Entities.Components;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using static Heidur.Constants.Physics;

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

        public static bool Attack(StatsComponent source, PhysicsComponent physicsComponent)
        {
            if (source.Clock > source.HitIntervalLastTicks + Constants.Unit.DEFAULT_UNIT_HIT_INTERVAL)
            {
                var targetPosition = physicsComponent.position;

                switch (physicsComponent.FacingDirection)
                {
                    case FacingDirections.UP:
                        targetPosition -= new Vector2(0, Constants.TILESIZE);
                        break;
                    case FacingDirections.DOWN:
                        targetPosition += new Vector2(0, Constants.TILESIZE);
                        break;
                    case FacingDirections.LEFT:
                        targetPosition -= new Vector2(Constants.TILESIZE, 0);
                        break;
                    case FacingDirections.RIGHT:
                        targetPosition += new Vector2(Constants.TILESIZE, 0);
                        break;
                }

                var objective = physicsComponent.NearbyUnits.Where(u => CheckIfAlive(u.statsComponent) && u.physicsComponent.position.Equals(targetPosition)).FirstOrDefault();
                if (objective != null)
                {
                    source.HitIntervalLastTicks = source.Clock;
                    TakeDamage(objective.statsComponent, source.Damage);
                    Console.WriteLine("You hitted the target!");
                }
            }

            return false;
        }
    }
}
