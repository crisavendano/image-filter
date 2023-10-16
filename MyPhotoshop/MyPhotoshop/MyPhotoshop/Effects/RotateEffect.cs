using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class RotateEffect:IPhotoEffect
{
    private readonly string _description = "Rota 90° a la derecha.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        var width = originalImage.Width;
        var height = originalImage.Height;
        var rotatedImage = new Image<Rgb24>(width, height); 
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                rotatedImage[height - 1 - y, x] = originalImage[x, y];
            }   
        }
        return rotatedImage;
    }
}