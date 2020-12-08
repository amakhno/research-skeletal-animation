using System;
using System.IO;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;

namespace Graphics.Importers
{
    public class DefaultTextureImporter : AssetImporter
    {
        public Type AssetType { get; } = typeof(Texture);
        public string[] FileExtensions { get; } = new string[] { ".bmp", ".exif", ".tiff", ".png", ".gif", ".jpg", ".jpeg" };

        public void Import(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            string file = Path.GetFileName(path);
            var textureImage = Image.Load<Rgba32>(path);

            // The color is correct if you try to save the texture
            Assets.Register(new Texture(name, file, textureImage));
        }
    }
}