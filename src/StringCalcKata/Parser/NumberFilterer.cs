using System.Collections.Generic;
using System.Linq;
using StringCalcKata.Interfaces;

namespace StringCalcKata.Parser
{
    public class NumberFilterer : INumberFilterer
    {
        public IEnumerable<int> FilterNumbersGreaterThan(IEnumerable<int> nums, int max)
        {
            return nums.Where(num => num <= max).ToList();
        }
    }
}
