using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Components
{
    public class StatsComponent
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Experience { get; set; }
        public int CurrentHP { get; set; }
        public float HitIntervalLastTicks;
        public float Clock;

        public StatsComponent()
        {
            Clock = HitIntervalLastTicks = 0;
            Range = Constants.Unit.DEFAULT_RANGE;
            Damage = Constants.Unit.DEFAULT_DAMAGE;
            CurrentHP = HP = Constants.Unit.DEFAULT_HP;
            Experience = Constants.Unit.DEFAULT_EXPERIENCE;
        }
    }
}
