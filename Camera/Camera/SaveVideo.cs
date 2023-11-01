using FFMediaToolkit.Encoding;
using FFMediaToolkit.Graphics;
using System.Drawing.Imaging;

namespace Camera
{
    internal class SaveVideo
    {
        public MediaOutput videoFile { get; set; }

        public string path { get; set; }

        public VideoEncoderSettings settings = new VideoEncoderSettings(
            width: 1280,
            height: 1024,
            framerate: 50,
            codec: VideoCodec.H264
        );

        private int VideoNum = 0;

        public void AddFrame(Bitmap bitmap)
        {
            var rect = new Rectangle(System.Drawing.Point.Empty, bitmap.Size);
            var bitLock = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            var bitmapData = ImageData.FromPointer(bitLock.Scan0, ImagePixelFormat.Gray8, bitmap.Size);
            bitmap.UnlockBits(bitLock);

            AddFrame(bitmapData);
        }

        public void AddFrame(ImageData imageData)
        {
            videoFile.Video.AddFrame(imageData);
        }

        public void VideoFileDispose()
        {
            if (videoFile != null)
            {
                var videoCopy = videoFile;
                videoFile = null;
                videoCopy.Dispose();
            }
        }

        public void MakeVideoFile(string videoPath)
        {
            SetVideoSaveFileNum(videoPath);
            videoFile = MediaBuilder.CreateContainer(path).WithVideo(settings).Create();
        }

        private void SetVideoSaveFileNum(string videoPath)
        {
            settings.EncoderPreset = EncoderPreset.UltraFast;
            settings.CRF = 17;
            settings.Framerate = 30;

            VideoNum++;

            string path = videoPath + "\\" + VideoNum + ".mp4";

            if (!File.Exists(path))
            {
                this.path = path;
                return;
            }
        }
    }
}
