using System;
using System.Collections.Generic;
using System.Linq;
using StringCalcKata.Interfaces;

namespace StringCalcKata.Parser
{
    public class NumberValidator : INumberValidator
    {
        public void AssertNoNegatives(IEnumerable<int> nums)
        {
            var negativeNums = nums.Where(num => num < 0).ToList();
            if (negativeNums.Any())
                throw new Exception("negatives not allowed: " + string.Join(",", negativeNums.Select(num => num.ToString())));
        }
    }
}
