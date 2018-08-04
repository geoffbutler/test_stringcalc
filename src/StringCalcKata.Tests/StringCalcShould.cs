using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using StringCalcKata.Parser;

namespace StringCalcKata.Tests
{
    [TestClass]
    public class StringCalcShould
    {
        private StringCalc _target;

        [TestInitialize]
        public void Init()
        {
            var inputParser = new InputParser();
            var numParser = new NumberParser();
            var numFilterer = new NumberFilterer();
            var numValidator = new NumberValidator();
            var parser = new Parser.Parser(inputParser, numParser, numFilterer, numValidator);
            _target = new StringCalc(parser);
        }

        [TestMethod]
        public void BeInstantiable()
        {
            _target.Should().NotBeNull();
        }

        [TestMethod]
        public void ReturnZeroForEmptyString()
        {
            _target.Add(string.Empty).Should().Be(0);
        }

        [TestMethod]
        public void ReturnASingleNumber()
        {
            _target.Add("1").Should().Be(1);
        }
        
        [TestMethod]
        public void AddTwoNumbers()
        {
            _target.Add("1,2").Should().Be(3);
            _target.Add("2,3").Should().Be(5);
        }

        [TestMethod]
        public void AddAnyNumberOfNumbers()
        {
            _target.Add("1,1,1").Should().Be(3);
            _target.Add("1,2,3,4").Should().Be(10);
            _target.Add(",1,2,3,4,5,").Should().Be(15);
        }

        [TestMethod]
        public void HandleNewlineInsteadOfCommasForDelim()
        {            
            _target.Add("\n1\n2\n3\n4\n5\n").Should().Be(15);
        }
        
        [TestMethod]
        public void HandleSingleCharCustomDelim()
        {
            _target.Add("//;\n1;2").Should().Be(3);
        }

        [TestMethod]
        public void ThrowWhenSuppliedNegativeNumbers()
        {
            new Action(() => _target.Add("-1")).ShouldThrow<Exception>().WithMessage("negatives not allowed: -1");
            new Action(() => _target.Add("-1,-2")).ShouldThrow<Exception>().WithMessage("negatives not allowed: -1,-2");
        }

        [TestMethod]
        public void IgnoreNumbersGreaterThan1000()
        {
            _target.Add("1000,1,1001,2,2003,3,3004").Should().Be(1006);
        }

        [TestMethod]
        public void HandleMultiCharCustomDelim()
        {
            _target.Add("//[***]\n1***2***3").Should().Be(6);
        }

        [TestMethod]
        public void HandleMultipleSingleCharCustomDelim()
        {
            _target.Add("//[*][%]\n1*2%3").Should().Be(6);
        }

        [TestMethod]
        public void HandleMultipleMultiCharCustomDelim()
        {
            _target.Add("//[***][%%%]\n1***2%%%3").Should().Be(6);
        }
    }
}
