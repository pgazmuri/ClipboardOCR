﻿using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardOCR
{
    public partial class Form1 : Form
    {
        private string key = "<key>";
        private string endpoint = "<endpoint url>";

        public Form1()
        {
            InitializeComponent();
            ClipboardNotification.ClipboardUpdate += ClipboardNotification_ClipboardUpdate;
        }

        private void ClipboardNotification_ClipboardUpdate(object sender, EventArgs e)
        {

            try
            {
                //check clipboard for image
                if (Clipboard.ContainsImage())
                {
                    var image = Clipboard.GetImage();
                    image = EnsureImageSize(image);
                    //send to ocr
                    var cli = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
                    //var task = cli.RecognizeTextInStreamAsync(image.ToStream(ImageFormat.Png), Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.TextRecognitionMode.Handwritten);
                    var task = cli.RecognizePrintedTextInStreamAsync(false, image.ToStream(ImageFormat.Png));
                    task.Wait();
                    //dump text to form
                    StringBuilder sb = new StringBuilder();

                    task.Result.Regions.ToList().ForEach(r => r.Lines.ToList().ForEach(l =>
                    {
                        l.Words.ToList().ForEach(w => sb.Append(w.Text + " "));
                        if (cbRetainNewlines.Checked)
                        {
                            _ = sb.AppendLine();
                        }
                    }));
                    tbResults.Text = sb.ToString().Replace(" \n", "\n");
                    if (cbAutoCopy.Checked)
                    {
                        if (tbResults.Text.Length > 0)
                        {
                            Clipboard.SetText(tbResults.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tbResults.Text = $"Error: {ex}";
            }
        }

        private static Image EnsureImageSize(Image image)
        {
            if (image.Width < 50 || image.Height < 50)
            {
                var newWidth = (image.Width > 50) ? image.Width : 50;
                var newHeight = (image.Height > 50) ? image.Height : 50;
                var newImage = new Bitmap(newWidth, newHeight);
                using (var grphx = Graphics.FromImage(newImage))
                {
                    grphx.DrawImage(image, new Point(0, 0));
                    grphx.Flush();
                }
                image = newImage;

            }

            return image;
        }

    }

    static class Extensions
    {
        public static Stream ToStream(this Image image, ImageFormat format)
        {
            var stream = new System.IO.MemoryStream();
            ImageCodecInfo pngEncoder = GetEncoder(ImageFormat.Png);

            // Create an Encoder object based on the GUID  
            // for the Quality parameter category.  
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.  
            // An EncoderParameters object has an array of EncoderParameter  
            // objects. In this case, there is only one  
            // EncoderParameter object in the array.  
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            image.Save(stream, pngEncoder, myEncoderParameters);
            stream.Position = 0;
            return stream;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
