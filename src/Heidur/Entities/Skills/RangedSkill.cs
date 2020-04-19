using Heidur.Entities.Components;
using Heidur.Entities.GameObjects;
using Heidur.Entities.Processors;
using Microsoft.Xna.Framework;
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
			if (unit.StatsComponent.Clock > unit.StatsComponent.HitIntervalLastTicks + Constants.Unit.DEFAULT_UNIT_HIT_INTERVAL - unit.StatsComponent.IntervalModifier)
			{
				if (objective != null &&
					StatsProcessor.CheckIfAlive(objective.StatsComponent) &&
					PhysicsProcessor.GetDistanceFromUnit(objective.PhysicsComponent, unit.PhysicsComponent) < Range)
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

			var normalized = Vector2.Subtract(source.position, objective.PhysicsComponent.position);
			normalized.Normalize();

			return (PhysicsProcessor.GetDistanceFromUnit(objective.PhysicsComponent, source) <= Range) &&
				direction.Equals(normalized);
		}
	}
}
