using System;
using FluentAssertions;
using UnoSimpleCalc.Core;
using Xunit;

namespace UnoSimpleCalc.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ValidDigit()
        {
            var cal = new Calculator();
            cal.AppendDigit(1);
            cal.Evaluate();
            cal.TextInput.Should().Be("1");
        }

        [Fact]
        public void TwoDigits()
        {
            var cal = new Calculator();
            cal.AppendDigit(1);
            cal.AppendDigit(5);
            cal.Evaluate();
            cal.Result.Should().Be(15);
        }

        [Fact]
        public void InvalidDigit()
        {
            var cal = new Calculator();
            new Action(() => cal.AppendDigit(11)).Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add()
        {
            var cal = new Calculator();
            cal.AppendDigit(1);
            cal.ApplyOperator(Operator.Add);
            cal.AppendDigit(1);
            cal.Evaluate();
            cal.Result.Should().Be(2);
        }

        [Fact]
        public void Negate()
        {
            var cal = new Calculator();
            cal.AppendDigit(5);
            cal.Negate();
            cal.Evaluate();
            cal.Result.Should().Be(-5);
        }

        [Fact]
        public void Subtract()
        {
            var cal = new Calculator();
            cal.AppendDigit(2);
            cal.ApplyOperator(Operator.Subtract);
            cal.AppendDigit(1);
            cal.Evaluate();
            cal.Result.Should().Be(1);
        }

        [Fact]
        public void Mult()
        {
            var cal = new Calculator();
            cal.AppendDigit(4);
            cal.ApplyOperator(Operator.Multiplication);
            cal.AppendDigit(3);
            cal.Evaluate();
            cal.Result.Should().Be(12);
        }

        [Fact]
        public void Div()
        {
            var cal = new Calculator();
            cal.AppendDigit(10);
            cal.ApplyOperator(Operator.Division);
            cal.AppendDigit(5);
            cal.Evaluate();
            cal.Result.Should().Be(2);
        }

        [Fact]
        public void NegateMult()
        {
            var cal = new Calculator();
            cal.AppendDigit(3);
            cal.ApplyOperator(Operator.Multiplication);
            cal.AppendDigit(5);
            cal.Negate();
            cal.Evaluate();
            cal.Result.Should().Be(-15);
        }

        [Fact]
        public void Decimal()
        {
            var cal = new Calculator();
            cal.AppendDigit(3);
            cal.SetDecimal();
            cal.AppendDigit(5);
            cal.Evaluate();
            cal.Result.Should().Be(3.5);
        }

        [Fact]
        public void DecimalMultiDigit()
        {
            var cal = new Calculator();
            cal.AppendDigit(3);
            cal.SetDecimal();
            cal.AppendDigit(5);
            cal.AppendDigit(5);
            cal.Evaluate();
            cal.Result.Should().Be(3.55);
        }
    }
}
