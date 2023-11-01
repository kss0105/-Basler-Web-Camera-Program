using Basler.Pylon;
using System.Diagnostics;
using System.Drawing.Imaging;
using CameraMonitoring;
using FFMediaToolkit;

namespace Camera
{
    internal class BaslerCamera
    {
        Form1 form1;

        SaveVideo video { get; set; }
        
        private readonly PixelDataConverter converter = new PixelDataConverter();

        private Basler.Pylon.Camera Camera { get; set; }

        Bitmap bitmap { get; set; }

        IGrabResult grabResult;

        private Image PictureBoxImage;

        private Image SaveImage;

        private bool OnOff = false;

        private bool Program = true;

        private bool Recording = false;

        private Thread GrabImageThread => new(StreamBasler);

        public string VideoPath = @"D:\Basler Camera\Camera\Baslervideos";

        public void Connect() => ConnectBasler();
        public void Disconnect() => DisconnectBasler();

        public BaslerCamera(Form1 form1)
        {
            this.form1 = form1;
        }

        private void ConnectBasler()
        {
            try
            {
                Camera = new Basler.Pylon.Camera();

                if (Camera.IsOpen)
                {
                    throw new InvalidOperationException();
                }

                if (!Camera.IsConnected)
                {
                    Camera.Open();
                    Console.WriteLine(Camera.IsConnected);
                    Camera.StreamGrabber.Start();
                    GrabImageThread.Start();
                }
            }
            catch
            {

            }
        }

        private void StreamBasler()
        {
            video = new SaveVideo();
            while (Program)
            {
                try
                {
                    if (Camera.IsConnected)
                    {
                        grabResult?.Dispose();
                        grabResult = Camera.StreamGrabber.RetrieveResult(200, TimeoutHandling.ThrowException);
                    }

                    if (grabResult != null && grabResult.GrabSucceeded)
                    {
                        bitmap?.Dispose();

                        GrabImageToBitmap();

                        if (Recording == true && video.videoFile == null)
                        {
                            video.MakeVideoFile(VideoPath);
                        }

                        if (Recording == true && video.videoFile != null)
                        {
                            video.AddFrame(bitmap);
                        }

                        PictureBoxImage?.Dispose();
                        SaveImage?.Dispose();

                        PictureBoxImage = (Image)bitmap.Clone();
                        SaveImage = (Image)bitmap.Clone();

                        form1.Screen1(PictureBoxImage);

                        Thread.Sleep(50);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        private void GrabImageToBitmap()
        {
            int width = grabResult.Width;
            int height = grabResult.Height;

            bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            converter.OutputPixelFormat = PixelType.Mono8;
            IntPtr bmpIntpr = bmpData.Scan0;
            converter.Convert(bmpIntpr, bmpData.Stride * bitmap.Height, grabResult);
            bitmap.UnlockBits(bmpData);

            bitmap.Palette = Palette.MonoPalette;
        }

        public void OnOffButton()
        {
            OnOff = !OnOff;

            if (OnOff && Camera.StreamGrabber.IsGrabbing)
            {
                Camera.StreamGrabber.Stop();
            }
            else 
            {
                Camera.StreamGrabber.Start();
            }
        }

        public void RecordButton()
        {
            Recording = !Recording;
            if (!Recording)
            {
                video.VideoFileDispose();
            }
        }

        private void DisconnectBasler()
        {
            Program = false;
        }
    }
}
