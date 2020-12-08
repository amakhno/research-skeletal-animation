using OpenTK.Graphics.OpenGL4;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using OpenTK;
using System;

namespace Graphics
{
	public unsafe class Texture : Asset
	{
		public static Texture Blank = new Texture("", "", Util.Bitmap.CreateBlank(1, 1, Vector4.One));

		public string Name { get; private set; }
		public string File { get; private set; }

		private int id = -1;

		public Texture(string name, string file, Image<Rgba32> image)
		{
			Name = name;
			File = file;
			id = GL.GenTexture();

			GL.BindTexture(TextureTarget.Texture2D, id);

			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
			GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

			if (image.TryGetSinglePixelSpan(out var pixelSpan))
			{
				Rgba32[] pixelArray = pixelSpan.ToArray();
				fixed (Rgba32* pointer = &pixelArray[0])
				{
					GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba32f, image.Width, image.Height, 0,
							PixelFormat.Bgra, PixelType.UnsignedByte, (IntPtr)pointer);
				}
			}
		}

		public void Bind()
		{
			GL.BindTexture(TextureTarget.Texture2D, this.id);
		}
	}
}