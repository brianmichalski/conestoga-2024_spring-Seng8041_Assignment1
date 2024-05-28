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

    public double Mode(List<double> data)
    {
        this.checkIfDatasetHasElements(data);

        var frequencyByElement = data.GroupBy(number => number)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .ToList();

        int maxCount = frequencyByElement.First().Count();
        if (frequencyByElement.Count(g => g.Count() == maxCount) > 1)
            throw new ArgumentException("Dataset has no mode.");

        return frequencyByElement.First().Key;
    }

    private void checkIfDatasetHasElements(List<double> data)
    {
        if ((data?.Count ?? 0) == 0)
        {
            throw new EmptyDataSetException("Dataset is empty or null.");
        }
    }
}
