# ✨ Furryfier

Makes your text as **UwU-OwO** as possible.  
Use with caution — it can be contagious... _UwU_

[![NuGet](https://img.shields.io/nuget/v/Furryfier.svg)](https://www.nuget.org/packages/Furryfier/)

💡 Install via .NET CLI:
```bash
dotnet add package Furryfier --version <latest_version>
```

## 🚀 Usage
### 🐾 Default furryfier config usage (uwu)

```cs
using Furryfier;

namespace Project;

internal abstract class Program
{
    private static void Main()
    {
        // Input string
        var inputString = "Hey! My name is Ihar. I like baskinball, pizza and funny cats!";
        
        // Handling with default config
        inputString = TextFurryfier.Furrify(inputString);
            
        // Default Result
        Console.WriteLine(inputString);
    }
}
```
### 📄 Example output:
```txt
Hey! My name is Ihaw. Rawr I like baskinball, pizza anyd funny cats! OWO
```

<hr>

### 🎛️ Custom config (owo)

```cs
using Furryfier;

namespace Uwunizator;

internal abstract class Program
{
    private static void Main()
    {
        // Input string
        var inputString = "Hey! My name is Ihar. I like baskinball, pizza and funny cats!";
 
        // Preparing a custom config
        var config = new FurryfierConfig
            {
                StartChance = 90,
                EndChance = 90,
                StartDuplicationChance = 0,
                EndDuplicationChance = 90,
                BetweenSentenceChance = 90,
                BetweenSentenceDuplicationChance = 90
            }
            .AddSlang("HELP ME!!!!!!!", 100)
            .AddSlang(new Dictionary<string, int>
            {
                {"hiiiiiii", 100},
                {"im going to touch you~~~", 100},
            })
            .RemoveSlang("uwu")
            .AddReplacement('o', "0", 100)
            .RemoveReplacement('s');

        // Handling with custom config
        inputString = TextFurryfier.Furrify(inputString, config);
        
        // Custom Result
        Console.WriteLine(inputString);
    }
}
```
### 📄 Example output:
```txt
*giggles* Hey! *boops* >w< My name 1s Ihar. *sniff* I l1ke bask1nball, p1zza and funny cats! *notices you* *blushes* UwU
```

<hr>

## 🍺 Project Budget
* A bottle of beer 🍼

* Snacks 🍿

* A free evening 🕒

📦 Also, check out the TypeScript version of this library:
👉 [GenAi-Bot/furryfier](https://github.com/GenAi-Bot/furryfier)

    Made with ❤️ specially for GenAi
