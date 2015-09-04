using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class SnakeSingle : Form {
        public SnakeSingle() {
            InitializeComponent();
            for(int a=0;a<9999;a++) {comGUI.Menu.rnd.Next(56465); }
        this.FormClosing += back;
        }

        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }

        private Rectangle r(int x1,int y1) {
            return new Rectangle(new Point(x1,y1),new Size(20,20));
        }
        
        private void SnakeSingle_Load(object sender, EventArgs e) {
            b=new Bitmap(484,461);
            g=Graphics.FromImage(b);
            g.Clear(Color.Black);
            pictureBox1.Image=b;
        }
        
        private List<Point> generate() {
            List<Point> s= new List<Point>();
            if(dire==1) {s.Add(new Point(x,y+20));s.Add(new Point(x+20,y+20));s.Add(new Point(x+10,y)); }
            if(dire==2) {s.Add(new Point(x+20,y));s.Add(new Point(x+20,y+20));s.Add(new Point(x,y+10)); }
            if(dire==3) {s.Add(new Point(x,y));s.Add(new Point(x,y+20));s.Add(new Point(x+20,y+10)); }
            if(dire==4) {s.Add(new Point(x,y));s.Add(new Point(x+20,y));s.Add(new Point(x+10,y+20)); }
            return s;
        }

        private void timer2_Tick(object sender, EventArgs e) {
            if(dire==1) {y-=20 ;}
            if(dire==2) {x-=20 ;}
            if(dire==3) {x+=20 ;}
            if(dire==4) {y+=20 ;}
            g=Graphics.FromImage(b);
            g.Clear(Color.Black);
            g.DrawPolygon(new Pen(Color.Orange,1),generate().ToArray());
            g.FillPolygon(new SolidBrush(Color.Orange),generate().ToArray());
            for(int a=0;a<posx.Count;a++) {
                g.DrawRectangle(new Pen(Color.Yellow,1),r(posx[a],posy[a]));
            g.FillRectangle(new SolidBrush(Color.Yellow),r(posx[a],posy[a]));
            }
            g.DrawRectangle(new Pen(Color.Red,1),r(fruit1,fruit2));
            g.FillRectangle(new SolidBrush(Color.Red),r(fruit1,fruit2));
            if(posx.Count==len) {
                posx.RemoveAt(0);
                posy.RemoveAt(0);
            }
            posx.Add(x);
            posy.Add(y);
            if(x==fruit1&&y==fruit2) {len++;spawn();Text="Score: "+(len-4).ToString(); }
            for(int a=0;a<posx.Count-1;a++) {if(posx[a]==x&&posy[a]==y) {lose(); } }
            if(x<0||x>460||y<0||y>440) {lose(); }
            pictureBox1.Image=b;
            changed=true;
        }

        private void spawn() {
            while(true) { 
                fruit1=comGUI.Menu.rnd.Next(24)*20;fruit2=comGUI.Menu.rnd.Next(23)*20;
                bool bre=true;
                for(int a=0;a<posx.Count-1;a++) {if(posx[a]==fruit1&&posy[a]==fruit2) {bre=false; } }
                if(bre) {break; }
                }
                g.DrawRectangle(new Pen(Color.Red,1),r(fruit1,fruit2));
                g.FillRectangle(new SolidBrush(Color.Red),r(fruit1,fruit2));
        }

        private void lose() {
            Text="Hai perso!  Clicca sulla schemata per rincominciare.        Score: "+(len-4).ToString();
            g.Clear(Color.Black);
            for(int a=0;a<posx.Count;a++) {g.DrawRectangle(new Pen(Color.Cyan,1),r(posx[a],posy[a]));
                g.FillRectangle(new SolidBrush(Color.Cyan),r(posx[a],posy[a])); }
            g.DrawRectangle(new Pen(Color.Blue,1),r(x,y));
                g.FillRectangle(new SolidBrush(Color.Blue),r(x,y));
            pictureBox1.Image=b;
            len=4;x=180;y=160;posx.Clear();posy.Clear();timer2.Stop();changed=false; }

        private void start() {
            if(!timer2.Enabled) {
                Text="Score: 0";
                 g.Clear(Color.Black);
                spawn();
            dire=comGUI.Menu.rnd.Next(4)+1;
                g.DrawRectangle(new Pen(Color.Orange,1),r(x,y));
            g.FillRectangle(new SolidBrush(Color.Orange),r(x,y));
            posx.Add(x);
            posy.Add(y);
                pictureBox1.Image=b;
                timer2.Start();}
            changed=true;
        }

        private void pictureBox1_Click(object sender, EventArgs e) {start();}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
    if (keyData == Keys.Up && changed)
    {
       if(dire==2||dire==3) {dire=1;changed=false; }
    }
    if (keyData == Keys.Down && changed)
    {
       if(dire==2||dire==3) {dire=4;changed=false; }
    }
    if (keyData == Keys.Left && changed)
    {
       if(dire==1||dire==4) {dire=2;changed=false; }
    }
    if (keyData == Keys.Right && changed)
    {
        if(dire==1||dire==4) {dire=3;changed=false; }
    }
    if (keyData == Keys.Enter && !timer2.Enabled)
    {
       start();
    }
    return true;
    }
        
        private Bitmap b;
        private Graphics g;
        
        private List<int> posx=new List<int>(),posy=new List<int>();
        private int x=180,y=160,len=4,dire=4,fruit1=0,fruit2=0;
        private bool changed=true;
    }
}
