using System.Collections.Generic;

namespace StringCalcKata.Interfaces
{
    public interface IParser
    {
        bool IsInputEmpty(string input);
        IEnumerable<int> Parse(string input);
    }
}
