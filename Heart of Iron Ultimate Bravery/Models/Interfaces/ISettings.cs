namespace Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

public interface ISettings
{
    public string GamePath { get; }
    public Mod CurrentMod { get; }
    
    public bool SetGamePath(string path);
    public bool SetMod(Mod mod);
}