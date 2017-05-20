using NicePics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace NicePics.Controllers
{
    /// <summary>
    /// Controller class
    /// </summary>
    public class ImageController : ApiController
    {
        /// <summary>
        /// A function that gets an image provided it's name
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns></returns>
        [Route("api/Image/GetImage")]
        [HttpGet]
        public byte[] GetImage(string imageName)
        {
            Image image = Datastore.GetImage(imageName);
            if (image != null)
                return image.ImageData;
            else return null;
        }
        /// <summary>
        /// A function that adds an image to the database
        /// </summary>
        /// <returns></returns>
        [Route("api/Image/AddImage")]
        [HttpPost]
        public string AddImage(string name)
        {

            Task<byte[]> task = this.Request.Content.ReadAsByteArrayAsync();

            task.Wait();

            byte[] byteArray = task.Result;

            Image image = new Image();
            image.ImageName = name;
            image.ImageData = byteArray;

            Datastore.AddImage(image);

            return image.ImageName + " is added.";
        }
    }
}
