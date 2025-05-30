using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());

            if (word == reversed) continue; // skip palindromic pairs

            if (wordSet.Contains(reversed) && !seen.Contains(reversed) && !seen.Contains(word))
            {
                result.Add($"{word} & {reversed}");
                seen.Add(word);
                seen.Add(reversed);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Reads a census file and summarizes the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) continue;

            var degree = fields[3].Trim();
            if (string.IsNullOrEmpty(degree)) continue;

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determines if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var w1 = word1.Replace(" ", "").ToLower();
        var w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length) return false;

        var letterCounts = new Dictionary<char, int>();
        foreach (var c in w1)
        {
            if (!letterCounts.ContainsKey(c)) letterCounts[c] = 0;
            letterCounts[c]++;
        }

        foreach (var c in w2)
        {
            if (!letterCounts.ContainsKey(c) || letterCounts[c] == 0) return false;
            letterCounts[c]--;
        }

        return true;
    }

    /// <summary>
    /// Reads JSON data from the USGS earthquake API for all earthquakes today,
    /// deserializes it, and returns a summary of locations and magnitudes.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        try
        {
            const string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            using var client = new HttpClient();

            var jsonStream = client.GetStreamAsync(url).Result;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);

            if (featureCollection?.Features == null || featureCollection.Features.Count == 0)
                return Array.Empty<string>();

            var summaries = new List<string>();

            foreach (var feature in featureCollection.Features)
            {
                string place = feature.Properties?.Place ?? "Unknown location";
                double? mag = feature.Properties?.Mag;

                // If magnitude is missing, use "N/A"
                string magString = mag.HasValue ? mag.Value.ToString("0.0") : "N/A";

                string summary = $"Place: {place}, Magnitude: {magString}";
                summaries.Add(summary);
            }

            return summaries.ToArray();
        }
        catch (Exception ex)
        {
            // In case of failure (e.g., network issues), return an empty array or an error message
            return new string[] { $"Error fetching earthquake data: {ex.Message}" };
        }
    }

    // JSON mapping classes
    public class FeatureCollection
    {
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string Place { get; set; }
        public double? Mag { get; set; }
    }
}
