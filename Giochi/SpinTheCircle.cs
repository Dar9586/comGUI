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
    public partial class SpinTheCircle : Form {
        public SpinTheCircle() {
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
         void prin(int num) {
            List<Color>col=new List<Color>(colors.GetRange(num,9-num));
            col.AddRange(colors.GetRange(0,num));
            g.Clear(Color.Black);
            g.DrawArc(new Pen(col[0],10),rect,70F,40);
            g.DrawArc(new Pen(col[1],10),rect,110F,40);
            g.DrawArc(new Pen(col[2],10),rect,150F,40);
            g.DrawArc(new Pen(col[3],10),rect,190F,40);
            g.DrawArc(new Pen(col[4],10),rect,230F,40);
            g.DrawArc(new Pen(col[5],10),rect,270F,40);
            g.DrawArc(new Pen(col[6],10),rect,310F,40);
            g.DrawArc(new Pen(col[7],10),rect,350F,40);
            g.DrawArc(new Pen(col[8],10),rect,30F,40);
            g.DrawString(bd[4].ToString(),new Font("Arial", 14),new SolidBrush(Color.White),new Point(0,0));
            g.FillEllipse(new SolidBrush(colors[bd[0]]),new Rectangle(240,bd[1],20,20));
            pictureBox1.Image=b;
        }
        Random rnd=new Random(Environment.TickCount);
        Rectangle rect=new Rectangle(25,25,450,450);
         static Bitmap b;
         static Graphics g;
         static List<int>bd=new List<int>();
         static List<Color>col1=new List<Color>();
         static List<Color>colors=new List<Color>() ;
         void SpinTheCircle_Load(object sender, EventArgs e) {
            col1.Clear();colors.Clear();bd.Clear();
            col1=new List<Color> {Color.FromArgb(255,255,255),Color.FromArgb(255,0,0),Color.FromArgb(0,255,0),Color.FromArgb(0,0,255),Color.FromArgb(255,255,0),Color.FromArgb(255,0,255),Color.FromArgb(0,255,255),Color.FromArgb(26,0,0),Color.FromArgb(255,36,0)};
            bd=new List<int> {rnd.Next(9),425,-3,rnd.Next(9),0 };
            for(int a=0;a<9;a++) {int h=rnd.Next(col1.Count);colors.Add(col1[h]);col1.RemoveAt(h); }
            b=new Bitmap(500,500);
            g=Graphics.FromImage(b);
            g.Clear(Color.Black);
            prin(bd[3]);
        }
        bool first=false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
    if (keyData == Keys.Left )
    {
         if(timer1.Enabled) { bd[3]=bd[3]==0?8:bd[3]-1; prin(bd[3]); } return true;  
    }
    if (keyData == Keys.Right)
    {
            if(timer1.Enabled) {bd[3]=bd[3]==8?0:bd[3]+1; prin(bd[3]); } return true;
    }
    
    return true;
        }

         void timer1_Tick(object sender, EventArgs e) {
            g.FillEllipse(new SolidBrush(Color.Black),new Rectangle(240,bd[1],20,20));
            bd[1]+=bd[2];
            g.FillEllipse(new SolidBrush(colors[bd[0]]),new Rectangle(240,bd[1]>448?448:bd[1],20,20));
            pictureBox1.Image=b;
            if(bd[1]<=240) {bd[2]=3; }
            if(bd[1]>=448) {if(bd[0]==bd[3]) {bd[2]=-3;bd[4]++;bd[0]=rnd.Next(9);prin(bd[3]); }else {g.DrawString("Hai Perso!!",new Font("Arial", 30),new SolidBrush(Color.Red),new Point(150,150));timer1.Stop();button1.Visible=true; }  }
        }

        private void button1_Click(object sender, EventArgs e) {
            if(first) { col1.Clear();colors.Clear();bd.Clear();
            col1=new List<Color> {Color.FromArgb(255,255,255),Color.FromArgb(255,0,0),Color.FromArgb(0,255,0),Color.FromArgb(0,0,255),Color.FromArgb(255,255,0),Color.FromArgb(255,0,255),Color.FromArgb(0,255,255),Color.FromArgb(26,0,0),Color.FromArgb(255,36,0)};
            bd=new List<int> {rnd.Next(9),425,-3,rnd.Next(9),0 };
            for(int a=0;a<9;a++) {int h=rnd.Next(col1.Count);colors.Add(col1[h]);col1.RemoveAt(h); }
            prin(bd[3]); }
            timer1.Enabled=!timer1.Enabled;button1.Visible=false;first=true;

        }
    }

    
}
