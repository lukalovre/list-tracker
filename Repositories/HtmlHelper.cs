using System;
using System.Diagnostics;
using System.Linq;
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
}
