using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Settings(string gamePath, Mod mod) : ISettings
{
    public string GamePath { get; set; } = gamePath;
    public Mod CurrentMod { get; set; } = mod;

    public bool SetGamePath(string path)
    {
        throw new System.NotImplementedException();
    }

    public bool SetMod(Mod mod)
    {
        throw new System.NotImplementedException();
    }
}