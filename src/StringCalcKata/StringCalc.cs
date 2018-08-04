using System.Linq;
using StringCalcKata.Interfaces;

namespace StringCalcKata
{
    public class StringCalc
    {
        private IParser _parser;

        public StringCalc(IParser parser)
        {
            _parser = parser;
        }

        public int Add(string input)
        {            
            if (!_parser.IsInputEmpty(input)) return 0;

            var nums = _parser.Parse(input);

            return nums.Sum();
        }
    }
}
