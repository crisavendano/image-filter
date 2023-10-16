using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class MirrorEffect:IPhotoEffect
{
    private readonly string _description = "Refleja en el eje Y.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        var width = originalImage.Width;
        var height = originalImage.Height;
        var mirrorImage = new Image<Rgb24>(width, height); 
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                mirrorImage[x, y] = originalImage[width - 1 - x, y];
            }   
        }
        return mirrorImage;
    }
}