using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class WindowsManagement : IWindowsManagement
{
    public WindowsManagement()
    {
        Buttons.Add(WindowType.MainMenu, true);
        Buttons.Add(WindowType.GenerateExport, false);
        Buttons.Add(WindowType.Multiplayer, false);
        Buttons.Add(WindowType.Settings, false);
    }

    public Dictionary<WindowType, bool> Buttons { get; set; } =  new();
}