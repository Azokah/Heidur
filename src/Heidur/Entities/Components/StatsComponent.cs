using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Heidur.Entities.Components.PhysicsComponent;

namespace Heidur.Entities.Components
{
    public class StatsComponent : IComponent
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Experience { get; set; }
        public int CurrentHP { get; set; }

        private float HitIntervalLastTicks;
        private float Clock;

        public StatsComponent()
        {
            Clock = HitIntervalLastTicks = 0;
            Range = Constants.Unit.DEFAULT_RANGE;
            Damage = Constants.Unit.DEFAULT_DAMAGE;
            CurrentHP = HP = Constants.Unit.DEFAULT_HP;
            Experience = Constants.Unit.DEFAULT_EXPERIENCE;
        }

        public void Update(float deltaTime, List<GameObject> nearbyNPC, GameMap map)
        {
            Clock += deltaTime;
        }

        public bool CheckIfAlive()
        {
            return (CurrentHP > 0);
        }

        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;
        }

        public void GainExperience(int experience)
        {
            Console.WriteLine($"You gained {experience} experience points!");
            this.Experience += experience;
        }

        public bool Attack(PhysicsComponent physicsComponent)
        {
            if (Clock > HitIntervalLastTicks + Constants.Unit.DEFAULT_UNIT_HIT_INTERVAL)
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

                var objective = physicsComponent.NearbyUnits.Where(u => u.statsComponent.CheckIfAlive() && u.physicsComponent.position.Equals(targetPosition)).FirstOrDefault();
                if (objective != null)
                {
                    HitIntervalLastTicks = Clock;
                    objective.statsComponent.TakeDamage(this.Damage);
                    Console.WriteLine("You hitted the target!");
                }
            }

            return false;
        }
    }
}
