using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class StringCalculatorTests
{
    [TestMethod]
    public void EmptyString_ReturnsZero()
    {
        var calc = new StringCalculator();
        Assert.AreEqual(0, calc.Add(""));
    }

    [TestMethod]
    public void SingleNumber_ReturnsNumber()
    {
        var calc = new StringCalculator();
        Assert.AreEqual(5, calc.Add("5"));
    }

    [TestMethod]
    public void MultipleNumbers_CommaSeparated()
    {
        var calc = new StringCalculator();
        Assert.AreEqual(6, calc.Add("1,2,3"));
    }

    [TestMethod]
    public void NewLineAndComma_Allowed()
    {
        var calc = new StringCalculator();
        Assert.AreEqual(6, calc.Add("1\n2,3"));
    }

    [TestMethod]
    public void NumbersGreaterThan1000_Ignored()
    {
        var calc = new StringCalculator();
        Assert.AreEqual(2, calc.Add("2,1001"));
    }

    [TestMethod]
    public void NegativeNumbers_ThrowException()
    {
        var calc = new StringCalculator();

        try
        {
            calc.Add("-1,2,-3");
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.AreEqual("Negatives not allowed: -1,-3", ex.Message);
        }
    }
}
