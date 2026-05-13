using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Creates an array of multiples of a number.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to hold the results
        // Step 2: Loop from 0 to length - 1
        // Step 3: Each element is number * (index + 1)
        // Step 4: Return the array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotates the list to the right by a given amount (in-place).
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find effective rotation using modulo
        // Step 2: Take last 'amount' elements
        // Step 3: Move them to the front
        // Step 4: Replace original list contents

        int n = data.Count;
        int shift = amount % n;

        if (shift == 0)
            return;

        List<int> temp = new List<int>();

        temp.AddRange(data.GetRange(n - shift, shift));
        temp.AddRange(data.GetRange(0, n - shift));

        data.Clear();
        data.AddRange(temp);
    }
}