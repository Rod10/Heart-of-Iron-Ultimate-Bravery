using Avalonia.Media.Imaging;

namespace Heart_of_Iron_Ultimate_Bravery.Models
{
  public class DesignerItem(Bitmap? image, double left, double top, double? width, string? text = null)
  {
    public double Left { get; set; } = left;

    public double Top { get; set; } = top;

    public double? Width { get; set; } = width;

    public Bitmap? Image { get; set; } = image;
    
    public string? Text { get; set; } = text;
  }
}