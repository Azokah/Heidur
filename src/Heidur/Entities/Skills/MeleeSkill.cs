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
		public bool Execute(GameObject unit)
		{
			return Attack(unit.statsComponent, unit.physicsComponent);
		}

		private bool Attack(StatsComponent source, PhysicsComponent physicsComponent)
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

				var objective = physicsComponent.NearbyUnits.Where(u => StatsProcessor.CheckIfAlive(u.statsComponent) && u.physicsComponent.position.Equals(targetPosition)).FirstOrDefault();
				if (objective != null)
				{
					AudioProcessor.PlaySoundEffect(Constants.SoundEffects.FXSounds.HIT);
					source.HitIntervalLastTicks = source.Clock;
					StatsProcessor.TakeDamage(objective.statsComponent, source.Damage);
					ParticlesProcessor.NewParticleStreamAt(Constants.Particles.DEFAULT_ATTACK_PARTICLES_AMMOUNT, objective.physicsComponent.position, Constants.Particles.ParticlesStyle.ATTACK);
				}
			}

			return false;
		}
	}
}
