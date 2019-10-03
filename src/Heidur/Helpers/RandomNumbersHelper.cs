using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Helpers
{
    public static class RandomNumbersHelper
    {
        public static int ReturnRandomNumber()
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next();
        }

        public static int ReturnRandomNumber(int min, int max)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(min, max);
        }

        public static int ReturnRandomNumber(int max)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(max);
        }
    }
}
