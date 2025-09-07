using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Settings(string language, string gamePath, Mod mod) : ISettings
{
    public string Language { get; set; } = language;
    public string GamePath { get; set; } = gamePath;
    public Mod CurrentMod { get; set; } = mod;

    public bool SetLanguage(string language)
    {
        throw new System.NotImplementedException();
    }
    public bool SetGamePath(string path)
    {
        throw new System.NotImplementedException();
    }

    public bool SetMod(Mod mod)
    {
        throw new System.NotImplementedException();
    }
}