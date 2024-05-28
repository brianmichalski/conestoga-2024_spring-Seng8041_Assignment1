using NUnit.Framework;
using StatisticsLibrary;

namespace StatisticsService.Tests;

[TestFixture]
public class MedianFormulaTests
{
    private BasicFormulas _basicFormulas;

    [SetUp]
    public void Setup()
    {
        this._basicFormulas = new BasicFormulas();
    }

    [Test]
    [TestCase(
        new double[] { 2.012, 1.8, 7.3, 6.6, 9.123, 14.35 },
        ExpectedResult = 6.95,
        TestName = "Median from double[] - even count")
    ]
    [TestCase(
        new double[] { 2.012, 7.303, 6.6, 9.123, 14.35 },
        ExpectedResult = 7.303,
        TestName = "Median from double[] - odd count")
    ]
    [TestCase(
        new double[] { 5, 5.0, 5.000, 5, 5, 5 },
        ExpectedResult = 5,
        TestName = "Median from double[] - same elements, even count")
    ]
    [TestCase(
        new double[] { 5, 5.0, 5.000, 5, 5 },
        ExpectedResult = 5,
        TestName = "Median from double[] - same elements, odd count")
    ]
    [DefaultFloatingPointTolerance(0.05)]
    public double ListOfDouble_Pass(double[] dataSet)
    {
        return this._basicFormulas.Median(new List<double>(dataSet));
    }

    [Test]
    [TestCase(
        new double[] { 2, 1, 7, 6, 9, 14 },
        ExpectedResult = 6.5,
        TestName = "Median from int[] - even count")
    ]
    [TestCase(
        new double[] { 2, 7, 6, 9, 14 },
        ExpectedResult = 7,
        TestName = "Median from int[] - odd count")
    ]
    [DefaultFloatingPointTolerance(0.05)]
    public double ListOfInt_Pass(double[] dataSet)
    {
        return this._basicFormulas.Median(new List<double>(dataSet));
    }

    [Test]
    [TestCase(
        TestName = "Median from empty double[]")
    ]
    public void EmptyDataset_Exception()
    {
        Assert.Throws<EmptyDataSetException>(() =>
            this._basicFormulas.Mean([]));
    }
}