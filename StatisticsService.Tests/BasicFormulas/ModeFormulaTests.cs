using NUnit.Framework;
using StatisticsLibrary;

namespace StatisticsService.Tests;

[TestFixture]
public class ModeFormulaTests
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
        new double[] { 1, 3},
        TestName = "Mode from int[]: > 1 mode values")
    ]
    [TestCase(
        new double[] { 3, 1, 2, 39284, 3, 4, 1, 7812897, 9, 23, 1, 200 },
        new double[] { 1 },
        TestName = "Mode from int[] - with outliers")
    ]
    [TestCase(
        new double[] { 3, -1, 2, 3, 4, 9, -23, 1 },
        new double[] { 3 },
        TestName = "Mode with negative numbers")
    ]
    [TestCase(
        new double[] { 5, 5.0, 5.000, 5, 5, 5 },
        new double[] { 5 },
        TestName = "Mode from double[] - same elements")
    ]
    public void NotEmptyDataSet_Pass(double[] dataSet, double[] expectedResult)
    {
        List<double> modes = this._basicFormulas.Mode(new List<double>(dataSet));
        Assert.That(modes, Is.EquivalentTo(new List<double>(expectedResult)));
    }

    [Test(
        Description = "Mode from big dataset")
    ]
    public void BigDataSet_Pass()
    {
        Assert.That(
            this._basicFormulas.Mode(new List<double>(TestDataSet._bigDataSet)),
            Is.EquivalentTo(new List<double>([89])));
    }

    [Test]
    [TestCase(
        TestName = "Mode from empty dataset")
    ]
    public void EmptyDataset_Exception()
    {
        Assert.Throws<EmptyDataSetException>(() =>
            this._basicFormulas.Mode([]));
    }
}
