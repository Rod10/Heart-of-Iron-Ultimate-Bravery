using Avalonia;
using Avalonia.Media.Imaging;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class ButtonItem
{
    public ButtonItem(string name, Thickness margin, Bitmap image)
    {
        Name = name;
        Margin = margin;
        Image = image;
    }

    public string Name { get; set; }
    public Thickness Margin { get; set; }
    public Bitmap Image { get; set; }
}