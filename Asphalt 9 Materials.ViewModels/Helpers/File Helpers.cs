using System;
using System.IO;

namespace Asphalt_9_Materials.ViewModel.Helpers
{
    public static class FileHelpers
    {

        /// <summary>
        /// Getting file name without extension.
        /// </summary>
        /// <param name="imageName">Image name.</param>
        /// <returns>The Filename without extension</returns>
        public static string GetFilename(string imageName)
        {
            return IsImageExist(imageName) ? Path.GetFileNameWithoutExtension(ImagePath(imageName)) : null;
        }

        /// <summary>
        /// Gets the image path for the image.
        /// </summary>
        /// <param name="imageName">Image name</param>
        /// <returns>The Path of the car image.</returns>
        public static string ImagePath(string imageName)
        {
            return $"{ImagesPath}{imageName}.png";
        }

        /// <summary>
        /// Indicates whether the image is exist.
        /// </summary>
        /// <param name="imageName">Image name</param>
        /// <param name="pathProvidered">Is Path of the image has been provided?</param>
        /// <returns>Whether the image is exist</returns>
        public static bool IsImageExist(string imageName, bool pathProvidered = false)
        {
            return pathProvidered ? File.Exists(imageName) : File.Exists(ImagePath(imageName));
        }

        /// <summary>
        /// Images directory path.
        /// </summary>
        public static string ImagesPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Assets\Cars\");

        /// <summary>
        /// Json file path (Draft from update car page).
        /// </summary>
        public static string JsonFile => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"car.json");

    }
}
