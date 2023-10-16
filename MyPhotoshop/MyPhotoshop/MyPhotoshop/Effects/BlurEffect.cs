using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class BlurEffect:IPhotoEffect
{
    private readonly string _description = "Difumina.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        var width = originalImage.Width;
        var height = originalImage.Height;
        var blurredImage = new Image<Rgb24>(width, height);
        
        int[,] boxBlurKernel = new int[,]
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };
        
        int kernelSum = 9;

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
                        rSum += pixel.R * boxBlurKernel[i + 1, j + 1];
                        gSum += pixel.G * boxBlurKernel[i + 1, j + 1];
                        bSum += pixel.B * boxBlurKernel[i + 1, j + 1];
                    }
                }
                blurredImage[x, y] = new Rgb24((byte)(rSum / kernelSum), (byte)(gSum / kernelSum), (byte)(bSum / kernelSum));
            }
        }

        return blurredImage;
    }  
}