using System.Text;
using System.Text.RegularExpressions;
using Furryfier.Protection;

namespace Furryfier;

public static partial class TextFurryfier
{
    [GeneratedRegex("(?<=[.!?])")]
    private static partial Regex SentenceRegex();
    
    /// <summary>
    /// Method for furryfying text
    /// </summary>
    /// <param name="input">Input string that will be furryfied</param>
    /// <param name="config">Config of furryfier. By default, uses default config</param>
    /// <returns></returns>
    public static string Furrify(string input, FurryfierConfig? config = null)
    {
        config ??= new FurryfierConfig();
        
        var rnd = new Random();

        var result = input.ProtectText(config.ProtectedPatternsConfig);
            
        var text = HandleText(result.ProtectedText, rnd, config);
        
        text = HandleBetweenSentences(text, rnd, config);

        var builder = new StringBuilder(text);
        
        builder.HandleStart(rnd, config);
        builder.HandleEnd(rnd, config);
        
        return builder.ToString().RestoreProtectedText(result.ProtectedParts);
    }
    
    private static string HandleText(string input, Random rnd, FurryfierConfig config)
    {
        var sb = new StringBuilder(input.Length);
        foreach (var ch in input)
        {
            if (config.LetterReplacements.TryGetValue(ch, out var rule))
            {
                var (replacement, chance) = rule;
                if (rnd.Next(1, 101) <= chance)
                {
                    sb.Append(replacement);
                    continue;
                }
            }
            sb.Append(ch);
        }
        return sb.ToString();
    }

    private static string HandleBetweenSentences(string input, Random rnd, FurryfierConfig config)
    {
        var parts = SentenceRegex().Split(input);
        var sb = new StringBuilder();
        foreach (var part in parts)
        {
            sb.Append(part);
            if (!part.EndsWith('.') && !part.EndsWith('!') && !part.EndsWith('?')) continue;
            
            if (rnd.Next(1, 101) > config.BetweenSentenceChance) continue;
                
            var count = GetInsertCount(rnd, config.BetweenSentenceDuplicationChance);
            for (var i = 0; i < count; i++)
            {
                var slang = GetRandomSlang(rnd, config);
                sb.Append(" " + slang);
            }
        }
        return sb.ToString();
    }

    private static void HandleStart(this StringBuilder builder, Random rnd, FurryfierConfig config)
    {
        if (rnd.Next(1, 101) > config.StartChance) return;
        var count = GetInsertCount(rnd, config.StartDuplicationChance);
        for (var i = 0; i < count; i++)
        {
            var slang = GetRandomSlang(rnd, config);
            builder.Insert(0, slang + " ");
        }
    }

    private static void HandleEnd(this StringBuilder builder, Random rnd, FurryfierConfig config)
    {
        if (rnd.Next(1, 101) > config.EndChance) return;
        var count = GetInsertCount(rnd, config.EndDuplicationChance);
        for (var i = 0; i < count; i++)
        {
            var slang = GetRandomSlang(rnd, config);
            builder.Append(" " + slang);
        }
    }

    private static int GetInsertCount(Random rnd, int duplicationChance)
    {
        var count = 1;
        while (rnd.Next(1, 101) <= duplicationChance)
        {
            count++;
        }
        return count;
    }

    private static string GetRandomSlang(Random rnd, FurryfierConfig config)
    {
        var weights = config.Slang;
        var total = weights.Values.Sum();
        var roll = rnd.Next(1, total + 1);
        foreach (var kv in weights)
        {
            roll -= kv.Value;
            if (roll <= 0) return kv.Key;
        }
        return string.Empty;
    }
}