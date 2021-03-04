// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;

public class MatchingBracketsTests
{
    [Fact]
    public void Paired_square_brackets()
    {
        var value = "[]";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Empty_string()
    {
        var value = "";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Unpaired_brackets()
    {
        var value = "[[";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Wrong_ordered_brackets()
    {
        var value = "}{";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Wrong_closing_bracket()
    {
        var value = "{]";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Paired_with_whitespace()
    {
        var value = "{ }";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Partially_paired_brackets()
    {
        var value = "{[])";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Simple_nested_brackets()
    {
        var value = "{[]}";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Several_paired_brackets()
    {
        var value = "{}[]";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Paired_and_nested_brackets()
    {
        var value = "([{}({}[])])";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Unopened_closing_brackets()
    {
        var value = "{[)][]}";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Unpaired_and_nested_brackets()
    {
        var value = "([{])";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Paired_and_wrong_nested_brackets()
    {
        var value = "[({]})";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Paired_and_incomplete_brackets()
    {
        var value = "{}[";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Too_many_closing_brackets()
    {
        var value = "[]]";
        Assert.False(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Math_expression()
    {
        var value = "(((185 + 223.85) * 15) - 543)/2";
        Assert.True(MatchingBrackets.IsPaired(value));
    }

    [Fact]
    public void Complex_latex_expression()
    {
        var value = "\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)";
        Assert.True(MatchingBrackets.IsPaired(value));
    }
}