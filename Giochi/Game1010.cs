using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI
{
    public partial class Game1010 : Form
    {
        public Game1010()
        {
            InitializeComponent();
        FormClosing += back;
        }
         void back(object sender, EventArgs e) {
            Cursor.Show();
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        Bitmap im=new Bitmap(1000,600);
        Graphics img;
        List<Color>scheme=new List<Color>();
        List<Blocks>block=new List<Blocks>();
        Bitmap simpleImage=new Bitmap(1,1);
        Graphics simpleGrap;
        int selectedBlock=-2,score=0;
        Random rnd=new Random(Environment.TickCount);
        void drawBlock(Blocks j) {
            foreach(Point x in j.Points) {drawCube(x,j.Color); }
        }
        private void drawBlock(Blocks j, bool clean){
            foreach(Point x in j.Points) {drawCube(x,clean?Color.Black:j.Color); }
        }
        private void drawBlock(Blocks j, bool clean,Graphics g){
            Blocks s=new Blocks(0,0,j.Type);
            foreach(Point x in s.Points) {drawCube(x,clean?Color.Black:j.Color,g); }
        }
        void drawCube(Point x,Color y) {
            img.FillRectangle(new SolidBrush(y),new Rectangle(x,new Size(50,50)));
            pictureBox1.Image=im;
        }
        void drawCube(Point x,Color y,Graphics g) {
            g.FillRectangle(new SolidBrush(y),new Rectangle(x,new Size(50,50)));
            pictureBox1.Image=im;
        }

        void drawScheme()
        {
            for(int a=0;a<10;a++) {
                for(int b=0;b<10;b++) {
                    drawCube(new Point(10+a*52,10+b*52),scheme[b*10+a]);
                }
                
            }
            pictureBox1.Image=im;
        }
        void drawButton(bool isStart)
        {
            selectedBlock=isStart?-2:-3;
            img.DrawRectangle(new Pen(isStart?Color.Cyan:Color.Red,1),10,530,518,68);
            img.DrawString(isStart?"Inizia":"Restart",new Font("Microsoft Sans Serif",20F,FontStyle.Regular,GraphicsUnit.Point, 0),new SolidBrush(isStart?Color.Cyan:Color.Red),new Point(230,540));
            pictureBox1.Image=im;

        }
        private void Game1010_Load(object sender, EventArgs e)
        {
            img=Graphics.FromImage(im);
            img.Clear(Color.Black);
            simpleGrap=Graphics.FromImage(simpleImage);
            scheme = Enumerable.Repeat(Color.Gray,100).ToList();
            drawScheme();
            updateScore();
            drawButton(true);
        }
        class Blocks{
            Point _loc;
            Size _size;
            Color _col=Color.Red;
            List<Point>_points;
            List<Color>_colList=new List<Color> {
                Color.PaleVioletRed,
                Color.Lime,
                Color.Aqua,
                Color.Yellow,
                Color.Yellow,
                Color.Orange,
                Color.Orange,
                Color.Pink,
                Color.Pink,
                Color.OrangeRed,
                Color.OrangeRed,
                Color.LightSkyBlue,
                Color.LightSkyBlue,
                Color.LightSkyBlue,
                Color.LightSkyBlue,
                Color.LightGreen,
                Color.LightGreen,
                Color.LightGreen,
                Color.LightGreen
            };
            int _type;
            public Blocks(int x,int y,int type):this(new Point(x,y),type) { }
            public Blocks(Point loc,int type){
                _loc=loc;
                _col=_colList[type];
                _type=type;
                setPoints();
            }
            void setPoints()
            {
                switch(_type)
                {
                    case  0:_points=new List<Point>{new Point(_loc.X,_loc.Y)};_size=new Size(1,1);break;
                    case  1:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X+1*52,_loc.Y+52*1)};_size=new Size(2,2);break;
                    case  2:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X+1*52,_loc.Y+52*1),new Point(_loc.X+2*52,_loc.Y+52*1),new Point(_loc.X,_loc.Y+52*2),new Point(_loc.X+1*52,_loc.Y+52*2),new Point(_loc.X+2*52,_loc.Y+52*2)};_size=new Size(3,3);break;
                    case  3:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X,_loc.Y+52*1)};_size=new Size(1,2);break;
                    case  4:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y)};_size=new Size(2,1);break;
                    case  5:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X,_loc.Y+52*2)};_size=new Size(1,3);break;
                    case  6:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y)};_size=new Size(3,1);break;
                    case  7:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X,_loc.Y+52*2),new Point(_loc.X,_loc.Y+52*3)};_size=new Size(1,4);break;
                    case  8:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y),new Point(_loc.X+3*52,_loc.Y)};_size=new Size(4,1);break;
                    case  9:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X,_loc.Y+52*2),new Point(_loc.X,_loc.Y+52*3),new Point(_loc.X,_loc.Y+52*4)};_size=new Size(1,5);break;
                    case 10:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y),new Point(_loc.X+3*52,_loc.Y),new Point(_loc.X+4*52,_loc.Y)};_size=new Size(5,1);break;
                    case 11:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X,_loc.Y+52*2)};_size=new Size(3,3);break;
                    case 12:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X,_loc.Y+52*2),new Point(_loc.X+1*52,_loc.Y+52*2),new Point(_loc.X+2*52,_loc.Y+52*2)};_size=new Size(3,3);break;
                    case 13:_points=new List<Point>{new Point(_loc.X+2*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y+52*1),new Point(_loc.X,_loc.Y+52*2),new Point(_loc.X+1*52,_loc.Y+52*2),new Point(_loc.X+2*52,_loc.Y+52*2)};_size=new Size(3,3);break;
                    case 14:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y),new Point(_loc.X+2*52,_loc.Y+52*1),new Point(_loc.X+2*52,_loc.Y+52*2)};_size=new Size(3,3);break;
                    case 15:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X,_loc.Y+52*1)};_size=new Size(2,2);break;
                    case 16:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X+1*52,_loc.Y+52*1)};_size=new Size(2,2);break;
                    case 17:_points=new List<Point>{new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X,_loc.Y+52*1),new Point(_loc.X+1*52,_loc.Y+52*1)};_size=new Size(2,2);break;
                    case 18:_points=new List<Point>{new Point(_loc.X,_loc.Y),new Point(_loc.X+1*52,_loc.Y),new Point(_loc.X+1*52,_loc.Y+52*1)};_size=new Size(2,2);break;
                    default:throw new ArgumentException(_type.ToString()+" is not valid");
                }
            }
            public List<int> getPoint(int index,bool isGrid8){
                List<int>v=new List<int>();
                if(_points.Contains(new Point(_loc.X+52*0,_loc.Y+52*0))){v.Add(index+(isGrid8?0 :0));}
                if(_points.Contains(new Point(_loc.X+52*1,_loc.Y+52*0))){v.Add(index+(isGrid8?1 :1));}
                if(_points.Contains(new Point(_loc.X+52*2,_loc.Y+52*0))){v.Add(index+(isGrid8?2 :2));}
                if(_points.Contains(new Point(_loc.X+52*3,_loc.Y+52*0))){v.Add(index+(isGrid8?3 :3));}
                if(_points.Contains(new Point(_loc.X+52*4,_loc.Y+52*0))){v.Add(index+(isGrid8?4 :4));return v;}
                if(_points.Contains(new Point(_loc.X+52*0,_loc.Y+52*1))){v.Add(index+(isGrid8?8 :10));}
                if(_points.Contains(new Point(_loc.X+52*1,_loc.Y+52*1))){v.Add(index+(isGrid8?9:11));}
                if(_points.Contains(new Point(_loc.X+52*2,_loc.Y+52*1))){v.Add(index+(isGrid8?10:12));}
                if(_points.Contains(new Point(_loc.X+52*0,_loc.Y+52*2))){v.Add(index+(isGrid8?16:20));}
                if(_points.Contains(new Point(_loc.X+52*1,_loc.Y+52*2))){v.Add(index+(isGrid8?17:21));}
                if(_points.Contains(new Point(_loc.X+52*2,_loc.Y+52*2))){v.Add(index+(isGrid8?18:22));}
                if(_points.Contains(new Point(_loc.X+52*0,_loc.Y+52*3))){v.Add(index+(isGrid8?24:30));}
                if(_points.Contains(new Point(_loc.X+52*0,_loc.Y+52*4))){v.Add(index+(isGrid8?32:40));}
                return v;
            }
            public Size getSize(bool effectiveSize)
            { if(effectiveSize) {return new Size((_size.Width-1)*52+50,(_size.Height-1)*52+50); }return _size;}
            public Rectangle getRectangle() {return new Rectangle(_loc,getSize(true)); }
            public Point Location {get {return _loc; }}
            public int Type {get {return _type; }}
            public Color Color {get {return _col; }set {_col=value; } }
            public List<Point> Points{get {return _points; }set {_points=value; }}
        }
        Point posizionGrid(int g){return new Point(582+((g%8)*52),10+(g/8)*52);}
        List<bool>updateUsable(List<bool>usable,Blocks x,int y){
            foreach(int z in x.getPoint(y,true)){usable[z]=false;}
            List<bool>g=new List<bool>(usable);
            for(int a=0;a<80;a++)
            {
                if(!usable[a]) { 
                if(a>7) {
                    g[a-8]=false;
                    if(a%8!=0) {g[a-9]=false; }
                    if((a+1)%8!=0) {g[a-7]=false; }
                }
                if(a<71) {
                    g[a+8]=false;
                    if(a%8!=0) {g[a+7]=false; }
                    if((a+1)%8!=0) {g[a+9]=false; }
                }
                if(a%8!=0) {g[a-1]=false; }
                if((a+1)%8!=0) {g[a+1]=false; }
                }
            }

            return g;
        }
        int getIndex(List<bool>usable,Blocks x){
            int w=8-x.getSize(false).Width;
            int h=10-x.getSize(false).Height;
            List<int>m1=new List<int>();
            List<int>m2=new List<int>();
            for(int a=0;a<h;a++) {for(int b=0;b<w;b++) {m1.Add(a*8+b); } }
            while(m1.Count>0) {int j=m1[rnd.Next(m1.Count)]; m2.Add(j);m1.Remove(j); }
            for(int a=0;a<m2.Count;a++) {
                    int n=m2[a];
                    bool ok=true;
                    foreach(int l in x.getPoint(n,true)) {if(!usable[l]) {ok=false;break; } }
                    if(ok) {return n; }
                } 

            return -1;
        }
        void refillBlock() {
            selectedBlock=-1;
            img.FillRectangle(new SolidBrush(Color.Black),new Rectangle(530,0,470,530));
            List<Blocks>k=new List<Blocks>();
            List<bool>usable=new List<bool>(Enumerable.Repeat(true,80).ToList());
            for (int a=0;a<3;a++)
            {
                int j=rnd.Next(19),p=-1;
                k.Add(new Blocks(posizionGrid(0),j));
                p=getIndex(usable,k[a]);
                while(p==-1) {j=rnd.Next(19);k[a]=new Blocks(posizionGrid(p),j); p=getIndex(usable,k[a]); }
                k[a]=new Blocks(posizionGrid(p),j);
                usable=updateUsable(usable,k[a],p);
            }
            block=k;
            foreach(Blocks x in block) {drawBlock(x); }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left) {
                if(selectedBlock<-1) { 
                if(new Rectangle(10,530,520,70).Contains(pictureBox1.PointToClient(Cursor.Position))) {
                        img.FillRectangle(Brushes.Black,new Rectangle(10,530,520,70));
                        if (selectedBlock==-3) {
                        score=0;
                        block.Clear();
                        img.Clear(Color.Black);
                        scheme = Enumerable.Repeat(Color.Gray,100).ToList();
                        drawScheme();
                            updateScore();
                    }
                    refillBlock();return;
                }
                }
                else { 
                int n=-1;
                foreach(Blocks x in block) {if(x.getRectangle().Contains(pictureBox1.PointToClient(Cursor.Position))){drawBlock(x);n=block.IndexOf(x);} }
                if (n!=-1)
                {
                    selectedBlock=n;
                    Cursor.Position=pictureBox1.PointToScreen(block[n].Location);
                    Cursor.Hide();
                    pb.Size = block[n].getSize(true);
                    drawBlock(block[n],true);
                    simpleImage=new Bitmap(block[n].getSize(true).Width,block[n].getSize(true).Height);
                    UpdatePb();
                }
                }
            }
        }

        void UpdatePb()
        {
            pb.Show();
            pb.Location=pictureBox1.PointToClient(Cursor.Position);
            simpleGrap=Graphics.FromImage(simpleImage);
            Point p=pictureBox1.PointToClient(Cursor.Position);
            if(p.X>-1&&p.X<1000&&p.Y>-1&&p.Y<600) { 
            Size s=block[selectedBlock].getSize(true);
            int lx=p.X+s.Width,ly=p.Y+s.Height;
            int flx=s.Width,fly=s.Height;
            if(lx>1000) {flx-=(lx-1000); }
            if (ly>600) {fly-=(ly-600); }
            try { simpleGrap.DrawImage(im.Clone(new Rectangle(p,new Size(flx,fly)),im.PixelFormat),new Point(0,0)); }catch {pb.Hide(); }
                }else { pb.Hide();}
                drawBlock(block[selectedBlock],false,simpleGrap);
            pb.Image=simpleImage;
        }
        private void pb_Mouse(object sender, EventArgs e)
        {
            if(selectedBlock>-1)UpdatePb();
        }
        int getPoint()
        {
            int x=pictureBox1.PointToClient(Cursor.Position).X/52;
            int y=pictureBox1.PointToClient(Cursor.Position).Y/52;
            return y*10+x;
        }
        bool placeAt(int index) {
            foreach(int l in block[selectedBlock].getPoint(index,false)) {try { if(scheme[l]!=Color.Gray)return false;}catch(ArgumentOutOfRangeException) {return false; }  }
            score+=block[selectedBlock].Points.Count;
            foreach(int l in block[selectedBlock].getPoint(index,false)) {drawCube(new Point(((l%10)*52)+10,((l/10)*52)+10),block[selectedBlock].Color);scheme[l]=block[selectedBlock].Color; }
            return true;
        }
        bool tryPlaceAt(int index,int what) {
            foreach(int l in block[what].getPoint(index,false)) {if(scheme[l]!=Color.Gray)return false; }
            return true;
        }
        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left) {
                if(pictureBox1.PointToClient(Cursor.Position).X<(555-block[selectedBlock].getSize(true).Width)) {
                    if(placeAt(getPoint())) {
                        block.RemoveAt(selectedBlock);pb.Hide();selectedBlock=-1;
                        updateScheme();
                        updateScore();
                        Cursor.Show(); if(block.Count==0) {refillBlock(); }
                        if(!tryPosition()) {drawButton(false); }
                    }
                }
            }
            else {
                pb.Hide();
                drawBlock(block[selectedBlock]);
                selectedBlock=-1;
                Cursor.Show();
            }
        }

        private void updateScore() {
            img.FillRectangle(Brushes.Black,new Rectangle(550,530,450,70));
            img.DrawString("Punteggio: "+score.ToString(),new Font("arial",20),Brushes.Cyan,550,530);
        }

        bool tryPosition() {
            for(int a=0;a<block.Count;a++) {
                int w=10-block[a].getSize(false).Width,h=10-block[a].getSize(false).Height;
                for(int b=0;b<h;b++) {for(int c=0;c<w;c++) {if(tryPlaceAt(b*10+c,a)) {selectedBlock=-1;return true; } } }
            }
            return false;
        }
        private void updateScheme() {
            List<Color>copy=new List<Color>(scheme);
            for(int a=0;a<10;a++) {
                if(!scheme.GetRange(a*10,10).Contains(Color.Gray)) {
                    for(int b=0;b<10;b++) {copy[a*10+b]=Color.Gray; }
                    score+=10;
                }
            }
            for(int b=0;b<10;b++) {
                bool ok=true;
                for(int a=0;a<10;a++) {
                    if(scheme[a*10+b]==Color.Gray) {ok=false;break; }
                }
                if(ok) {for(int a=0;a<10;a++) {
                    copy[a*10+b]=Color.Gray;score+=10;
                } }
            }
            scheme=new List<Color>(copy);
            drawScheme();
        }
    }
    
    
}