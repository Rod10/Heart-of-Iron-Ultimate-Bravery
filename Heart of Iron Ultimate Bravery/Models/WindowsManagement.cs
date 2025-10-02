using System.Collections.Generic;
using Heart_of_Iron_Ultimate_Bravery.Constant;
using Heart_of_Iron_Ultimate_Bravery.Models.Interfaces;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class WindowsManagement : IWindowsManagement
{
    public WindowsManagement()
    {
        Buttons.Add(WindowType.MainMenu, false);
        Buttons.Add(WindowType.GenerateExport, true);
        Buttons.Add(WindowType.Multiplayer, false);
        Buttons.Add(WindowType.Settings, false);
        
        Panels.Add(WindowType.MainMenu, false);
        Panels.Add(WindowType.Generate, true);
        Panels.Add(WindowType.Export, false);
        Panels.Add(WindowType.Multiplayer, false);
        Panels.Add(WindowType.Settings, false);
    }

    public Dictionary<WindowType, bool> Buttons { get; set; } =  new();
    public Dictionary<WindowType, bool> Panels { get; set; } =  new();
}