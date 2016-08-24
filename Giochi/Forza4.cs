using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace comGUI {
    public partial class Forza4 : Form {
        public Forza4() {
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
        Bitmap im=new Bitmap(490,560);
        Graphics img;
        List<int>scheme=new List<int>();
        List<int>winning=new List<int>();
        Random rnd=new Random(Environment.TickCount);
        int oldpos=0,timerselect=-1;
        bool turn=false,start=false,iscolored=false;

        private void Forza4_Load(object sender, EventArgs e) {
            img=Graphics.FromImage(im);
            img.Clear(Color.Black);
            img.DrawRectangle(new Pen(Color.Cyan,1),0,70,489,418);
            for(int a=0;a<6;a++) {
                for(int b=0;b<7;b++) {
                    img.DrawArc(new Pen(Color.Cyan,3),new Rectangle(new Point(10+b*70,80+a*70),new Size(50,50)),0,360);
                }
            }
            img.DrawRectangle(new Pen(Color.Cyan,1),0,499,489,60);
            img.DrawString("Inizia",new Font("Microsoft Sans Serif",20F,FontStyle.Regular,GraphicsUnit.Point, 0),new SolidBrush(Color.Cyan),new Point(200,510));
            pictureBox1.Image=im;
            scheme = Enumerable.Repeat(0,42).ToList();
        }
        
        private void drawcolumn(int what,bool gray) {
            if(what!=-1) { 
            img=Graphics.FromImage(im);
            img.FillRectangle(new SolidBrush(gray?Color.Gray:Color.Black),1+what*70,71,68,417);
            bool changed=false;
            for(int a=0;a<6;a++) {
                img.DrawArc(new Pen(Color.Cyan,3),new Rectangle(new Point(10+what*70,80+a*70),new Size(50,50)),0,360);
                switch(scheme[what+a*7])
                    { case 0:timerselect=what+a*7;changed=true; break; 
                      case 1:img.FillPie(new SolidBrush(Color.Red),new Rectangle(new Point(10+what*70,80+a*70),new Size(50,50)),0,360);break; 
                      case 2:img.FillPie(new SolidBrush(Color.Yellow),new Rectangle(new Point(10+what*70,80+a*70),new Size(50,50)),0,360);break; }
                
            }
            if(!changed) {timerselect=-1; }
            pictureBox1.Image=im;}
        }
        void changecolumn(int ol,int ne) {
            drawcolumn(ol,false);
            drawcolumn(ne,true);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if(start) { 
            int pos=new Point(MousePosition.X-Location.X-21,MousePosition.Y-Location.Y-44).X/70;
            int y=new Point(MousePosition.X-Location.X-21,MousePosition.Y-Location.Y-44).Y/70;
            if(y>0&&y<7) { 
            if(pos!=oldpos) {changecolumn(oldpos,pos);oldpos=pos;}}else {timerselect=-1;drawcolumn(oldpos,false);oldpos=-1;  } }
        }
        
        Point getPoint(int x) {
            return new Point(10+(x%7)*70,80+(x/7)*70);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if(timerselect!=-1&&oldpos!=-1) {
                if(iscolored) {
                    img.FillPie(new SolidBrush(Color.Gray),new Rectangle(getPoint(timerselect),new Size(50,50)),0,360);
                    img.DrawArc(new Pen(Color.Cyan,3),new Rectangle(getPoint(timerselect),new Size(50,50)),0,360); }
                else {img.FillPie(new SolidBrush(turn?Color.Red:Color.Yellow),new Rectangle(getPoint(timerselect),new Size(50,50)),0,360); }
                iscolored=!iscolored;
                pictureBox1.Image=im;
            }
            
        }
        void writeTurn() {
            img.FillRectangle(new SolidBrush(Color.Black),0,0,200,69);
            Color c=turn?Color.Red:Color.Yellow;
            img.DrawString("Turno",new Font("Microsoft Sans Serif",20F,FontStyle.Regular,GraphicsUnit.Point, 0),new SolidBrush(c),new Point(10,15));
            img.FillPie(new SolidBrush(c),new Rectangle(new Point(100,0),new Size(50,50)),0,360);
        }
        void writeWon() {
            img.FillRectangle(new SolidBrush(Color.Black),201,0,300,69);
            Color c=turn?Color.Red:Color.Yellow;
            img.DrawString("Vince il "+(turn?"Rosso":"Giallo")+" !",new Font("Microsoft Sans Serif",20F,FontStyle.Regular,GraphicsUnit.Point, 0),new SolidBrush(c),new Point(275,15));
        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            if(start) { 
            if(timerselect!=-1) {
                scheme[timerselect]=turn?1:2;
                drawcolumn(timerselect%7,true);
                checkWin();
                if(winning.Count==4) {
                        timer2.Start();
                        start =false;writeWon();timerselect=-1;drawcolumn(oldpos,false);oldpos=-1;
                        img.DrawRectangle(new Pen(Color.Cyan,1),0,499,489,60);
                        img.DrawString("Restart",new Font("Microsoft Sans Serif",20F,FontStyle.Regular,GraphicsUnit.Point, 0),new SolidBrush(Color.Cyan),new Point(190,510));
                        return; };
                turn=!turn;
            } }else {
                if((MousePosition.Y-Location.Y-44)/70==7) {start=true;
                    img.FillRectangle(new SolidBrush(Color.Black),0,499,490,61);
                    scheme = Enumerable.Repeat(0,42).ToList();
                     turn=rnd.Next(2)==1;
                    timer2.Stop();
                    img.FillRectangle(new SolidBrush(Color.Black),new Rectangle(new Point(0,0),new Size(500,60)));
                    for(int a=0;a<7;a++) {drawcolumn(a,false); }
                    pictureBox1.Image=im;
                }
            }writeTurn();
        }
        bool chkwin(int n1,int n2,int n3,int n4,string comp) {
            string h=scheme[n1].ToString()+scheme[n2].ToString()+scheme[n3].ToString()+scheme[n4].ToString();
            return comp==h;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e) {
            timerselect=-1;drawcolumn(oldpos,false);oldpos=-1;
            
        }

        private void timer2_Tick(object sender, EventArgs e) {
            if(iscolored) {
                for(int a=0;a<4;a++) { 
                    img.FillPie(new SolidBrush(Color.Black),new Rectangle(getPoint(winning[a]),new Size(50,50)),0,360);
                    img.DrawArc(new Pen(Color.Cyan,3),new Rectangle(getPoint(winning[a]),new Size(50,50)),0,360); }}
                else {for(int a=0;a<4;a++) { img.FillPie(new SolidBrush(turn?Color.Red:Color.Yellow),new Rectangle(getPoint(winning[a]),new Size(50,50)),0,360); } }
                iscolored=!iscolored;
            pictureBox1.Image=im;
        }

        private void checkWin() {
            for(int a=0;a<4;a++) {
                for(int b=0;b<6;b++) {
                    int h=7*b+a;
                    if (chkwin(h,h+1,h+2,h+3,turn?"1111":"2222")) { winning= new List<int> {h,h+1,h+2,h+3};return; } }
            }
            for(int a=0;a<6;a++) {
                for(int b=0;b<3;b++) {
                    int h=7*b+a;
                    if (chkwin(h,h+7,h+14,h+21,turn?"1111":"2222")) {winning= new List<int> {h,h+7,h+14,h+21};return; } }
            }
            for(int a=3;a<7;a++) {
                for(int b=0;b<3;b++) {
                    int h=7*b+a;
                    if(chkwin(h,h+6,h+12,h+18,turn?"1111":"2222")) { winning= new List<int> {h,h+6,h+12,h+18};return; }
                }
            }
            for(int a=0;a<4;a++) {
                for(int b=0;b<3;b++) {
                    int h=7*b+a;
                    if(chkwin(h,h+8,h+16,h+24,turn?"1111":"2222")) { winning= new List<int> {h,h+8,h+16,h+24};return; }
                }
            }
           winning= new List<int>();
        }
    }
}
