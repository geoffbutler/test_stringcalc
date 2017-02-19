using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalcKata
{
    public class StringCalc
    {
        public int Add(string input)
        {
            if (input == string.Empty) return 0;
            
            var nums = ParseInput(input);
            
            NegativeNumberCheck(nums);

            return nums.Sum();
        }
        
        private static List<int> ParseInput(string input)
        {
            string[] delims;
            string numberInput;
            GetDelimitersAndNumberInput(input, out delims, out numberInput);

            var numberStrings = numberInput.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            return numberStrings.Select(int.Parse)
                .Where(num => num <= 1000) // exclude numbers greater than 1000
                .ToList();
        }

        private static void GetDelimitersAndNumberInput(string input, out string[] delims, out string numberInput)
        {
            if (!input.StartsWith("//"))
            {
                // no custom delims
                delims = new[] { ",", "\n" }; // default 
                numberInput = input;
                return;
            }

            if (!input.StartsWith("//["))
            {
                // single char custom delim                
                delims = new[] { input.Substring(2, 1) };
                numberInput = input.Substring(3);
                return;
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

            delims = multiCharDelims.ToArray();
            numberInput = input.Substring(startOfNumberInput);
        }

        private static void NegativeNumberCheck(IEnumerable<int> nums)
        {
            var negativeNums = nums.Where(num => num < 0).ToList();
            if (negativeNums.Any())
                throw new Exception("negatives not allowed: " + string.Join(",", negativeNums.Select(num => num.ToString())));
        }
    }
}
