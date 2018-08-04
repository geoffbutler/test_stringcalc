using System.Collections.Generic;

namespace StringCalcKata.Interfaces
{
    public interface INumberValidator
    {
        void AssertNoNegatives(IEnumerable<int> nums);
    }
}
