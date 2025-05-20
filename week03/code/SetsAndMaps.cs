using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

/// <summary>
/// This static class contains several methods solving problems
/// related to Sets, Maps (Dictionaries), and JSON data handling.
/// </summary>
public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two-character 
    /// words (lowercase, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.
    /// 
    /// For example, if words was: [am, at, ma, if, fi], this method
    /// would return:
    /// ["am & ma", "if & fi"]
    /// 
    /// The order of the array and the order of words in each string
    /// does not matter.
    /// 
    /// Special case: words like 'aa' are palindromes and do not form pairs.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    /// <returns>Array of strings describing symmetric pairs.</returns>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());

            if (word == reversed)
                continue;

            if (wordSet.Contains(reversed) && !seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Reads a census file and summarizes the degrees (education)
    /// earned by those contained in the file. The summary is stored
    /// in a dictionary where the key is the degree and the value is
    /// the number of people who earned that degree.
    /// 
    /// The degree information is located in the 4th column (index 3).
    /// Assumes no header row in the file.
    /// </summary>
    /// <param name="filename">The filename to read</param>
    /// <returns>A dictionary mapping degree name to count</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length < 4)
                continue;

            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determines if 'word1' and 'word2' are anagrams.
    /// An anagram is when the same letters of a word are
    /// rearranged to form a new word.
    /// 
    /// This method ignores spaces and case differences.
    /// Uses a dictionary to count letter frequencies.
    /// 
    /// Examples:
    /// IsAnagram("CAT","ACT") returns true
    /// IsAnagram("DOG","GOOD") returns false
    /// </summary>
    /// <param name="word1">First word</param>
    /// <param name="word2">Second word</param>
    /// <returns>True if the words are anagrams; otherwise false</returns>
    public static bool IsAnagram(string word1, string word2)
    {
        var w1 = word1.Replace(" ", "").ToLower();
        var w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length)
            return false;

        var letterCounts = new Dictionary<char, int>();

        foreach (var c in w1)
        {
            if (!letterCounts.ContainsKey(c))
                letterCounts[c] = 0;
            letterCounts[c]++;
        }

        foreach (var c in w2)
        {
            if (!letterCounts.ContainsKey(c) || letterCounts[c] == 0)
                return false;

            letterCounts[c]--;
        }

        return true;
    }

    /// <summary>
    /// Reads JSON data from the USGS earthquake API for all earthquakes today,
    /// deserializes it, and returns a summary of earthquake locations and magnitudes.
    /// </summary>
    /// <returns>Array of strings describing each earthquake's place and magnitude</returns>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
        {
            return Array.Empty<string>();
        }

        var summaries = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties?.Place ?? "Unknown location";
            double? mag = feature.Properties?.Mag;

            string magStr = mag.HasValue ? mag.Value.ToString("0.0") : "N/A";
            string summary = $"Place: {place}, Magnitude: {magStr}";
            summaries.Add(summary);
        }

        return summaries.ToArray();
    }
}

/// <summary>
/// Represents the top-level collection of earthquake features
/// in the GeoJSON data returned by the USGS API.
/// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Represents each individual earthquake event (feature)
/// containing properties like place and magnitude.
/// </summary>
public class Feature
{
    public Properties Properties { get; set; }
}

/// <summary>
/// Represents the earthquake properties such as location and magnitude.
/// </summary>
public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}
