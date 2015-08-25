using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class Snake : Form {
        public Snake() {
            InitializeComponent();
        this.FormClosing += back;
         Resize+=resi;
        }
        private void resi(object sender, EventArgs e) {
             if(Size.Width<250) {Size=new Size(250,Size.Height);}
           if(Size.Height<250) {Size=new Size(Size.Width,250);}
            Size ca1=new Size(Width-16,Height-39);
           pictureBox1.Size=ca1;
            Bitmap ca=b;
            b=new Bitmap(ca,ca1);
            g=Graphics.FromImage(b);
            pictureBox1.Image=b;
        }
        private void back(object sender, EventArgs e) {
            men.Show();this.Dispose();
        }
        public int size1=10,size2=10;
        public SnakeMenu men;
        Bitmap b;
        Graphics g;
        private void timer1_Tick(object sender, EventArgs e) {

        }

        private void Snake_Load(object sender, EventArgs e) {
            Size ca1=new Size(Width-16,Height-39);
            pictureBox1.Size=ca1;
            b=new Bitmap(ca1.Width,ca1.Height);
            g=Graphics.FromImage(b);
            g.Clear(Color.Black);
            g.DrawRectangle(new Pen(Color.Red,1),new Rectangle(new Point(50,50),new Size(20,20)));
            pictureBox1.Image=b;
        }
        int x=300,y=300;

        private void timer2_Tick(object sender, EventArgs e) {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    if (keyData == Keys.Up )
    {
       y--;
    }
    if (keyData == Keys.Down )
    {
       y++;
    }
    if (keyData == Keys.Left)
    {
        x--;
    }
    if (keyData == Keys.Right )
    {
        x++;
    }
    Size=new Size(x,y);
            Debug.WriteLine(Size.ToString());
    return base.ProcessCmdKey(ref msg, keyData);
}
        
    }
}
