using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicePics.Models
{
    /// <summary>
    /// A static class for keeping added photos and getting photos by name
    /// </summary>
    public static class Datastore
    {
        /// <summary>
        /// A list for keeping photos
        /// </summary>
        public static List<Image> Images = new List<Image>();
        /// <summary>
        /// A method for adding photos to the Images list
        /// </summary>
        /// <param name="image"></param>
        public static void AddImage(Image image)
        {
            Images.Add(image);
        }
        /// <summary>
        /// A method for getting a photo from images list
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public static Image GetImage(string imageName)
        {
            List<Image> list = Images.Where(a => a.ImageName.Equals(imageName)).ToList();
            if (Images.Count() > 0 && list.Count() > 0)
                return list[0];
            else
                return null;
        }
    }
}