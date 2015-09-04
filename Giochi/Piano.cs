using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class Piano : Form {
        public Piano() {
            InitializeComponent();
        this.FormClosing += back;
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        private Bitmap b;
        private Graphics g;
        private void Piano_Load(object sender, EventArgs e) {
            b=new Bitmap(200,250);
            g=Graphics.FromImage(b);
            g.Clear(Color.White);
            
        }

        private static Rectangle crea(int where,int hei) {
            return new Rectangle(where,hei,50,75);
        }

        private void adding() {
            listp.Add(new Point(comGUI.Menu.rnd.Next(4)*50,250));
            listb.Add(false);
        }

        List<Point> listp=new List<Point>();
        List<bool> listb=new List<bool>();
        private void grid(int start) {
            for(int a=0;a<8;a++) {g.DrawLine(new Pen(Color.Black,1),0,start,200,start);start+=74; }
            int h=50;
            for(int a=0;a<3;a++) {g.DrawLine(new Pen(Color.Black,1),h,0,h,250);h+=50; }
        }
        private void timer1_Tick(object sender, EventArgs e) {
           g.Clear(Color.White);
            grid(listp[0].Y);
            for(int a=0;a<listp.Count;a++) {
                if(listp[a].Y<=-75) {
                    if(!listb[a]) {lose();break; }
                    
                    listp.RemoveAt(a);listb.RemoveAt(a);
                }

                listp[a]=new Point(listp[a].X,listp[a].Y-2);
                Rectangle o=crea(listp[a].X,listp[a].Y+1);
                if(!listb[a]) { 
                g.DrawRectangle(new Pen(Color.Black,1),o);g.FillRectangle(new SolidBrush(Color.Black),o);}
                else {g.DrawRectangle(new Pen(Color.Gray,1),o);g.FillRectangle(new SolidBrush(Color.Gray),o); }
                
                
                if(listp[a].Y==174) {adding(); }
                pictureBox1.Image=b;
            }

            pictureBox1.Image=b;
        }
        int poi=0;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
           
	//capture up arrow key
    if (keyData == Keys.Up)
    {
         Cursor.Position=new Point(Cursor.Position.X,Cursor.Position.Y-1);
    }
	//capture down arrow key
    if (keyData == Keys.Down )
    {
         Cursor.Position=new Point(Cursor.Position.X,Cursor.Position.Y+1);
    }
	//capture left arrow key
    if (keyData == Keys.Left )
    {
            Cursor.Position=new Point(Cursor.Position.X-1,Cursor.Position.Y);
    }
	//capture right arrow key
    if (keyData == Keys.Right)
    {
      Cursor.Position=new Point(Cursor.Position.X+1,Cursor.Position.Y);
    }
    
    return base.ProcessCmdKey(ref msg, keyData);
        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            Point mpos=MousePosition;
            Point wpos=Location;
            Point pos=new Point(mpos.X-wpos.X-18,mpos.Y-wpos.Y-38);
            if(b.GetPixel(pos.X,pos.Y)==Color.FromArgb(255,0,0,0)) {
                bool ok=true;
                for(int a=0;a<listp.Count;a++) {if(crea(listp[a].X,listp[a].Y).Contains(pos)&&ok) 
                        {listb[a]=true;poi++;label1.Text="Punteggio : "+poi.ToString();}
                else {if(listb[a]==false) {ok=false; } }
                }
            }
            else if(b.GetPixel(pos.X,pos.Y)==Color.FromArgb(255,128,128,128)) {
                bool ok=true;
                for(int a=0;a<listp.Count;a++) {if(crea(listp[a].X,listp[a].Y).Contains(pos)&&ok) {listb[a]=true;}
                else {if(listb[a]==false) {ok=false; } }
                }
                
            }
            else {
                int x,y=250;
                x=pos.X-(pos.X%50);
                for(int a=0;a<listp.Count;a++) {
                    if(listp[a].Y> pos.Y) {y=(listp[a-1].Y+1);break; }
                }
                g.DrawRectangle(new Pen(Color.Red,1),crea(x,y));
                g.FillRectangle(new SolidBrush(Color.Red),crea(x,y));
                lo=b;
               lose();
            }
        }
        Bitmap lo;
        private void lose() {
            timer1.Stop();
            button1.Visible=true;
            listb.Clear();
            listp.Clear();
            pictureBox1.Image=lo;
            poi=0;
            button1.Text="Reset";
        }
        private void button1_Click(object sender, EventArgs e) {
            label1.Text="Punteggio : 0";
            g.Clear(Color.White);
            pictureBox1.Image=b;
          adding();timer1.Start();button1.Visible=false;
        }
    }
}
