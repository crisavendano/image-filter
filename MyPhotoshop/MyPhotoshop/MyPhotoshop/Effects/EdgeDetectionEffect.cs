using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class EdgeDetectionEffect:IPhotoEffect
{
    private readonly string _description = "Detecta los bordes.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        var width = originalImage.Width;
        var height = originalImage.Height;
        var edgeImage = new Image<Rgb24>(width, height);
        
        int[,] edgeDetectionKernel = new int[,]
        {
            { -1, -1, -1 },
            { -1, 8, -1 },
            { -1, -1, -1 }
        };
        
        int kernelSum = 1;

        for (var x = 1; x < width - 1; x++)
        {
            for (var y = 1; y < height - 1; y++)
            {
                int rSum = 0;
                int gSum = 0;
                int bSum = 0;

                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        var pixel = originalImage[x + i, y + j];
                        rSum += pixel.R * edgeDetectionKernel[i + 1, j + 1];
                        gSum += pixel.G * edgeDetectionKernel[i + 1, j + 1];
                        bSum += pixel.B * edgeDetectionKernel[i + 1, j + 1];
                    }
                }
                
                rSum = rSum < 0 ? 0 : rSum;
                gSum = gSum < 0 ? 0 : gSum;
                bSum = bSum < 0 ? 0 : bSum;
                
                rSum = rSum > 255 ? 255 : rSum;
                gSum = gSum > 255 ? 255 : gSum;
                bSum = bSum > 255 ? 255 : bSum;
                
                edgeImage[x, y] = new Rgb24((byte)(rSum / kernelSum), (byte)(gSum / kernelSum), (byte)(bSum / kernelSum));
            }
        }

        return edgeImage;
    }  
}