using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class Mod
{
    public string Name {  get; set; }
    public int steamId { get; set; }
    public List<Country> countries { get; set; } 
}