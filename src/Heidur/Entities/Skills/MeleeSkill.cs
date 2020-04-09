using Heidur.Entities.Components;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Skills
{
	public class MeleeSkill : ISkill
	{
		public bool Execute(GameObject unit, GameObject objective)
		{
			return Attack(unit, objective);
		}

		private bool Attack(GameObject unit, GameObject objective)
		{
			if (unit.statsComponent.Clock > unit.statsComponent.HitIntervalLastTicks + Constants.Unit.DEFAULT_UNIT_HIT_INTERVAL)
			{
				var targetPosition = unit.physicsComponent.position;

				switch (unit.physicsComponent.FacingDirection)
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

				if (objective != null && StatsProcessor.CheckIfAlive(objective.statsComponent) && PhysicsProcessor.GetDistanceFromUnit(unit.physicsComponent, objective.physicsComponent) <= 1)
				{
					AudioProcessor.PlaySoundEffect(Constants.SoundEffects.FXSounds.HIT);
					unit.statsComponent.HitIntervalLastTicks = unit.statsComponent.Clock;
					StatsProcessor.TakeDamage(objective.statsComponent, unit.statsComponent.Damage);
					ParticlesProcessor.NewParticleStreamAt(Constants.Particles.DEFAULT_ATTACK_PARTICLES_AMMOUNT, objective.physicsComponent.position, Constants.Particles.ParticlesStyle.ATTACK);
					UIProcessor.SetFloatingText(Constants.UI.DEFAULT_FLOATING_TEXT_DURATION, "-" + unit.statsComponent.Damage, objective.physicsComponent.position, Color.Red);
					if (!StatsProcessor.CheckIfAlive(objective.statsComponent))
					{
						StatsProcessor.GainExperience(unit.statsComponent, objective.statsComponent.ExperienceReward);
					}
				}
			}

			return false;
		}
	}
}
