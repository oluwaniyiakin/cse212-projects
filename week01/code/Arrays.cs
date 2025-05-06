using System;

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
        //
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

        // Step 1: Create an array to hold the result
        double[] result = new double[count];

        // Step 2: Loop to fill the array with multiples
        for (int i = 0; i < count; i++)
        {
            // Step 3: Calculate and store each multiple
            result[i] = start * (i + 1);
        }

        // Step 4: Return the array of multiples
        return result;
    }
}
