using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comGUI {
    class Utility {
        public static Bitmap ResizeImage(Bitmap x, Size size) {
            Bitmap s = x;
            Bitmap o = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(o);
            g.DrawImage(s, 0, 0, size.Width, size.Height);
            return o;
        }
    }
}
