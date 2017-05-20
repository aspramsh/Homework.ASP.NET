using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel;
using System.Globalization;

namespace NicePics.Models
{
    /// <summary>
    /// An image class for image objects in the server part
    /// </summary>
    public class Image
    {
        /// <summary>
        /// A string property for storing image name
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// A property for storing image converted to string
        /// </summary>
        public byte[] ImageData { get; set; }
    }
}