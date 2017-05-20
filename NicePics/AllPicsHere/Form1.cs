using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Drawing.Imaging;

namespace AllPicsHere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fS = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fS.Length];
            fS.Read(b, 0, (int)fS.Length);
            fS.Close();
            return b;
        }

        /// <summary>
        /// A method that adds clients photo to server's database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

            if (open.ShowDialog() == DialogResult.OK)

            {

                textBox1.Text = open.FileName;

            }

            Image image = new Image();

            image.ImageName = textBox2.Text;

            string path = textBox1.Text;
            image.ImageData = ImageToBinary(path);
            string commandUrl = textBox4.Text + image.ImageName;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(commandUrl);

            request.Method = "POST";
            request.ContentType = "multipart/form-data";
            request.ContentLength = image.ImageData.Length;
            using (Stream postStream = request.GetRequestStream())
            {
                // Send the data.
                postStream.Write(image.ImageData, 0, image.ImageData.Length);
                postStream.Close();
            }
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                MemoryStream memStr = new MemoryStream();
                var sr = new StreamReader(stream);
                var str = sr.ReadToEnd();

                textBox3.Text = str;
            }

        }
        /// <summary>
        /// A method that gets a photo for client from server's datastore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Image image = new Image();
            image.ImageName = textBox2.Text;
            string commandUrl = textBox5.Text + image.ImageName;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            string data = null;
            response = client.GetAsync(commandUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
        
                string imageData = data.Substring(1, data.Length - 2);
                System.Drawing.Image img = null;

                byte[] bitmapBytes = Convert.FromBase64String(imageData);

                using (MemoryStream memoryStream = new MemoryStream(bitmapBytes))

                {

                    img = System.Drawing.Image.FromStream(memoryStream);

                    pictureBox1.Image = img;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.Text = "http://localhost:63794/API/Image/AddImage?name=";
            textBox5.Text = "http://localhost:63794/API/Image/GetImage?ImageName=";
        }
    }
}
