using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraMonitoring
{
    class Palette
    {
        public static ColorPalette MonoPalette => colorPalette;

        private static ColorPalette colorPalette = MakeMonoPalette();

        private static ColorPalette MakeMonoPalette()
        {
            using (Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                ColorPalette monoPalette = bmp.Palette;
                Color[] entries = monoPalette.Entries;

                for (int i = 0; i < 256; i++)
                    entries[i] = Color.FromArgb(i, i, i);

                return monoPalette;
            }
        }
    }
}
