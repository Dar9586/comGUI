using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class Test : Form {
        public Test() {
            InitializeComponent();
            FormClosing += back;
        }
        void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }

         void button1_Click(object sender, EventArgs e) {
            int windowTop = Top; 
            int windowLeft = Left;
            Bitmap s=new Bitmap(306, 568);
            Graphics g=Graphics.FromImage(s);
            g.CopyFromScreen(new Point(Left+13+8,Top+13+31),new Point(0,0),new Size(306, 568));
            pictureBox2.Image=s;
            Bitmap s1=new Bitmap(pictureBox1.Image);
            Bitmap s2=new Bitmap(pictureBox2.Image);
            Console.WriteLine(compare(s1,s2));

        }
        private bool compare(Bitmap bmp1, Bitmap bmp2) 
{
    bool equals = true;
    bool flag = true;  //Inner loop isn't broken

    //Test to see if we have the same size of image
    if (bmp1.Size == bmp2.Size)
    {
        for (int x = 0; x < bmp1.Width; ++x)
        {
            for (int y = 0; y < bmp1.Height; ++y)
            {
                if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                {
                    equals = false;
                    flag = false;
                    break;
                }
            }
            if (!flag)
            {
                break;
            }
        }
    }
    else
    {
        equals = false;
    }
    return equals;
}
    }
}
