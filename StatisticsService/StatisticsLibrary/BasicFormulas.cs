using System.Linq;

namespace StatisticsLibrary;

public class BasicFormulas
{
    public double Mean(List<double> data)
    {
        this.checkIfDatasetHasElements(data);

        return data.Sum() / data.Count();
    }

    public double Median(List<double> data)
    {
        this.checkIfDatasetHasElements(data);
         
        data.Sort();

        int count = data.Count;
        int medianIndex = (count / 2);

        // Median when elements count is even
        if (count % 2 == 0)
        {
            return (data[medianIndex - 1] + data[medianIndex]) / 2;
        }

        // Median when elements count is odd
        return data[medianIndex];
    }

    public List<double> Mode(List<double> data)
    {
        this.checkIfDatasetHasElements(data);

        var frequencyByElement = data.GroupBy(n => n)
            .Select(group => new { Number = group.Key, Count = group.Count() })
            .ToList();

        int maxCount = frequencyByElement.Max(g => g.Count);
        if (maxCount == 1)
        {
            return new List<double>();
        }

        return frequencyByElement.Where(g => g.Count == maxCount)
            .Select(g => g.Number)
            .ToList();
    }

    private void checkIfDatasetHasElements(List<double> data)
    {
        if ((data?.Count ?? 0) == 0)
        {
            throw new EmptyDataSetException("Dataset is empty or null.");
        }
    }
}
