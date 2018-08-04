using System.Collections.Generic;

namespace StringCalcKata.Interfaces
{
    public interface INumberParser
    {
        IEnumerable<int> Parse(string numberInput, IEnumerable<string> delimiters);
    }
}
