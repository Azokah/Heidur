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
		private int Range { get; set; }

		public RangedSkill()
		{
			Range = Constants.RangedSkill.DEFAULT_RANGED_RANGE;
		}

		public bool Execute(GameObject unit, GameObject objective)
		{
			return Attack(unit, objective);
		}

		private bool Attack(GameObject unit, GameObject objective)
		{
			if (unit.statsComponent.Clock > unit.statsComponent.HitIntervalLastTicks + Constants.Unit.DEFAULT_UNIT_HIT_INTERVAL)
			{
				if (objective != null &&
					StatsProcessor.CheckIfAlive(objective.statsComponent) &&
					PhysicsProcessor.GetDistanceFromUnit(objective.physicsComponent, unit.physicsComponent) < Range)
				{
					AudioProcessor.PlaySoundEffect(Constants.SoundEffects.FXSounds.HIT);
					unit.statsComponent.HitIntervalLastTicks = unit.statsComponent.Clock;
					StatsProcessor.TakeDamage(objective.statsComponent, unit.statsComponent.Damage);
					ParticlesProcessor.NewParticleStreamAt(Constants.Particles.DEFAULT_ATTACK_PARTICLES_AMMOUNT, objective.physicsComponent.position, Constants.Particles.ParticlesStyle.ATTACK);
					if (!StatsProcessor.CheckIfAlive(objective.statsComponent))
					{
						StatsProcessor.GainExperience(unit.statsComponent, objective.statsComponent.ExperienceReward);
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

			return (PhysicsProcessor.GetDistanceFromUnit(objective.physicsComponent, source) <= Range) &&
				direction.Equals(normalized);
		}
	}
}
