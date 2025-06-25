namespace Furryfier;

public static class FurryfierConfigReplacementsExtensions
{
    /// <summary>
    /// Adds new character replacement
    /// </summary>
    /// <param name="config">Fyrryfier config</param>
    /// <param name="character">Character to replace</param>
    /// <param name="replacement">Replacement</param>
    /// <param name="chance">Chance of appearance</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig AddReplacement(this FurryfierConfig config, char character, string replacement, int chance)
    {
        if (!config.LetterReplacements.ContainsKey(character))
        {
            config.LetterReplacements.Add(character, (replacement, chance));
        }
        return config;
    }
    
    /// <summary>
    /// Adds or updates multiple letter replacements
    /// </summary>
    /// <param name="config">Furryfier config</param>
    /// <param name="letterReplacements">Letter replacements to add</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig AddReplacement(this FurryfierConfig config, Dictionary<char, (string replacement, int chance)> letterReplacements)
    {
        foreach (var pair in letterReplacements)
        {
            config.LetterReplacements[pair.Key] = pair.Value;
        }
        return config;
    }

    /// <summary>
    /// Removes character replacement
    /// </summary>
    /// <param name="config">Fyrryfier config</param>
    /// <param name="character">Character to replace</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig RemoveReplacement(this FurryfierConfig config, char character)
    {
        config.LetterReplacements.Remove(character);
        return config;
    }

    /// <summary>
    /// Updates character replacement
    /// </summary>    
    /// <param name="config">Fyrryfier config</param>
    /// <param name="character">Character to replace</param>    
    /// <param name="newReplacement">Replacement</param>
    /// <param name="newChance">Chance of appearance</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig UpdateReplacement(this FurryfierConfig config, char character, string newReplacement, int newChance)
    {
        config.LetterReplacements[character] = (newReplacement, newChance);
        return config;
    }
    
    /// <summary>
    /// Replaces letters replacement dictionary with new
    /// </summary>
    /// <param name="config">Fyrryfier config</param>
    /// <param name="newReplacements">New replacement dictionary</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig ReplaceReplacement(this FurryfierConfig config, Dictionary<string, int> newReplacements)
    {
        config.Slang.Clear();
        foreach (var pair in newReplacements)
        {
            config.Slang[pair.Key] = pair.Value;
        }
        return config;
    }
}