using Basler.Pylon;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CameraMonitoring;
using System.ComponentModel;
using static System.Resources.ResXFileRef;
using System.Windows.Forms;
using FFMediaToolkit.Encoding;
using FFMediaToolkit.Graphics;
using FFMediaToolkit;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Camera;

namespace Camera
{
    internal class WebCamera
    {
        Form1 form1;

        private VideoCapture WebCamCamera { get; set; }
        OpenCvSharp.VideoWriter VideoWriter;
        private Mat Frame = new Mat();

        private int deviceNum { get; set; }

        private Thread CameraStreamingThread => new(StreamWeb);

        public Bitmap picture { get; set; }

        private bool Program = true;

        private bool OnOff = false;

        private bool Monitor = true;

        private bool Record = false;

        private int VideoNum = 0;

        public string VideoPath = @"D:\Basler Camera\Camera\Webvideos";

        public void Connect() => ConnectWeb();
        public void Disconnect() => DisconnectWeb();

        public WebCamera(Form1 form1)
        {
            this.form1 = form1;
        }

        private void ConnectWeb()
        {
            WebCamCamera = new VideoCapture(deviceNum);
            WebCamCamera.Open(deviceNum);

            if (WebCamCamera.IsOpened())
            {
                CameraStreamingThread.Start();
            }
        }

        private void StreamWeb()
        {
            int pictureonoff = 0;

            while (Program)
            {
                if (Monitor)
                {
                    if(pictureonoff != 0)
                    {
                        pictureonoff = 0;
                    }

                    try
                    {
                        if (Record == true && VideoWriter != null)
                        {
                            VideoWriter.Write(Frame);
                        }

                        WebCamCamera.Read(Frame);

                        picture?.Dispose();

                        picture = Frame.ToBitmap();

                        form1.Screen2(picture);

                        Thread.Sleep(50);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
                else
                {
                    if (pictureonoff == 0)
                    {
                        pictureonoff++;
                        form1.WebOff();
                    }
                }
            }
        }

        public void OnOffButton()
        {
            OnOff = !OnOff;
            if (OnOff)
            {
                Monitor = false;
            }
            else
            {
                Monitor = true;
            }
        }

        public void RecordButton()
        {
            Record = !Record;
            if (Record == true)
            {
                VideoNum++;
                VideoWriter = new OpenCvSharp.VideoWriter(VideoPath + "\\" + VideoNum + ".mp4", FourCC.XVID, 24, Frame.Size());
            }
            else
            {
                VideoWriter.Release();
            }
        }

        private void DisconnectWeb()
        {
            Program = false;
        }
    }
}