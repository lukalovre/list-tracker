using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Repositories;

public static class HtmlHelper
{
    public static int GetYear(string str)
    {
        var years = Regex.Matches(str, @"\d{4}");
        var yearList = years.Select(o => Convert.ToInt32(o.Value));

        return yearList.Where(o => o > 1900 && o < 2999).Min();
    }

    public static void OpenLink(string link)
    {
        Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
    }

    public static void OpenLink(string link, List<string> arguments)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            // Make this a search engine choice in settings
            link = $"https://duckduckgo.com/?q={string.Join("+", arguments)}";
        }

        OpenLink(link);
    }

    internal static void DownloadPNG(string webFile, string destinationFile)
    {
        if (string.IsNullOrEmpty(webFile))
        {
            return;
        }

        destinationFile = $"{destinationFile}.png";

        FileRepsitory.Delete(destinationFile);

        if (File.Exists(destinationFile))
        {
            return;
        }

        var directory = Path.GetDirectoryName(destinationFile);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (webFile == null || webFile == "N/A")
        {
            return;
        }

        using (WebClient client = new WebClient())
        {
            client.DownloadFile(new Uri(webFile), destinationFile);
        }
    }

    public static string CleanUrl(string url)
    {
        return url?.Split('?')?.FirstOrDefault()?.Trim() ?? string.Empty;
    }

    // public static List<ImdbListItem> GetFromList(string listFolderPath, string listName, IEnumerable<string> filter, out DateTime updatedDate)
    // {
    //     var result = new List<ImdbListItem>();

    //     var listPathHtm = Path.Combine(listFolderPath, $"{listName}.htm");
    //     var listPathJson = Path.Combine(listFolderPath, $"{listName}.json");

    //     updatedDate = File.GetLastWriteTime(listPathHtm);

    //     if (!File.Exists(listPathHtm))
    //     {
    //         return result;
    //     }

    //     if (File.Exists(listPathJson))
    //     {
    //         var json = File.ReadAllText(listPathJson);
    //         return JsonConvert.DeserializeObject<List<ImdbListItem>>(json);
    //     }

    //     var lines = File.ReadAllLines(listPathHtm);

    //     foreach (var line in lines)
    //     {
    //         if (line.Contains(@"/title/tt"))
    //         {
    //             string pattern = @"tt\d{7}";
    //             var match = Regex.Match(line, pattern);
    //             var imdbID = match.Value;

    //             if (!string.IsNullOrWhiteSpace(match.Value))
    //             {
    //                 pattern = @"tt\d{8}";
    //                 match = Regex.Match(line, pattern);

    //                 if (!string.IsNullOrWhiteSpace(match.Value))
    //                 {
    //                     imdbID = match.Value;
    //                 }
    //             }

    //             if (result.Any(o => o.Imdb == imdbID))
    //             {
    //                 continue;
    //             }

    //             if (filter.Any(o => o == imdbID))
    //             {
    //                 // To keep the correct positions
    //                 result.Add(new ImdbListItem { Imdb = imdbID });
    //                 continue;
    //             }

    //             var imdbData = Imdb.GetDataFromAPI(imdbID, false);

    //             result.Add(new ImdbListItem
    //             {
    //                 Imdb = imdbData.imdbID,
    //                 Directors = imdbData.Director,
    //                 Title = imdbData.Title,
    //                 Year = int.Parse(imdbData.Year.Split('–').FirstOrDefault()),
    //                 Runtime = GetMinutes(imdbData),
    //                 NumVotes = imdbData.imdbVotes == "N/A" ? 0 : int.Parse(imdbData.imdbVotes.Replace(",", string.Empty)),
    //                 IMDbRating = imdbData.imdbRating == "N/A" ? 0 : float.Parse(imdbData.imdbRating),
    //                 Position = result.Count + 1,
    //                 Metascore = imdbData.Metascore == "N/A" ? null : (int?)int.Parse(imdbData.Metascore)
    //             });
    //         }
    //     }

    //     var jsonText = JsonConvert.SerializeObject(result, Formatting.Indented);

    //     File.WriteAllText(listPathJson, jsonText);

    //     return result;
    // }

    // public record ImdbItem(
    // string Title,
    // int Runtime,
    // int Year,
    // string ExternalID,
    // string Actors,
    // string Country,
    // string Director,
    // string Genre,
    // string Language,
    // string Plot,
    // string Type,
    // string Writer,
    // string StandupPerformer,
    // string StandupTitle);

    // private static int GetMinutes(ImdbData imdbData)
    // {
    //     if (imdbData.Runtime == @"\N" || imdbData.Runtime == @"N/A")
    //     {
    //         return 0;
    //     }

    //     if (int.TryParse(imdbData.Runtime.TrimEnd(" min".ToArray()), out var result))
    //     {
    //         return result;
    //     }

    //     return 0;
    // }
}
