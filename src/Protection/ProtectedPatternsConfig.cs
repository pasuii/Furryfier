using System.Text.RegularExpressions;

namespace Furryfier.Protection;

public abstract class ProtectedPatternsConfig
{
    public Regex[] ProtectedPatterns { get; set; } = [ new Regex("\"/https?:\\\\/\\\\/\\\\S+/g\"")];
    public bool EnableDiscordMode { get; set; } = true;
    public Regex[] DiscordProtectedPatterns { get; set; } = [ new Regex("/<[^>]*>/g")];
}