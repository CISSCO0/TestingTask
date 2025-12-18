using System;
using System.Collections.Generic;

public class StringCalculator
{
    public int Add(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        var numbers = new List<int>();
        var current = "";
        var negatives = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (c == ',' || c == '\n')
            {
                ProcessNumber(current, numbers, negatives);
                current = "";
            }
            else
            {
                current += c;
            }
        }

        ProcessNumber(current, numbers, negatives);

        if (negatives.Count > 0)
            throw new Exception("Negatives not allowed: " + string.Join(",", negatives));

        int sum = 0;
        foreach (var n in numbers)
            sum += n;

        return sum;
    }

    private void ProcessNumber(string value, List<int> numbers, List<int> negatives)
    {
        if (string.IsNullOrEmpty(value))
            return;

        int number = int.Parse(value);

        if (number < 0)
            negatives.Add(number);
        else if (number <= 1000)
            numbers.Add(number);
    }
}
