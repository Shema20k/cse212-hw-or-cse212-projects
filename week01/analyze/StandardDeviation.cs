public static class StandardDeviation
{
    public static void Run()
    {
        var numbers = new[] { 600, 470, 170, 430, 300 };
        Console.WriteLine(StandardDeviation1(numbers)); // 147.322
        Console.WriteLine(StandardDeviation2(numbers)); // 147.322
        Console.WriteLine(StandardDeviation3(numbers)); // 147.322
    }

    private static double StandardDeviation1(int[] numbers)
    {
        var total = 0.0;
        var count = 0;

        foreach (var number in numbers)
        {
            total += number;
            count += 1;
        }

        var avg = total / count;
        var sumSquaredDifferences = 0.0;

        foreach (var number in numbers)
        {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }

    private static double StandardDeviation2(int[] numbers)
    {
        var sumSquaredDifferences = 0.0;
        var countNumbers = 0;

        foreach (var number in numbers)
        {
            var total = 0;
            var count = 0;

            foreach (var value in numbers)
            {
                total += value;
                count += 1;
            }

            var avg = (double)total / count;
            sumSquaredDifferences += Math.Pow(number - avg, 2);
            countNumbers += 1;
        }

        var variance = sumSquaredDifferences / countNumbers;
        return Math.Sqrt(variance);
    }

    private static double StandardDeviation3(int[] numbers)
    {
        var count = numbers.Length;
        var avg = (double)numbers.Sum() / count;
        var sumSquaredDifferences = 0.0;

        foreach (var number in numbers)
        {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }
}