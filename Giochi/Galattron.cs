using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace comGUI {
    public partial class Galattron : Form {
        public Galattron() {
            InitializeComponent();
        this.FormClosing += back;
        }
         void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
         Bitmap b;
         Graphics g;
         void Galattron_Load(object sender, EventArgs e) {
            b=new Bitmap(484,461);
            g=Graphics.FromImage(b);
            g.Clear(Color.Black);
            pictureBox1.Image=b;
        }
      
            
        

         void start_Click(object sender, EventArgs e) {
            listp.Clear();
            listw.Clear();
            g.Clear(Color.Black);
            g.DrawImage(Properties.Resources.InitChar,new Point(223,192));
            pictureBox1.Image=b;
            start.Visible=false;
            start.Text="Restart";
            timer1.Start();
            timer2.Start();
            star.Start();
            pos=0;
            poi=0;
        }
        int pos=0;
        SoundPlayer sou=new SoundPlayer(Properties.Resources.Sound);
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
	//capture left arrow key
    if (keyData == Keys.Left )
    {
                g.Clear(Color.Black);
                g.DrawImage(Properties.Resources.LChar,new Point(228,192));
                pos=1;
    }
	//capture right arrow key
    if (keyData == Keys.Right)
    {g.Clear(Color.Black);
                g.DrawImage(Properties.Resources.RChar,new Point(228,192));
                pos=2;
    }
    
    return true;
        }
        int poi=0;
         void timer1_Tick(object sender, EventArgs e) {
            g.Clear(Color.Black);
            g.FillRectangle(new SolidBrush(Color.DarkGreen),new Rectangle(0,215,492,100));
            for(int a=0;a<starp.Count;a++) {
                starp[a]=new Point(starp[a].X+1,starp[a].Y);
                g.FillRectangle(new SolidBrush(Color.LightYellow),new Rectangle(starp[a],new Size(3,3)));
                if(starp[a].X==492) {starp.RemoveAt(a);a--; }
            }
            if(pos==1) {g.DrawImage(Properties.Resources.LChar,new Point(223,192)); }                     
            else if(pos==2) {g.DrawImage(Properties.Resources.RChar,new Point(223,192)); }                     
            else if(pos==0) {g.DrawImage(Properties.Resources.InitChar,new Point(223,192)); } 
            for(int a=0;a<listw.Count;a++) {
                if(listw[a]) {
                    listp[a]=new Point(listp[a].X+2,listp[a].Y);
                     g.DrawImage(Properties.Resources.LEnemy,listp[a]);
                    if (listp[a].X>=205) {if(pos==1) {listw.RemoveAt(a);
                            sou.Play();
                            listp.RemoveAt(a);a--;poi++;} else {lose();} }
                }
                else {listp[a]=new Point(listp[a].X-2,listp[a].Y);
                    g.DrawImage(Properties.Resources.REnemy,listp[a]);
                    if (listp[a].X<=249) {if(pos==2) {listw.RemoveAt(a);
                            sou.Play();
                            listp.RemoveAt(a);a--;poi++;} else {lose();}}
                }
                }
            pictureBox1.Image=b;
        }

         void lose() {
            timer1.Stop();
            star.Stop();
            timer2.Stop();
            starp.Clear();
            start.Visible=true;
        }

        List<Point> listp=new List<Point>();
        List<bool> listw=new List<bool>();

         void pictureBox1_Click(object sender, EventArgs e) {
            Point mpos=MousePosition;
            Point wpos=Location;
            Point pos=new Point(mpos.X-wpos.X-20,mpos.Y-wpos.Y-43);
        }
        bool gene=true;
         void timer2_Tick(object sender, EventArgs e) {
            
            if(gene) { 
                int j=rnd.Next(3);
            if(j==1) {listp.Add(new Point(10,200));listw.Add(true);gene=false;}
            else if(j==0) {listp.Add(new Point(482,200));listw.Add(false);gene=false; }
            }else {gene=true; }
            label1.Text="Punteggio : "+poi.ToString();
        }
        Random rnd=new Random(Environment.TickCount);
        List<Point> starp=new List<Point>();
         void star_Tick(object sender, EventArgs e) {
            if(starp.Count<500) {
                starp.Add(new Point(rnd.Next(492),rnd.Next(200)));
            }
        }
    }
}
