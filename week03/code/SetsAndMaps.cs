using System.Text.Json;

// Author: shema20k

public static class SetsAndMaps
{
    /// <summary>
    /// Find symmetric pairs of 2-letter words in O(n) time.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> set = new(words);
        HashSet<string> used = new();
        List<string> result = new();

        foreach (string word in words)
        {
            if (used.Contains(word))
                continue;

            string reversed = new string(new char[] { word[1], word[0] });

            if (word != reversed && set.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                used.Add(word);
                used.Add(reversed);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Summarize degrees from file (column 4)
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Check if two words are anagrams (ignore spaces + case)
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new();

        foreach (char c in word1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;

            counts[c]++;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Earthquake JSON summary
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(request);
        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);

        string json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var data = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();

        if (data?.Features != null)
        {
            foreach (var f in data.Features)
            {
                result.Add($"{f.Properties.Place} - Mag {f.Properties.Mag}");
            }
        }

        return result.ToArray();
    }
}