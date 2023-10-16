using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class BrightenEffect:IPhotoEffect
{
    private readonly string _description = "Aclara.";
    
    public string Description
    {
        get { return _description; }
    }

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        var width = originalImage.Width;
        var height = originalImage.Height;
        var brightImage = new Image<Rgb24>(width, height); 
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var r = originalImage[x, y].R + 20 < 255 ? originalImage[x, y].R + 20 : 255;
                var g = originalImage[x, y].G + 20 < 255 ? originalImage[x, y].G + 20 : 255;
                var b = originalImage[x, y].B + 20 < 255 ? originalImage[x, y].B + 20 : 255;
                brightImage[x, y] = new Rgb24((Byte)r,(Byte)g,(Byte)b);
            }   
        }
        return brightImage;
    }
}