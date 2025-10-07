using Avalonia.Media.Imaging;

namespace Heart_of_Iron_Ultimate_Bravery.Models;

public class DesignerItem
{
    public double Left { get; set; }
    public double Top { get; set; }
    public double Width { get; set; }
    public Bitmap Image { get; set; }
    
    public DesignerItem(Bitmap image, double left, double top, double width)
    {
        Image = image;
        Left = left;
        Top = top;
        Width = width;
    }
}