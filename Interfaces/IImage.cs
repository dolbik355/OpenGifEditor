using System.Drawing;

namespace OpenGifImage
{
    internal interface IImage
    {
        int Width { get; }
        int Height { get; }

        void Save(string path);
        void Crop(Rectangle rect);
    }
}