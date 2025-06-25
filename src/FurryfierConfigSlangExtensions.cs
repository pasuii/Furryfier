namespace Furryfier;

public static class FurryfierConfigSlangExtensions
{
    /// <summary>
    /// Adds new phrase to the slang dictionary
    /// </summary>
    /// <param name="config">Fyrryfier config</param>
    /// <param name="phrase">Slang to add</param>
    /// <param name="chance">Chance of appearance</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig AddSlang(this FurryfierConfig config, string phrase, int chance)
    {
        config.Slang.TryAdd(phrase, chance);
        return config;
    }

    /// <summary>
    /// Adds multiple phrases to the slang dictionary
    /// </summary>
    /// <param name="config">Fyrryfier config</param>
    /// <param name="slang">Slang dictionary to add</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig AddSlang(this FurryfierConfig config, Dictionary<string, int> slang)
    {
        foreach (var pair in slang)
        {
            config.Slang[pair.Key] = pair.Value;
        }
        return config;
    }

    /// <summary>
    /// Removes phrase from the slang dictionary
    /// </summary>
    /// <param name="config">Fyrryfier config</param>
    /// <param name="phrase">Slang to add</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig RemoveSlang(this FurryfierConfig config, string phrase)
    {
        config.Slang.Remove(phrase);
        return config;
    }

    /// <summary>
    /// Updates chance of phrase in the slang dictionary
    /// </summary>
    /// <param name="config">Fyrryfier config</param>
    /// <param name="phrase">Slang to add</param>
    /// <param name="newChance">Chance of appearance</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig UpdateSlang(this FurryfierConfig config, string phrase, int newChance)
    {
        config.Slang[phrase] = newChance;
        return config;
    }
    
    /// <summary>
    /// Replaces slang dictionary with new
    /// </summary>
    /// <param name="config">Furryfier config</param>
    /// <param name="newSlang">New slang dictionary</param>
    /// <returns>Updated config</returns>
    public static FurryfierConfig ReplaceSlang(this FurryfierConfig config, Dictionary<string, int> newSlang)
    {
        config.Slang.Clear();
        foreach (var pair in newSlang)
        {
            config.Slang[pair.Key] = pair.Value;
        }
        return config;
    }
}