using Furryfier.Protection;

namespace Furryfier;

public class FurryfierConfig
{
    /// <summary>
    /// Protection for sensitive data
    /// </summary>
    public ProtectedPatternsConfig ProtectedPatternsConfig { get; init; }
    
    /// <summary>
    /// Chance, that the additional text will be added to the start of the text
    /// </summary>
    public int StartChance { get; init; } = 20;
    
    /// <summary>
    /// Chance, that the additional text will be added to the start several times
    /// </summary>
    public int StartDuplicationChance { get; init; } = 10;
    
    /// <summary>
    /// Chance, that the additional text will be added to the end of the text
    /// </summary>
    public int EndChance { get; init; } = 20;
    
    /// <summary>
    /// Chance, that the additional text will be added to the end several times
    /// </summary>
    public int EndDuplicationChance { get; init; } = 10;
    
    /// <summary>
    /// Chance, that the additional text will be added between sentences
    /// </summary>
    public int BetweenSentenceChance { get; init; } = 30;
    
    /// <summary>
    /// Chance, that the additional text will be added between sentences several times
    /// </summary>
    public int BetweenSentenceDuplicationChance { get; init; } = 5;

    /// <summary>
    /// Slang uwu
    /// </summary>
    public Dictionary<string, int> Slang { get; }
    
    /// <summary>
    /// Chances, that the letter will be furryfied
    /// </summary>
    public Dictionary<char, (string replacement, int chance)> LetterReplacements { get; }

    /// <summary>
    /// Creates default furryfier config
    /// </summary>
    public FurryfierConfig()
    {
        Slang = DefaultSlang().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        LetterReplacements = DefaultReplacements().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    /// <summary>
    /// Default slang dictionary
    /// </summary>
    private static Dictionary<string, int> DefaultSlang() => new()
    {
        {"uwu", 30}, {"UwU", 30}, {"UWU", 30},
        {"owo", 30}, {"OwO", 30}, {"OWO", 30},
        {"=w=", 30}, {"=W=", 30},
        {"rawr", 20}, {"Rawr", 20}, {"RAWR", 20},
        {"nyaa", 5}, {"NyaA", 5}, {"NYAA", 5},
        {"nyan", 5}, {"Nyan", 5}, {"NYAN", 5},
        {"nya~", 5}, {"nya", 5}, {"nyaa~", 5}, {"nya~!", 5},
        {"~~~", 10},
        {"*purr*", 30}, {"*nuzzles*", 30}, {"*blushes*", 30}, {"*hugs*", 10}, {"*sniff*", 10},
        {"*boops*", 30}, {"*squee*", 30}, {"*fluff*", 30},
        {"*giggles*", 10}, {"*snuggles*", 20}, {"*notices you*", 20}, {"*paws at you*", 20},
        {"hewo", 1}, {"hewwo", 1}, {"H-hewwo!", 10},
        {"b-baka", 5}, {"tehe", 5},
        {"mew", 10}, {"mewmew", 10}, {"mrowr", 15},
        {"x3", 50}, {">w<", 50}, {"^w^", 50}, {":3", 50},
        {"rawr x3", 10}, {"rawr >w<", 10}, {"rawr ^w^", 10}, {"rawr :3", 10},
        {"blep", 25}
    };

    /// <summary>
    /// Default letter replacements dictionary
    /// </summary>
    private static Dictionary<char, (string replacement, int chance)> DefaultReplacements() => new()
    {
        ['r'] = ("w", 20), ['l'] = ("w", 20),
        ['R'] = ("W", 20), ['L'] = ("W", 20),
        ['n'] = ("ny", 20), ['N'] = ("Ny", 20),
        ['a'] = ("aw", 10), ['A'] = ("Aw", 10),
        ['t'] = ("tw", 10), ['T'] = ("Tw", 10),
        ['s'] = ("z", 20), ['S'] = ("Z", 20),
        ['р'] = ("в", 20), ['Р'] = ("В", 20),
        ['л'] = ("в", 20), ['Л'] = ("В", 20)
    };
}