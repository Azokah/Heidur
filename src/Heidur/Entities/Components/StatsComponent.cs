namespace Heidur.Entities.Components
{
	public class StatsComponent
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Experience { get; set; }
		public int Level { get; set; }
        public int CurrentHP { get; set; }
        public float HitIntervalLastTicks;
        public float Clock;
		public int ExperienceReward { get; set; }

        public StatsComponent()
        {
            Clock = HitIntervalLastTicks = 0;
            Range = Constants.Unit.DEFAULT_RANGE;
            Damage = Constants.Unit.DEFAULT_DAMAGE;
            CurrentHP = HP = Constants.Unit.DEFAULT_HP;
            Experience = Constants.Unit.DEFAULT_EXPERIENCE;
			ExperienceReward = Constants.Unit.DEFAULT_REWARD;
			Level = Constants.Unit.DEFAULT_LEVEL;
        }
    }
}
