namespace Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

public interface ISettings
{
    public string Language { get; }
    public string GamePath { get; }
    public Mod CurrentMod { get; }
    
    public void SetLanguage(string language);
    public void SetGamePath(string path);
    public void SetMod(string mod);
}