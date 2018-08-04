using StringCalcKata.Interfaces;
using StringCalcKata.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalcKata.Parser
{
    public class InputParser : IInputParser
    {
        public InputInfo Parse(string input)
        {
            if (!input.StartsWith("//"))
            {
                // no custom delims
                return new InputInfo
                {
                    Delimiters = new[] { ",", "\n" }, // default
                    NumberInput = input
                };
            }

            if (!input.StartsWith("//["))
            {
                // single char custom delim                
                return new InputInfo
                {
                    Delimiters = new[] { input.Substring(2, 1) },
                    NumberInput = input.Substring(3)
                };
            }

            // multi char custom delim                        
            var delimRegex = new Regex(@"\[{1}[^\]\[]*\]{1}");
            var delimMatches = delimRegex.Matches(input);
            var multiCharDelims = new List<string>();
            var delimLength = 2; // skip '//'
            foreach (Match match in delimMatches)
            {
                delimLength += match.Length;
                multiCharDelims.Add(match.Value.TrimStart('[').TrimEnd(']'));
            }

            var startOfNumberInput = delimLength + 1; // for the \n
            return new InputInfo
            {
                Delimiters = multiCharDelims.ToArray(),
                NumberInput = input.Substring(startOfNumberInput)
            };
        }
    }
}
