//this file for Part 1
//W01 Code: Dynamic Arrays
// Plan: The function will take a starting number (start) and a count of multiples to return.
public double[] MultiplesOf(int start, int count)
{
    // Create an array to store the multiples.
    double[] multiples = new double[count];
    
    // Loop to fill the array with multiples of 'start'
    for (int i = 0; i < count; i++)
    {
        multiples[i] = start * (i + 1); // Fill the array with multiples.
    }
    
    return multiples;
}
