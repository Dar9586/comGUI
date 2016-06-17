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
        PictureBox create(int x,Bitmap btm) {
            PictureBox x1=new PictureBox();
            x1.Image=btm;
            x1.Size=new Size(75,100);
            x1.BackColor=Color.White;
            x1.Location=new Point(x,0);
            panel1.Controls.Add(x1);
            return x1;
        }
        
         void button1_Click(object sender, EventArgs e) {
            //for(int a=0;a<40;a++) {create(80*a,lst[a].Image);}
            Cards s=new Cards(Properties.Resources.queenspades2,5);
            Console.WriteLine(s.Value);
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e) {
            panel1.HorizontalScroll.LargeChange=80;
            panel1.HorizontalScroll.SmallChange=80;
            //panel1.HorizontalScroll.Value+=80;
        }
    }
}
