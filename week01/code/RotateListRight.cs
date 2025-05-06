//this file for Part 2
//W01 Code: Dynamic Arrays
using System;
using System.Collections.Generic;

namespace Week01
{
    public static class RotateListRightSolution
    {
        /// <summary>
        /// Rotates the list to the right by k positions.
        /// For example: 
        /// If data = {1, 2, 3, 4, 5, 6, 7, 8, 9} and k = 3,
        /// then rotated = {7, 8, 9, 1, 2, 3, 4, 5, 6}
        /// </summary>
        public static List<int> RotateListRight(List<int> data, int k)
        {
            // STEP 1: Check if the list is empty or k is 0 → return the list as-is
            if (data == null || data.Count == 0 || k == 0)
                return data;

            // STEP 2: Calculate the actual number of rotations needed
            // If k >= data.Count, we rotate by (k % data.Count) instead
            k = k % data.Count;

            // STEP 3: Break the list into two parts:
            // Part 1 = last k elements
            // Part 2 = first (count - k) elements
            List<int> lastPart = data.GetRange(data.Count - k, k);          // Get last k elements
            List<int> firstPart = data.GetRange(0, data.Count - k);         // Get the rest

            // STEP 4: Combine both parts (lastPart first, then firstPart)
            List<int> rotated = new List<int>();
            rotated.AddRange(lastPart);
            rotated.AddRange(firstPart);

            // STEP 5: Return the rotated list
            return rotated;
        }
    }
}
