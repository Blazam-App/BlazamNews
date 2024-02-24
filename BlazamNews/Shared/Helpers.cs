using Microsoft.AspNetCore.Components.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
namespace BlazamNews.Shared
{
    public static class Helpers
    {


        /// <summary>
        /// Resizes a raw byte array, assumed to be an image, to the maximum dimension provided
        /// </summary>
        /// <param name="rawImage"></param>
        /// <param name="maxDimension"></param>
        /// <param name="cropToSquare"></param>
        /// <returns></returns>
        public static byte[] ResizeRawImage(this byte[] rawImage, int maxDimension, bool cropToSquare = false)
        {
            using (var image = Image.Load(rawImage))
            {
                if (image.Height > image.Width)
                {
                    if (cropToSquare)
                        image.Mutate(x => x.Crop(image.Width, image.Width));
                    image.Mutate(x => x.Resize(0, maxDimension));

                }
                else
                {
                    if (cropToSquare)
                        image.Mutate(x => x.Crop(image.Height, image.Height));
                    image.Mutate(x => x.Resize(maxDimension, 0));
                }
                using (var ms = new MemoryStream())
                {
                    image.SaveAsPng(ms);
                    return ms.ToArray();
                }
            }
        }
        public static async Task<byte[]?> ToByteArrayAsync(this IBrowserFile file, int maxReadBytes = 5000000)
        {
            byte[] fileBytes;
            using (var stream = file.OpenReadStream(5000000))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
            }
            return fileBytes;
        }
    }
}
