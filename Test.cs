﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class Test : Form {
        public Test() {
            InitializeComponent();
            Resize+=resi;
        }
        private void resi(object sender, EventArgs e) {
           if(Size.Width<250) {Size=new Size(250,Size.Height);}
           if(Size.Height<250) {Size=new Size(Size.Width,250);}
           Debug.WriteLine(Size.ToString());
        }
        static int x=50,y=50;

        Bitmap b;
        Graphics g;
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    if (keyData == Keys.Up )
    {
        if(y-1>=0) { y--;}
    }
    if (keyData == Keys.Down )
    {
       if(y+1<pictureBox1.Size.Height-20) { y++;}
    }
    if (keyData == Keys.Left)
    {
        if(x-1>=0) { x--;}
    }
    if (keyData == Keys.Right )
    {
        if(x+1<pictureBox1.Size.Width-20) { x++;}
    }
    
    return base.ProcessCmdKey(ref msg, keyData);
}
        Rectangle r;
        private void timer1_Tick(object sender, EventArgs e) {
            g.Clear(Color.Gray);
            List<Point> s=new List<Point>();
            s.Add(new Point(40,40));
            s.Add(new Point(60,40));
            s.Add(new Point(50,20));
            g.DrawPolygon(Pens.Red,s.ToArray());
            g.FillPolygon(new SolidBrush(Color.Black),s.ToArray());
            pictureBox1.Image=b;
            Debug.WriteLine(b.GetPixel(150,150).ToString());
    Debug.WriteLine(new Point(x,y).ToString()+"\n\n");
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }
        //private static RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
        private static Random rnd1=new Random(Environment.TickCount);
        private void button1_Click(object sender, EventArgs e) {
            /* byte[] buffer = new byte[4];
            rnd.GetBytes(buffer);
            textBox1.Text=buffer[0].ToString();*/
            textBox1.Text=rnd1.Next(50).ToString();
        }

        private void Test_Load(object sender, EventArgs e) {
            b=new Bitmap(pictureBox1.Size.Width,pictureBox1.Size.Width);
            g=Graphics.FromImage(b);
            
        }
    }
}
