using OpenTK;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Graphics.Util
{
    public static class Bitmap
    {
        public static Image<Rgba32> CreateBlank(int width, int height, Vector4 color)
        {
            Image<Rgba32> bmp = new Image<Rgba32>(1, 1);
            Color c = new Color(new Rgba32(new System.Numerics.Vector4(color.X, color.Y, color.Z, color.W)));
            bmp[0, 0] = c;
            return bmp;
        }
    }
}