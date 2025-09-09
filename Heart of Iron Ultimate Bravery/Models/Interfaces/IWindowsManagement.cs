using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Constant;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

public interface IWindowsManagement
{
    public Dictionary<WindowType, bool> Buttons { get; set; }
}