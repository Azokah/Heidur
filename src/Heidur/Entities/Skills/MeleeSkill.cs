using Heidur.Entities.GameObjects;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
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
			if (unit.StatsComponent.Clock > unit.StatsComponent.HitIntervalLastTicks + Constants.Unit.DEFAULT_UNIT_HIT_INTERVAL - unit.StatsComponent.IntervalModifier)
			{
				var targetPosition = unit.PhysicsComponent.position;

				switch (unit.PhysicsComponent.FacingDirection)
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

				if (objective != null && StatsProcessor.CheckIfAlive(objective.StatsComponent) && PhysicsProcessor.GetDistanceFromUnit(unit.PhysicsComponent, objective.PhysicsComponent) <= 1)
				{
					var damage = Helpers.RandomNumbersHelper.ReturnRandomNumber(unit.StatsComponent.GetMinDamage(), unit.StatsComponent.GetMaxDamage());
					AudioProcessor.PlaySoundEffect(Constants.SoundEffects.FXSounds.HIT);
					unit.StatsComponent.HitIntervalLastTicks = unit.StatsComponent.Clock;
					StatsProcessor.TakeDamage(objective.StatsComponent, damage);
					ParticlesProcessor.NewParticleStreamAt(Constants.Particles.DEFAULT_ATTACK_PARTICLES_AMMOUNT, objective.PhysicsComponent.position, Constants.Particles.ParticlesStyle.ATTACK);
					UIProcessor.SetFloatingText(Constants.UI.DEFAULT_FLOATING_TEXT_DURATION, "-" + damage, objective.PhysicsComponent.position, Color.Red);
					if (!StatsProcessor.CheckIfAlive(objective.StatsComponent))
					{
						StatsProcessor.GainExperience(unit, objective.StatsComponent.ExperienceReward);
					}
				}
			}

			return false;
		}
	}
}
