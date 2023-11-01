using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    internal class Photo
    {
        public string ImagePath = @"D:\Basler Camera\Camera\pictures";

        private int PhotoButton = 0;

        public void PhotoImage(Image image)
        {
            if (image != null)
            {
                PhotoButton++;
                image.Save(ImagePath + "\\" + PhotoButton + "." + "Png");
            }
        }
    }
}
