using Heidur.Entities.Components;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Skills
{
	public class RangedSkill : ISkill
	{
		private int range { get; set; }

		public RangedSkill()
		{
			range = Constants.RangedSkill.DEFAULT_RANGED_RANGE;
		}

		public bool Execute(GameObject unit)
		{
			return Attack(unit.statsComponent, unit.physicsComponent);
		}

		private bool Attack(StatsComponent source, PhysicsComponent physicsComponent)
		{
			if (source.Clock > source.HitIntervalLastTicks + Constants.Unit.DEFAULT_UNIT_HIT_INTERVAL)
			{
				var objective = physicsComponent.NearbyUnits.Where(u => StatsProcessor.CheckIfAlive(u.statsComponent) && CheckIfInRange(physicsComponent, u)).FirstOrDefault();
				if (objective != null)
				{
					AudioProcessor.PlaySoundEffect(Constants.SoundEffects.FXSounds.HIT);
					source.HitIntervalLastTicks = source.Clock;
					StatsProcessor.TakeDamage(objective.statsComponent, source.Damage);
					ParticlesProcessor.NewParticleStreamAt(Constants.Particles.DEFAULT_ATTACK_PARTICLES_AMMOUNT, objective.physicsComponent.position, Constants.Particles.ParticlesStyle.ATTACK);
					if (!StatsProcessor.CheckIfAlive(objective.statsComponent))
					{
						StatsProcessor.GainExperience(source, objective.statsComponent.ExperienceReward);
					}
				}
			}

			return false;
		}

		private bool CheckIfInRange(PhysicsComponent source, GameObject objective)
		{
			Vector2 direction = Vector2.Zero;
			switch (source.FacingDirection)
			{
				case FacingDirections.UP:
					direction = new Vector2(0, 1);
					break;
				case FacingDirections.DOWN:
					direction = new Vector2(0, -1);
					break;
				case FacingDirections.LEFT:
					direction = new Vector2(1, 0);
					break;
				case FacingDirections.RIGHT:
					direction = new Vector2(-1, 0);
					break;
			}

			var normalized = Vector2.Subtract(source.position, objective.physicsComponent.position);
			normalized.Normalize();

			return (PhysicsProcessor.GetDistanceFromUnit(objective.physicsComponent, source) <= range) &&
				direction.Equals(normalized);
		}
	}
}
