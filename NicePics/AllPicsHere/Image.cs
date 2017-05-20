using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace AllPicsHere
{
    /// <summary>
    /// A class for image objects in the client side
    /// </summary>
    public class Image
    {
        /// <summary>
        /// A property for keeping image name
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// A property for keeping image data
        /// </summary>
        public byte[] ImageData { get; set; }
    }
}
