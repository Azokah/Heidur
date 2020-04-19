using Heidur.Entities.Processors;

namespace Heidur.Entities.Components
{
	public class StatsComponent
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
		public int Vision { get; set; }
        public int Experience { get; set; }
		public int Level { get; set; }
        public int CurrentHP { get; set; }
        public float HitIntervalLastTicks;
        public float Clock;
		public int ExperienceReward { get; set; }
		public float IntervalModifier { get; set; }
		public int LearningPoints { get; set; }

		public int Strength { get; set; }
		public int Dexterity { get; set; }
		public int Intelligence { get; set; }
		public int Constitution { get; set; }
		public int Spirit { get; set; }

		public int ItemStrength { get; set; }
		public int ItemDexterity { get; set; }
		public int ItemIntelligence { get; set; }
		public int ItemConstitution { get; set; }
		public int ItemSpirit { get; set; }
		public int ItemDamage { get; set; }
		public int ItemHp { get; set; }
		public int ItemRange { get; set; }

		public StatsComponent()
        {
            Clock = HitIntervalLastTicks = 0;
			Strength = Helpers.RandomNumbersHelper.ReturnRandomNumber(3,18);
			Dexterity = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			Intelligence = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			Constitution = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			Spirit = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			Experience = Constants.Stats.DEFAULT_EXPERIENCE;
			ExperienceReward = Constants.Stats.DEFAULT_REWARD;
			Level = Constants.Stats.DEFAULT_LEVEL;
			IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * Dexterity;
			Vision = Constants.NPC.DEFAULT_VISION;
			ItemStrength = 0;
			ItemDexterity = 0;
			ItemIntelligence = 0;
			ItemConstitution = 0;
			ItemSpirit = 0;
			ItemDamage = 0;
			ItemHp = 0;
			ItemRange = 0;
			LearningPoints = 0;

			StatsProcessor.ApplyBonuses(this);
			StatsProcessor.CalculateStats(this);
		}

		public StatsComponent(int range, int damage, int hp, int experience, int level, int strength, int dexterity, int intelligence, int constitution, int spirit)
		{
			Clock = HitIntervalLastTicks = 0;
			Strength = strength;
			Dexterity = dexterity;
			Intelligence = intelligence;
			Constitution = constitution;
			Spirit = spirit;
			Vision = Constants.NPC.DEFAULT_VISION;
			Range = range;
			Damage = damage;
			CurrentHP = HP = hp;
			IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * Dexterity;
			Experience = experience;
			ExperienceReward = Constants.Stats.DEFAULT_REWARD;
			Level = level;
			ItemStrength = 0;
			ItemDexterity = 0;
			ItemIntelligence = 0;
			ItemConstitution = 0;
			ItemSpirit = 0;
			ItemDamage = 0;
			ItemHp = 0;
			ItemRange = 0;
			LearningPoints = 0;

			StatsProcessor.ApplyBonuses(this);
		}

		public StatsComponent(int strength, int dexterity, int intelligence, int constitution, int spirit)
		{
			Clock = HitIntervalLastTicks = 0;
			Strength = strength;
			Dexterity = dexterity;
			Intelligence = intelligence;
			Constitution = constitution;
			Spirit = spirit;
			Experience = Constants.Stats.DEFAULT_EXPERIENCE;
			ExperienceReward = Constants.Stats.DEFAULT_REWARD;
			Level = Constants.Stats.DEFAULT_LEVEL;
			IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * Dexterity;
			Vision = Constants.NPC.DEFAULT_VISION;
			ItemStrength = 0;
			ItemDexterity = 0;
			ItemIntelligence = 0;
			ItemConstitution = 0;
			ItemSpirit = 0;
			ItemDamage = 0;
			ItemHp = 0;
			ItemRange = 0;
			LearningPoints = 0;

			StatsProcessor.ApplyBonuses(this);
			StatsProcessor.CalculateStats(this);
		}
	}
}
