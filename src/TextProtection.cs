using System.Text.RegularExpressions;
using Furryfier.Protection;

namespace Furryfier;

public static class TextProtector
{
    public static ProtectedTextResult ProtectText(string input, ProtectedPatternsConfig config)
    {
        var protectedParts = new List<ProtectedPart>();
        var index = 0;

        var patterns = new List<Regex>(config.ProtectedPatterns);

        if (config.EnableDiscordMode)
        {
            patterns.AddRange(config.DiscordProtectedPatterns);
        }

        var fullPattern = string.Join("|", patterns.Select(r => r.ToString()));
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

    public static string RestoreProtectedText(string text, List<ProtectedPart> protectedParts)
    {
        var result = text;
        foreach (var part in protectedParts)
        {
            result = result.Replace(part.Placeholder, part.Original);
        }
        return result;
    }
}