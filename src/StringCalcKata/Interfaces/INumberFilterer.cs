using System.Collections.Generic;

namespace StringCalcKata.Interfaces
{
    public interface INumberFilterer
    {
        IEnumerable<int> FilterNumbersGreaterThan(IEnumerable<int> nums, int max);
    }
}
