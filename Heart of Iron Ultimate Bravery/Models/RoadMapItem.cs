using System.Collections.Generic;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class RoadMapItem
{
    public RoadMapItem(string name, string completion,string margin, List<RoadMapItem>? tasks = null) 
    {
        Name = name;
        Completion = completion;
        Margin = margin;
        Tasks = tasks;
    }

    public string Name { get; set; }
    public string Completion { get; set; }
    public List<RoadMapItem>? Tasks { get; set; }
    public string Margin  { get; set; }
}