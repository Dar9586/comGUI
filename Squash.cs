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
    public partial class Squash : Form {
        public Squash() {
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
         Random rnd=new Random(Environment.TickCount);
         Bitmap grap=new Bitmap(750,500);
         Graphics image;
         static List<object>data=new List<object>();
        //0=position1(int), 1=position2(int), 2=blocked(bool),3=gravityX(int),4=gravityY(int),5=imageBackup(Bitmap),6=positionBallX(int),7=positionBally(int),8=point(int)
         void Squash_Load(object sender, EventArgs e) {
            data.Clear();data=new List<object> {50,100,false,1,1,new Bitmap(1,1),100,rnd.Next(20,280),0};
            image=Graphics.FromImage(grap);
            image.Clear(Color.Black);
            image.DrawImage(Properties.Resources.Pongscheme,0,0);
            pictureBox1.Image=grap;
        }
         void button1_Click(object sender, EventArgs e) {
            image.Clear(Color.Black);
            image.DrawImage(Properties.Resources.Pongscheme,0,0);
            data.Clear();data=new List<object> {50,100,false,1,1,new Bitmap(1,1),100,rnd.Next(20,280),0};
            timer1.Start();label1.Text="0";button1.Visible=false;
        }
         protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up ){
                data[0]=(int)data[0]-10;playerBar.Image=new Bitmap(25, 460);
            }
            else if (keyData == Keys.Down){
                data[0]=(int)data[0]+10;playerBar.Image=new Bitmap(25, 460);
            }
            else if(keyData==Keys.Escape) {
                data[2]=!((bool)data[2]);
            }
            return true;
        }
         void playerBar_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            if((int)data[0]<0) {data[0]=0; } else if((int)data[0]>360) {data[0]=360; }
            g.FillRectangle(new SolidBrush(Color.Gray),0,(int)data[0],25,100);
        }

         void playerBar_MouseMove(object sender, MouseEventArgs e) {
            data[0]=MousePosition.Y-Location.Y-113;
            playerBar.Image=new Bitmap(25, 460);
        }
         void bounce() {
            if((int)data[6]>339&&(int)data[6]<391) { 
                image.DrawImage((Bitmap)data[5],new Point((int)data[6],(int)data[7]));}else {
                image.FillRectangle(new SolidBrush(Color.Black),(int)data[6],(int)data[7],20,20);}
            if((int)data[3]==1)  {if((int)data[6]>=710) {data[3]=-1; }}
            else if((int)data[3]==-1) {if((int)data[6]<=20) {data[3]=1; }}
            if((int)data[4]==1)  {if((int)data[7]>=460) {data[4]=-1; }}
            else if((int)data[4]==-1) {if((int)data[7]<=20) {data[4]=1; }}
            data[6]=(int)data[6]+(int)data[3]*5;
            data[7]=(int)data[7]+(int)data[4]*5;
            if((int)data[6]>339&&(int)data[6]<391) { 
            data[5]=Properties.Resources.Pongscheme.Clone(new Rectangle((int)data[6],(int)data[7],20,20),Properties.Resources.Pongscheme.PixelFormat);
            }
            image.FillPie(new SolidBrush(Color.Cyan),new Rectangle((int)data[6],(int)data[7],20,20),0,360);pictureBox1.Image=grap;
        }
         void timer1_Tick(object sender, EventArgs e) {
            if((int)data[6]==70) {
                int y=(int)data[0]+20,z=(int)data[7];
                Console.WriteLine(y+" "+z);
                if(y<=(z+10)&&(y+100)>=z) {data[3]=1;data[8]=(int)data[8]+1;label1.Text=data[8].ToString();}
            }
            else if((int)data[6]==20){timer1.Stop();button1.Visible=true;}
            bounce();
        }
    }
}
