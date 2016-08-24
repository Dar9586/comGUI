using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class Arkanoid : Form {
        public Arkanoid() {
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
        private List<Point>ballBorder(int what) {
            List<Point> x=new List<Point>();
            switch(what) {                                                                           //step prima                                        step attuale
                case 0:for(int a=0;a<7;a++){x.Add(new Point(data[2]+a+1-data[0]*2,data[3]-data[1]*2));  x.Add(new Point(data[2]+a+1-data[0],data[3]-data[1]));  x.Add(new Point(data[2]+a+1,data[3]));    } break;
                case 1:for(int a=0;a<7;a++){x.Add(new Point(data[2]-data[0]*2,data[3]+a+1-data[1]*2));  x.Add(new Point(data[2]-data[0],data[3]+a+1-data[1]));  x.Add(new Point(data[2],data[3]+a+1));    } break;
                case 2:for(int a=0;a<7;a++){x.Add(new Point(data[2]-data[0]*2+8,data[3]+a+1-data[1]*2));x.Add(new Point(data[2]-data[0]+8,data[3]+a+1-data[1]));x.Add(new Point(data[2]+8,data[3]+a+1));} break;
                case 3:for(int a=0;a<7;a++){x.Add(new Point(data[2]-data[0]*2+a+1,data[3]+8-data[1]*2));x.Add(new Point(data[2]-data[0]+a+1,data[3]+8-data[1]));x.Add(new Point(data[2]+a+1,data[3]+8));} break;
            }
            return x;
        }

        List<Point> pol=new List<Point>();
        void updatePol() {
            pol.Clear();
            for(int a=0;a<bri.Count;a++){
                if (bri[a].Col!=Color.Black) {
                    pol.AddRange(data[1]==3?bri[a].getUp():bri[a].getDown());
                    pol.AddRange(data[0]==3?bri[a].getLeft():bri[a].getRight());
                }
            }
        }

        void collide() {
            List<Point> bal=new List<Point>();
            bal.AddRange(ballBorder(data[0]==3?1:2));
            bal.AddRange(ballBorder(data[1]==3?0:3));
            for(int a=0;a<bal.Count;a++) {
                if (pol.Contains(bal[a])) {
                    int s=getnumList(bal[a]);
                    bri[s].Hit--;
                    if(bri[s].Hit==0) {bri[s].Col=Color.Black;bri[s].Draw(pictureBox1.Image);}
                    else if(bri[s].Hit==1) {bri[s].Col=Color.DarkGray;bri[s].Draw(pictureBox1.Image);}
                    if(bri[s].getDown().Contains(bal[a])) {data[1]*=-1;Console.WriteLine("Used Down"+(bri[s].getDown().IndexOf(bal[a]))); }
                    else if(bri[s].getUp().Contains(bal[a])) {data[1]*=-1;Console.WriteLine("Used Up"+(bri[s].getUp().IndexOf(bal[a]))); }
                    else if(bri[s].getLeft().Contains(bal[a])) {data[0]*=-1;Console.WriteLine("Used Left"+(bri[s].getLeft().IndexOf(bal[a]))); }
                    else if(bri[s].getRight().Contains(bal[a])) {data[0]*=-1;Console.WriteLine("Used Right"+(bri[s].getRight().IndexOf(bal[a]))); }
                    updatePol();
                    break;}
            }
            }
        int getnumList(Point x) {
            while((x.X-1)%51!=0) {x.X--; }
            while((x.Y-80)%16!=0) {x.Y--; }
            return ((x.X-1)/51)+((x.Y-80)/16*13);
        }
        Point getPoint(int x) {return new Point(51*(x%13)+1,16*(x/13)+80);}
        void bounce() {
            drawBall(data[2],data[3],true);
            if(data[2]<=0||data[2]>=655) {data[0]*=-1;updatePol();}
            if(data[3]>=546||data[3]<=0) {data[1]*=-1;updatePol();}
            data[2]+=data[0];
            data[3]+=data[1];
            //Console.WriteLine(new Point(data[2],data[3]));
            if (data[3]==516){int x=data[2];if(x+21>=pictureBox2.Location.X&&x+13<=pictureBox2.Location.X+80) {data[1]=-3;updatePol(); }}
            if(data[3]<=data[4]&&data[3]>=80) { collide(); }
            drawBall(data[2],data[3],false);
            
        }
        void drawBall(Point num,bool bla) {
            grap.FillPie(new SolidBrush(bla?Color.Black:Color.FromArgb(115,155,155)),new Rectangle(num,new Size(9,9)),0,360);
        }
        void drawBall(int numx,int numy,bool bla) {
            drawBall(new Point(numx,numy),bla);
        }
        List<int>data=new List<int>();
        //0=gravity x,1=gravity y,2=pos x,3=pos y,
        Graphics grap;
        Bitmap img;
        private void Arkanoid_Load(object sender, EventArgs e) {
            img=new Bitmap(80,15);
            grap=Graphics.FromImage(img);
            grap.Clear(Color.Coral);
            pictureBox2.Image=img;
            img=new Bitmap(664,554);
            grap=Graphics.FromImage(img);
            grap.Clear(Color.Black);
            pictureBox1.Image=img;
            data=new List<int>{rnd.Next(2)==0?3:-3,3,rnd.Next(464)+100,rnd.Next(43)*3+300,0};
        }
        Random rnd=new Random(Environment.TickCount);
        List<Bricks>bri=new List<Bricks>();
        List<Point>usable=new List<Point>();
        //                                0           1             2             3       4             5          6       7             8            9          10
        List<Color>col=new List<Color> {Color.Black,Color.White,Color.Orange,Color.Cyan,Color.Green,Color.Red,Color.Blue,Color.Purple,Color.Yellow,Color.Gray,Color.Gold};
        private void button1_Click(object sender, EventArgs e) {
            List<string>level=new List<string> {
                "999999999999955555555555558888888888888333333333333377777777777774444444444444",
                "001000000000000120000000000012300000000001234000000000123450000000012345600000001234567000000123456780000012345678100001234567812000123456781230012345678123409999999999995",
                "44444444444440000000000000111----------000000000000055555555555550000000000000----------111000000000000077777777777770000000000000666----------000000000000033333333333330000000000000----------333",
                "02349608123400349670123490049678023496009678103496700678120496780078123096781008123406781200123490781230023496081234003496701234900496780234960096781034967006781204967800781230967810",
                "00080000080000008000008000000080008000000008000800000009999999000000999999900000995999599000099599959900099999999999009999999999900999999999990090999999909009090000090900909000009090000099099000000009909900000",
                "6050403040506605040304050660504030405066050403040506605040304050660-2-2-2-2-0660504030405066050403040506605040304050660504030405062020-020-02026050403040506",
                "00000887000000000887760000000887766500000087766550000087766554400007766554430000766554433000066554433200006554433220000554433221000004433221000000433221100000003221100000000021100000",
                "000-0-0-0-0000-000000000-00--0-000-0--000000010000000-000-2-000-0000-00300-0000000004000000000-00500-0000-000-6-000-000000070000000--0-000-0--00-000000000-0000-0-0-0-000",
                "0-0-00000-0-00-4-00000-4-00-3-00000-3-00---00000---00000000000000000071118000000007222800000000733380000000074448000000007555800000000766680000",
    /*buggato*/ "0------------00000000000000-000000000000-000000000000-000000000000-000006000000-000063600000-000631360000-006316136000-063139313600-006316136000-000631360000-000063600000-000006000000-000000000000-000000000000-000000000000------------",
                "09999999999900900000000090090999999909009090000090900909099909090090909090909009090999090900909000009090090999999909009000000000900999999999990",
                "-------------0000-00000-700-10-00-00-000-00-40-00-000-02-00-06-000-00-00-00-000-00-00-00-000-00-05-00-000-00-00-00-000-30000-000000-00000-000080------------",
                "08880111088800777022207770066603330666005550444055500444055504440033306660333002220777022200111088801110",
                "6666666666666-00000000000-666666666666600000000000002999999999992-00000000000-111111111111100000000000003999999999993-00000000000-555555555555500000000000005555555555555-00000000000-",
                "31-3333333-13318-33333-4133188-333-441331888-1-4441331888814444133188881444413318888144441339888814444933398881444933333988144933333339814933333333391933333",
                "000000-0000000000110110000001100-0011001100220220011002200-0022002200880880022008800-0088008800440440088004400-0044004400550550044005500-0055005500660660055006600-0066006600000000066",
                "00000090000000006669444000006661114440000661111144000666111114440066611111444009009090900900000009000000000000900000000000090000000000-0-0000000000---00000000000-0000000",
                "20-8888888-0220--88888--0220-0-888-0-0220-07-8-30-0220-0709030-0220-0704030-0220-0704030-0220-0704030-0220-0704030-022---70403---2",
                "00---------00004567-765400004567-765400004567-7654000045678765400004567-765400004567-765400004567-76540000---------00",
                "-1-2-3-4-5-6--7-9-9-9-9-1-0000000000000-7-0-0-0-0-0--0-7-0-0-0-0--0-0-7-0-0-0--0-0-0-7-0-0--0-0-0-0-7-0-000000000007000-0-0-0-7-0000-0-0-7-0-0000-0-7-0-0-000007-0-0-0000070000-000000",
                "0-222222222-00-000000000-00-0-------0-00-0-00000-0-00-0-00000-0-00-0-05550-0-00-0-04440-0-00-0-06660-0-00-0-01110-0-00-0-00000-0-00-0-33333-0-00-000000000-00-000000000-00-----------0",
                "88888888888888888888888888000000000000055-0-555-0-5555-0-555-0-5555-0-555-0-5555-0-555-0-55000000000000011111111111111111111111111",
                "3333333333333000000000000000999099909990094909490949009990999099900000000000000999099909990095909590959009990999099900000000000000999099909990096909690969009990999099900",
                "000000000000000000111000000000011100000000001110000000001111100000000161610000000166166100000066666660000066666666600006666666660006666666666606666666666666",
                "555555555555544444444444446666666666666-----999------555-000-666--555-000-666--00000000000--00000000000--000-444-000--000-444-000--999-----999-",
                "00-999-0000000-00000-00000-0033300-0000-0444440-0000-0666660-0000-0077700-00000-00000-0000000-----000000",
                "0000000000000000000000000000000000000009999999999999888888888888899999999999990000000000000999999999999955555555555559999999999999",
                "66666666666666----7-7----66-000000000-66-700000007-66-770000077-66-777000777-606-7770777-60006-77777-6000006-777-600000006-7-6000000000676000000000006000000",
                "88888-0-8888877777-0-77777--1---0---1--66666-0-6666655555-0-5555544444-0-4444499199-0-9919933333-0-3333322222-0-2222211111-0-11111",
                "1700000000000176500000000017654300000001765432100000176543218700097654321876500-95432187654000-93218765400000-91876540000000-97654000000000-95400000000000-9",
                "40506070801029090909090909060504030201009090909090903060405070801909090909090907060504030200909090909090203040506070890909090909090807060504030090909090909010203040506079090909090909",
                "00-0-0-0-0-0000-0-0-0-0-0000-0-0-0-440000-0-0-0-0-0000-0-0-55550000-0-0-0-0-0000-0-6666660000-0-0-0-0-0000-777777770000-0-0-0-0-0000888888888000099999999900"
            };
            grap.Clear(Color.Black);
            int xo=0;
            try { xo=int.Parse(textBox1.Text); }catch(FormatException) {xo=level.Count-1; }
            bri.Clear();
            data[4]=textBox2.Text==""?level[xo].Length/13*16+75:textBox2.Text.Length/13*16;
            for(int a=0;a<(textBox2.Text==""?level[xo].Length/13:textBox2.Text.Length/13);a++) {
                for(int b=0;b<13;b++) {
                    bri.Add(new Bricks((textBox2.Text==""?level[xo]:textBox2.Text)[b+a*13]=='-'?Color.Gold:col[int.Parse((textBox2.Text==""?level[xo]:textBox2.Text)[b+a*13].ToString())],getPoint(b+a*13)));bri[b+a*13].Draw(img);}
            }
            updatePol();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            bounce();
            for(int a=0;a<bri.Count;a++) {if(bri[a].Col==Color.DarkGray||bri[a].Col==Color.Gray||bri[a].Col==Color.FromArgb(188,174,0))bri[a].Draw(pictureBox1.Image); }
            pictureBox1.Image=img;
        }
        private void Arkanoid_MouseMove(object sender, MouseEventArgs e) {
            int y=MousePosition.X-Location.X-61;
            if(y>597) {y=597; }
            else if(y<13) {y=13; }
            pictureBox2.Location=new Point(y,538);
        }

        private void button2_Click(object sender, EventArgs e) {
            bounce();pictureBox1.Image=img;
        }

        private void button3_Click(object sender, EventArgs e) {
            for(int a=0;a<pol.Count;a++) {Console.WriteLine(pol[a]); }
            
        }

        private void button4_Click(object sender, EventArgs e) {
            Console.WriteLine("Ball Point: "+new Point(data[2],data[3]));
        }

        private void button5_Click(object sender, EventArgs e) {
            timer1.Enabled=!timer1.Enabled;
        }
    }
    class Bricks {
        Size size=new Size(50,15);
        Point point=new Point(0,0);
        Color col=Color.Black;
        int hit=1;
        int score=0;
        public Bricks(Color c,Point p) {
            col=c;
            point=p;
            if(c==Color.Gray) {score=0;hit=2; }
            else if(c==Color.White) {score=50; }
            else if(c==Color.Orange) {score=60; }
            else if(c==Color.Cyan) {score=70; }
            else if(c==Color.Green) {score=80; }
            else if(c==Color.Red) {score=90; }
            else if(c==Color.Blue) {score=100; }
            else if(c==Color.Purple) {score=110; }
            else if(c==Color.Yellow) {col=Color.FromArgb(255,255,127); score=120; }
            else if(c==Color.Gold) {col=Color.FromArgb(188,174,0); score=0;hit=-1; }
            else { Console.WriteLine("Error"); }
        }
        public List<Point>getUp() {
            List<Point> x=new List<Point>();
            for(int a=0;a<50;a++) {x.Add(new Point(point.X+a,point.Y)); }
            return x;
        }
        public List<Point>getDown() {
            List<Point> x=new List<Point>();
            for(int a=0;a<50;a++) {x.Add(new Point(point.X+a,point.Y+15)); }
            return x;
        }
        public List<Point>getLeft() {
            List<Point> x=new List<Point>();
            for(int a=1;a<13;a++) {x.Add(new Point(point.X,point.Y+a)); }
            return x;
        }
        public List<Point>getRight() {
            List<Point> x=new List<Point>();
            for(int a=1;a<13;a++) {x.Add(new Point(point.X+50,point.Y+a)); }
            return x;
        }
        public void Draw(Image img) {
            Graphics g=Graphics.FromImage(img);
            g.FillRectangle(new SolidBrush(col),new Rectangle(point,size));
        }
        public int Hit {get {return hit; }set {hit=value; } }
        public int Score {get {return score; }set {score=value; } }
        public Color Col {get {return col; }set {col=value; } }
        public Point Location {get {return point; }set {point=value; } }
    }
}
