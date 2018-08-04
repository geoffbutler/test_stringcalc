using System.Collections.Generic;
using StringCalcKata.Interfaces;

namespace StringCalcKata.Parser
{
    public class Parser : IParser
    {
        private IInputParser _inputParser;
        private INumberParser _numberParser;
        private INumberFilterer _numberFilterer;
        private INumberValidator _numberValidator;

        public Parser(IInputParser inputParser, INumberParser numberParser, INumberFilterer numberFilterer, INumberValidator numberValidator)
        {
            _inputParser = inputParser;
            _numberParser = numberParser;
            _numberFilterer = numberFilterer;
            _numberValidator = numberValidator;
        }

        public bool IsInputEmpty(string input)
        {
            return input != string.Empty;
        }

        public IEnumerable<int> Parse(string input)
        {
            var inputInfo = _inputParser.Parse(input);

            var nums = _numberParser.Parse(inputInfo.NumberInput, inputInfo.Delimiters);

            var filteredNums = _numberFilterer.FilterNumbersGreaterThan(nums, 1000); // exclude numbers greater than 1000

            _numberValidator.AssertNoNegatives(filteredNums);

            return filteredNums;
        }
    }
}
