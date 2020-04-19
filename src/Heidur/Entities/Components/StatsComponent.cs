using Heidur.Entities.Processors;

namespace Heidur.Entities.Components
{
	public class StatsComponent
    {
        public int HP { get; set; }
        public int MaxDamage { get; set; }
		public int MinDamage { get; set; }
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

		public int BaseStrength { get; set; }
		public int BaseDexterity { get; set; }
		public int BaseIntelligence { get; set; }
		public int BaseConstitution { get; set; }
		public int BaseSpirit { get; set; }

		public int ItemStrength { get; set; }
		public int ItemDexterity { get; set; }
		public int ItemIntelligence { get; set; }
		public int ItemConstitution { get; set; }
		public int ItemSpirit { get; set; }
		public int ItemMaxDamage { get; set; }
		public int ItemMinDamage { get; set; }
		public int ItemHp { get; set; }
		public int ItemRange { get; set; }

		public StatsComponent()
        {
            Clock = HitIntervalLastTicks = 0;
			BaseStrength = Helpers.RandomNumbersHelper.ReturnRandomNumber(3,18);
			BaseDexterity = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			BaseIntelligence = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			BaseConstitution = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			BaseSpirit = Helpers.RandomNumbersHelper.ReturnRandomNumber(3, 18);
			Experience = Constants.Stats.DEFAULT_EXPERIENCE;
			ExperienceReward = Constants.Stats.DEFAULT_REWARD;
			Level = Constants.Stats.DEFAULT_LEVEL;
			IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * BaseDexterity;
			Vision = Constants.NPC.DEFAULT_VISION;
			ItemStrength = 0;
			ItemDexterity = 0;
			ItemIntelligence = 0;
			ItemConstitution = 0;
			ItemSpirit = 0;
			ItemMaxDamage = 0;
			ItemHp = 0;
			ItemRange = 0;
			LearningPoints = 0;

			StatsProcessor.InitializeStats(this);
		}

		public StatsComponent(int range, int damage, int hp, int experience, int level, int strength, int dexterity, int intelligence, int constitution, int spirit)
		{
			Clock = HitIntervalLastTicks = 0;
			BaseStrength = strength;
			BaseDexterity = dexterity;
			BaseIntelligence = intelligence;
			BaseConstitution = constitution;
			BaseSpirit = spirit;
			Vision = Constants.NPC.DEFAULT_VISION;
			Range = range;
			MaxDamage = damage;
			CurrentHP = HP = hp;
			IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * BaseDexterity;
			Experience = experience;
			ExperienceReward = Constants.Stats.DEFAULT_REWARD;
			Level = level;
			ItemStrength = 0;
			ItemDexterity = 0;
			ItemIntelligence = 0;
			ItemConstitution = 0;
			ItemSpirit = 0;
			ItemMaxDamage = 0;
			ItemHp = 0;
			ItemRange = 0;
			LearningPoints = 0;
		}

		public StatsComponent(int strength, int dexterity, int intelligence, int constitution, int spirit)
		{
			Clock = HitIntervalLastTicks = 0;
			BaseStrength = strength;
			BaseDexterity = dexterity;
			BaseIntelligence = intelligence;
			BaseConstitution = constitution;
			BaseSpirit = spirit;
			Experience = Constants.Stats.DEFAULT_EXPERIENCE;
			ExperienceReward = Constants.Stats.DEFAULT_REWARD;
			Level = Constants.Stats.DEFAULT_LEVEL;
			IntervalModifier = Constants.Stats.INTERVAL_MODIFIER_CONSTANT * BaseDexterity;
			Vision = Constants.NPC.DEFAULT_VISION;
			ItemStrength = 0;
			ItemDexterity = 0;
			ItemIntelligence = 0;
			ItemConstitution = 0;
			ItemSpirit = 0;
			ItemMaxDamage = 0;
			ItemHp = 0;
			ItemRange = 0;
			LearningPoints = 0;

			StatsProcessor.InitializeStats(this);
		}

		public int GetStrength()
		{
			return BaseStrength + ItemStrength;
		}

		public int GetDexterity()
		{
			return BaseDexterity + ItemDexterity;
		}

		public int GetIntelligence()
		{
			return BaseIntelligence + ItemIntelligence;
		}

		public int GetSpirit()
		{
			return BaseSpirit + ItemSpirit;
		}

		public int GetConstitution()
		{
			return BaseConstitution + ItemConstitution;
		}

		public int GetMaxHp()
		{
			return HP + ItemHp;
		}

		public int GetMinDamage()
		{
			return MinDamage + ItemMinDamage;
		}

		public int GetMaxDamage()
		{
			return MaxDamage + ItemMaxDamage;
		}
	}
}
