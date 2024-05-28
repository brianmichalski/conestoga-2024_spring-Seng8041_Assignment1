using NUnit.Framework;
using StatisticsLibrary;

namespace StatisticsService.Tests;

[TestFixture]
public class MeanFormulaTests
{
    private BasicFormulas _basicFormulas;

    [SetUp]
    public void Setup()
    {
        this._basicFormulas = new BasicFormulas();
    }

    [Test]
    [TestCase(
        new double[] { 3, 1, 2, 3, 4, 9, 23, 1 },
        ExpectedResult = 5.75,

        TestName = "Mean with int[] - not outliers ")
    ]
    [TestCase(
        new double[] { 3, 1, 2, 39284, 3, 4, 7812897, 9, 23, 1, 200 },
        ExpectedResult = 713857,
        TestName = "Mean with int[] - with outliers")
    ]
    [DefaultFloatingPointTolerance(0.0001)]
    public double ListOfInteger_Pass(double[] dataSet)
    {
        return this._basicFormulas.Mean(new List<double>(dataSet));
    }

    [Test]
    [TestCase(
        new double[] { 1.1, 2.2, 3.3 },
        ExpectedResult = 2.2,
        TestName = "Mean from double[] - no outliers")
    ]
    [TestCase(
        new double[] { 1.1, 2.2, 3.3, 45, 12937645123890 },
        ExpectedResult = 2587529024788.32,
        TestName = "Mean from double[] - with outliers")
    ]
    [DefaultFloatingPointTolerance(0.0001)]
    public double ListOfDouble_Pass(double[] dataSet)
    {
        return this._basicFormulas.Mean(new List<double>(dataSet));
    }

    [Test]
    [TestCase(
        TestName = "Mean from empty double[]")
    ]
    public void EmptyDataset_Exception()
    {
        Assert.Throws<EmptyDataSetException>(() =>
            this._basicFormulas.Mean([]));
    }
}