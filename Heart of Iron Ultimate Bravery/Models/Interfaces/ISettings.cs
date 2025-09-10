namespace Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

public interface ISettings
{
    public string Language { get; }
    public string GamePath { get; }
    public Mod CurrentMod { get; }
    
    public bool SetLanguage(string language);
    public bool SetGamePath(string path);
    public bool SetMod(string mod);
}