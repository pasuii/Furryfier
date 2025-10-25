using System.Text.RegularExpressions;

namespace Furryfier.Protection;

public class ProtectedPatternsConfig
{
    public required Regex[] ProtectedPatterns { get; init; }
    public bool EnableDiscordMode { get; init; }
    public required Regex[] DiscordProtectedPatterns { get; init; }
}