using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function returns an array of multiples.
    /// For example, MultiplesOf(3, 5) should return: {3, 6, 9, 12, 15}
    /// </summary>
    /// <param name="start">The starting number whose multiples we want</param>
    /// <param name="count">How many multiples to generate</param>
    /// <returns>An array containing the multiples</returns>
    public static double[] MultiplesOf(double start, int count)
    {
        // Step-by-step plan:
        // Step 1: Create a new array of type double and size equal to 'count'
        //         This will hold the multiples we calculate.
        //
        // Step 2: Loop from i = 0 to i < count
        //         For each i, compute the multiple using: start * (i + 1)
        //         This gives us the first 'count' multiples of 'start'
        //
        // Step 3: Store each multiple in the array at position i
        //
        // Step 4: After the loop, return the array

        double[] result = new double[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// This function rotates a list to the right by a specified amount.
    /// For example, RotateListRight({1,2,3,4,5}, 2) => {4,5,1,2,3}
    /// </summary>
    /// <param name="data">The list of integers to rotate</param>
    /// <param name="amount">The number of positions to rotate right</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step-by-step plan:
        //
        // Step 1: Calculate the index where the rotation should begin.
        //         That is, how many items from the end should move to the front.
        //
        // Step 2: Use GetRange to split the list into two parts:
        //         - Part A: the last 'amount' items
        //         - Part B: the remaining items at the front
        //
        // Step 3: Clear the original list
        //
        // Step 4: Use AddRange to add Part A, then Part B into the list (in new order)

        // Step 1: Find split index (start of last `amount` elements)
        int splitIndex = data.Count - amount;

        // Step 2: Slice the list into two parts
        List<int> partA = data.GetRange(splitIndex, amount);
        List<int> partB = data.GetRange(0, splitIndex);

        // Step 3: Clear original list
        data.Clear();

        // Step 4: Add the rotated parts
        data.AddRange(partA);
        data.AddRange(partB);
    }
}
