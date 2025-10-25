using System.Text.RegularExpressions;

namespace Furryfier.Protection;

internal static class TextProtectorExtensions
{
    public static ProtectedTextResult ProtectText(this string input, ProtectedPatternsConfig config)
    {
        var protectedParts = new List<ProtectedPart>();
        var index = 0;

        var patternStrings = new List<string>();

        patternStrings.AddRange(config.ProtectedPatterns.Select(r => r.ToString()));

        if (config.EnableDiscordMode)
        {
            patternStrings.AddRange(config.DiscordProtectedPatterns.Select(r => r.ToString()));
        }

        var fullPattern = string.Join("|", patternStrings.Select(p => "(" + p + ")"));

        var regex = new Regex(fullPattern, RegexOptions.Compiled);

        var protectedText = regex.Replace(input, match =>
        {
            var placeholder = new string('ඞ', index + 1);
            protectedParts.Add(new ProtectedPart(placeholder, match.Value));
            index++;
            return placeholder;
        });

        return new ProtectedTextResult(protectedText, protectedParts);
    }

    public static string RestoreProtectedText(this string text, List<ProtectedPart> protectedParts)
    {
        var result = text;

        foreach (var part in protectedParts.OrderByDescending(p => p.Placeholder.Length))
        {
            result = result.Replace(part.Placeholder, part.Original);
        }

        return result;
    }
}