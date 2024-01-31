using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Threading;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using AForge.Video;
using AForge.Video.DirectShow;

namespace BTE_RM
{
   
    class Upload_OMR
    {
   
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;

      public  Image pic1;
      public   Image pic2;
        bool tr = false;
        Graphics imageprocessing;
        Bitmap myimage;
        Bitmap mainimage;
        Bitmap imagesize;
        #region omrcheak
        public void cameraActive()
        {
            videoDevice = new VideoCaptureDevice(videoDevices[BTERM.getBTER.CameracomboBox.SelectedIndex].MonikerString);
            videoDevice.NewFrame += new NewFrameEventHandler(VideoDevice_NewFrame);
            //  tr = true;
            videoDevice.Start();

        }

        private void VideoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pic1 = (Bitmap)eventArgs.Frame.Clone();
                pic2 = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception)
            {

            }
        }


        public void imagecheck()
        {


            try
            {
                mainimage = new Bitmap(pic1);
                imagesize = new Bitmap(80, 80);

                imageprocessing = Graphics.FromImage(imagesize);

                image();
             BTERM.getBTER.pictureBoxbarcodechaker2.Image = imagesize;

            }
            catch (Exception)
            {

            }
        }



        private void image()
        {
            try
            {


                for (int Imageheight = 0; Imageheight < 80; Imageheight++)
                {

                    for (int Imagewidgh = 20; Imagewidgh < 100; Imagewidgh++)
                    {
                        int pic = Imagewidgh - 20;

                        Color mainpixColor = mainimage.GetPixel(Imagewidgh, Imageheight);

                        imagesize.SetPixel(pic, Imageheight, mainpixColor);
                    }

                }
            }
            catch (Exception)
            {

            }
        }
        public void initcamera()
        {
            
            try
            {

                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                foreach (FilterInfo device in videoDevices)
                {
                  BTERM.getBTER.CameracomboBox.Items.Add(device.Name);
                }
                BTERM.getBTER.CameracomboBox.SelectedIndex = 0;
            }
           catch (Exception)
            {
                BTERM.getBTER.CameracomboBox.Items.Add("No device!!");
            }
        }

     public void timer_cheek()
        {
            BarcodeReader barread = new BarcodeReader();
            BTERM.getBTER.pictureBoxbarcodechaker.Image = pic1;

            imagecheck();

            if (BTERM.getBTER.pictureBoxbarcodechaker2.Image != null)
            {

                Result res = barread.Decode((Bitmap)BTERM.getBTER.pictureBoxbarcodechaker2.Image);

                try
                {
                    string result = res.ToString().Trim();
                    if (result != null)
                    {
                        BTERM.getBTER.lablfari.Text = result;
                        videoDevice.Stop();
                        BTERM.getBTER.timer1.Stop();

                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public void stopcamera()
        {
            try
            {
                if (videoDevice.IsRunning)
                {
                    videoDevice.Stop();
                }
            }
           catch(Exception)
            { }
        }


        #endregion omrcheakchar
    }
}
