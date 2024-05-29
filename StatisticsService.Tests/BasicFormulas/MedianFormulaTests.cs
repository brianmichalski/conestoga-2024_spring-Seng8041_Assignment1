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
        new double[] { 9.123, 2.012, 1.8, 7.3, 6.6, 9.123, 14.35 },
        ExpectedResult = 7.3,
        TestName = "Median from double[] - repeating decimals")
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
    [TestCase(
        new double[] { 3, -1, 2, 3, 4, 9, -23, 1 },
        ExpectedResult = 2.5,
        TestName = "Median with negative numbers")
    ]
    [DefaultFloatingPointTolerance(0.001)]
    public double NotEmptyDataSet_Pass(double[] dataSet)
    {
        return this._basicFormulas.Median(new List<double>(dataSet));
    }

    [Test(
        Description = "Median from big dataset",
        ExpectedResult = 89)
    ]
    [DefaultFloatingPointTolerance(0.00001)]
    public double BigDataSet_Pass()
    {
        return this._basicFormulas.Median(
            new List<double>(TestDataSet._bigDataSet));
    }

    [Test]
    [TestCase(
        TestName = "Median from empty dataset")
    ]
    public void EmptyDataset_Exception()
    {
        Assert.Throws<EmptyDataSetException>(() =>
            this._basicFormulas.Mean([]));
    }
}