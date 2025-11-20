using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks; // Added for best practice with async networking

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // 1. Initialize a HashSet for O(1) average time complexity lookups.
        HashSet<string> wordSet = new HashSet<string>(words);
        
        // 2. Initialize a list to store the resulting pairs.
        List<string> resultPairs = new List<string>();

        // 3. Iterate through the original words array. O(n) loop.
        foreach (string word in words)
        {
            // Edge case: Skip words with identical letters (e.g., "aa").
            if (word[0] == word[1])
            {
                continue;
            }

            // 4. Calculate the reverse of the current word. 
            string reversedWord = new string(new[] { word[1], word[0] });

            // 5. Check if the reversed word exists in the set. O(1) average time complexity.
            if (wordSet.Contains(reversedWord))
            {
                // To prevent adding the pair twice, only add when 'word' is lexicographically smaller than its reverse.
                if (string.Compare(word, reversedWord) < 0)
                {
                    resultPairs.Add($"{word} & {reversedWord}");
                }
            }
        }
        
        // 6. Return the list of pairs as an array.
        return resultPairs.ToArray();
    }


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>Dictionary of degree counts</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        // NOTE: File.ReadLines requires System.IO
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Check if there are enough fields (4 columns means indices 0, 1, 2, 3)
            if (fields.Length > 3) 
            {
                // The degree information is in the 4th column, which is index 3.
                string degree = fields[3].Trim(); 
                
                // Increment the count for the degree in the dictionary.
                if (degrees.TryGetValue(degree, out int currentCount))
                {
                    // Key exists: Increment the count
                    degrees[degree] = currentCount + 1;
                }
                else
                {
                    // Key does not exist: Add the key with a count of 1
                    degrees.Add(degree, 1);
                }
            }
        }
        
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // 1. Initialize the character count dictionary.
        Dictionary<char, int> charCounts = new Dictionary<char, int>();

        // 2. Process word1: Build the character frequency map.
        foreach (char c in word1)
        {
            // Ignore spaces and convert to lower case for case-insensitivity.
            if (char.IsWhiteSpace(c))
            {
                continue;
            }
            char lowerC = char.ToLower(c);

            // Increment count for the character.
            if (charCounts.TryGetValue(lowerC, out int count))
            {
                charCounts[lowerC] = count + 1;
            }
            else
            {
                charCounts.Add(lowerC, 1);
            }
        }

        // 3. Process word2: Decrement counts based on characters found.
        foreach (char c in word2)
        {
            // Ignore spaces and convert to lower case.
            if (char.IsWhiteSpace(c))
            {
                continue;
            }
            char lowerC = char.ToLower(c);

            // Check if the character is in the map and has a count > 0.
            if (charCounts.TryGetValue(lowerC, out int count) && count > 0)
            {
                // Decrement the count.
                charCounts[lowerC] = count - 1;
            }
            else
            {
                // Cannot be an anagram.
                return false; 
            }
        }

        // 4. Final check: All counts in the dictionary must be zero.
        return charCounts.Values.All(count => count == 0);
    }


    /// <summary>
    /// This function will read JSON data from the USGS consisting of earthquake data.
    /// It returns a list of all earthquake locations ('place') and magnitudes ('mag').
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        // NOTE: HttpClient requires System.Net.Http
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        
        try 
        {
            // 1. Setup the HTTP client.
            using var client = new HttpClient();
            
            // WARNING: Blocking on an async call (.Result) is bad practice in most C# apps.
            // If this were a real application (not a class exercise), the method signature should be 'public static async Task<string[]>'
            // and the call would be 'using var jsonStream = await client.GetStreamAsync(uri);'
            var jsonStreamTask = client.GetStreamAsync(uri);
            using var jsonStream = jsonStreamTask.Result; 

            // 2. Setup Deserialization options.
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // NOTE: Deserialization requires the FeatureCollection, Feature, and Properties classes defined elsewhere.
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);

            // 3. Handle null result.
            if (featureCollection?.Features == null)
            {
                return new string[0]; 
            }

            // 4. Transform the data into the desired string array format.
            string[] summary = featureCollection.Features
                .Select(feature => 
                {
                    var p = feature.Properties;
                    // Format the output string: Location Name - Mag X.XX
                    return $"{p.Place} - Mag {p.Mag:F2}";
                })
                .ToArray();

            return summary;
        }
        catch (Exception ex)
        {
            // Catch any networking or deserialization errors at runtime.
            Console.WriteLine($"Error in EarthquakeDailySummary: {ex.Message}");
            return new string[] { "Error fetching earthquake data." };
        }
    }
}