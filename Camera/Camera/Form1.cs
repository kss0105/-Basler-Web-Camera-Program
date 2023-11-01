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

namespace Camera
{
    public partial class Form1 : Form
    {
        BaslerCamera Basler { get; set; }
        WebCamera Web { get; set; }

        Photo photo = new Photo();

        public Form1() => InitializeComponent();

        private bool BaslerOnOff = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            unsafe
            {
                FFmpegLoader.FFmpegPath = @"D:\Basler Camera\Camera\Camera\bin\Debug\net6.0-windows";
            }

            Basler = new BaslerCamera(this);
            Web = new WebCamera(this);
            Basler.Connect();
            Web.Connect();
        }

        public void Screen1(Image PictureBoxImage)
        {
            var image = PictureBoxImage.Clone() as Image;
            var old = pictureBox1.Image;
            pictureBox1.Image = image;
            old?.Dispose();
        }

        public void Screen2(Image picture)
        {
            var image = picture.Clone() as Image;
            var old = pictureBox2.Image;
            pictureBox2.Image = image;
            old?.Dispose();
        }

        private void BaslerOnOffBtnClick(object sender, EventArgs e)
        {
            BaslerOnOff = !BaslerOnOff;
            Basler.OnOffButton();
            if (BaslerOnOff == true)
            {
                pictureBox1.Image = null;
            }

        }

        private void BaslerPhotoBtnClick(object sender, EventArgs e)
        {
            photo.PhotoImage(pictureBox1.Image);
        }

        private void BaslerRecordBtnClick(object sender, EventArgs e)
        {
            Basler.RecordButton();
        }

        private void WebOnOffBtnClick(object sender, EventArgs e)
        {
            Web.OnOffButton();
        }

        private void WebPhotoBtnClick(object sender, EventArgs e)
        {
            photo.PhotoImage(pictureBox2.Image);
        }

        private void WebRecordBtnClick(object sender, EventArgs e)
        {
            Web.RecordButton();
        }

        public void WebOff()
        {
            pictureBox2.Image = null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Basler.Disconnect();
            Web.Disconnect();
            Application.Exit();
            //주석처리되어 있는건 강제 종료 코드
            //Application.ExitThread();
            //Environment.Exit(0);
        }
    }
}