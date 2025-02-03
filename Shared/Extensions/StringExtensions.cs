using System.Globalization;
using System.Text.RegularExpressions;

namespace Shared.Extensions;

public static class StringExtensions
{
    public static DateTime? ToDate(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return null;

        string pattern = @"^[a-z]{2}\d{4}-\d{2}-\d{2}$";
        Regex regex = new Regex(pattern);

        Match match = regex.Match(str);
        if (match.Success)
        {
            var cultureinfo = new CultureInfo(str.Substring(0, 2));
            DateTime.TryParseExact(str.Substring(0, 2), "yyyy-MM-dd", cultureinfo, DateTimeStyles.None, out DateTime date);
            return date;
        }

        pattern = @"(\d{4}-\d{2}-\d{2})$";
        regex = new Regex(pattern);
        match = regex.Match(str);

        if (match.Success)
        {
            DateTime.TryParseExact(str, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
            return date;
        }

        return null;
    }
}
