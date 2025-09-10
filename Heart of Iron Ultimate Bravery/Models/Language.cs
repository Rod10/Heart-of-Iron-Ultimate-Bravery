namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Language
{
    public Language(string name, string local)
    {
        Name = name;
        Local = local;
    }

    public string Name { get; set; }
    public string Local { get; set; }
}