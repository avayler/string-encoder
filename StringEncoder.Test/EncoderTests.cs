using System;
using FluentAssertions;
using Xunit;

namespace StringEncoder.Test;

public class EncoderTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("a", "(")]
    [InlineData("A", "(")]
    [InlineData("aa", "))")]
    [InlineData("AA", "))")]
    [InlineData("Aa", "))")]
    [InlineData("aA", "))")]
    [InlineData("aAb", "))(")]
    [InlineData("!!Ab", "))((")]
    [InlineData("(()", "))(")]
    [InlineData("(( !££jkh)", "))(())((((")]
    [InlineData("recede", "()()()")]
    [InlineData("din", "(((")]
    [InlineData("Success", ")())())")]
    [InlineData("(( @", "))((")]
    [InlineData("CodeWarrior", "()(((())())")]
    [InlineData("Supralapsarian", ")()))()))))()(")]
    [InlineData("iiiiii", "))))))")]
    [InlineData(" ( ( )", ")))))(")]
    public void EncodeString1(String input, String expected)
    {
        // Arrange
        var encoder = new Encoder();

        // Act
        var result = encoder.Encode(input);

        // Assert
        result.Length.Should().Be(expected.Length);
        result.Should().Be(expected);
    }
}