using System;

public class StringCalculator
{
    private int _calledCount = 0;

    public int CalledCount => _calledCount;

    public int Add(string numbers)
    {
        _calledCount++;
        if (string.IsNullOrEmpty(numbers))
            return 0;

        string[] separators = { ",", "\n" };

        if (numbers.StartsWith("//"))
        {
            separators = new[] { numbers[2].ToString() };
            numbers = numbers.Substring(4);
        }

        string[] nums = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int sum = 0;

        List<int> negatives = new List<int>();

        foreach (var num in nums)
        {
            if (int.TryParse(num, out int parsedNum))
            {
                if (parsedNum < 0)
                    negatives.Add(parsedNum);

                if (parsedNum <= 1000)
                    sum += parsedNum;
            }
        }

        if (negatives.Count > 0)
            throw new InvalidOperationException($"negatives not allowed {string.Join(", ", negatives)}");

        return sum;
    }
}