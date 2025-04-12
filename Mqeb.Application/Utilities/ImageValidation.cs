using System.IO;

namespace Mqeb.Application.Utilities
{
    public class ImageValidation
    {
        public static bool Validate(string imageName)
        {
            var extension = Path.GetExtension(imageName);
            if (imageName == null)
            {
                return false;
            }

            return extension.ToLower() == ".png" || extension.ToLower() == ".jpg";
        }
    }
}