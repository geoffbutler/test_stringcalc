using StringCalcKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalcKata.Parser
{
    public class NumberParser : INumberParser
    {
        public IEnumerable<int> Parse(string numberInput, IEnumerable<string> delimiters)
        {
            var delims = delimiters.ToArray();
            var numberStrings = numberInput.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            return numberStrings.Select(int.Parse).ToList();
        }
    }
}
