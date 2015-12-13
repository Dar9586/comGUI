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
    public partial class Minesweeper : Form {
        public Minesweeper() {
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
        Bitmap b;
        Graphics g;
        private void Minesweeper_Load(object sender, EventArgs e) {
          
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            numericUpDown3.Maximum=numericUpDown1.Value*numericUpDown2.Value-5;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
            numericUpDown3.Maximum=numericUpDown1.Value*numericUpDown2.Value-5;
        }

        private void drawScheme() {
            int a=0;
            while(a<35) {
                int b=a*16;
                g.DrawLine(new Pen(Color.Cyan,1),new Point(b,0),new Point(b,480));
                g.DrawLine(new Pen(Color.Cyan,1),new Point(0,b),new Point(480,b));
                a++;
            }
        }
        List<int>list=new List<int>();
        private void Inizia_Click(object sender, EventArgs e) {
            if(numericUpDown3.Value<=numericUpDown3.Maximum) { 
                list.Clear();
                time=0;
                can=true;
                label5.Text="00 : 00";
                used.Clear();
                for(int a=0;a<numericUpDown1.Value*numericUpDown2.Value;a++) {list.Add(0);used.Add(true); }
                for(int a=0;a<numericUpDown3.Value;a++) {
                    int j=comGUI.Menu.rnd.Next(list.Count);
                    if(list[j]==0) {list[j]=9; }else {a--; }
                }
                control();
                generate();
            Size z=new Size((int)(16*numericUpDown1.Value+1),(int)(16*numericUpDown2.Value+1));
            b=new Bitmap(z.Width,z.Height);
            g=Graphics.FromImage(b);
            g.Clear(Color.Black);
                pictureBox1.Size=z;
                this.Size=new Size(z.Width+50,z.Height+150);
                drawScheme();
                layout(false);
                label4.Location=reset.Location=new Point(30,pictureBox1.Size.Height+20);
                reset.Location=new Point(25,pictureBox1.Size.Height+40);
                reset.Size=new Size(pictureBox1.Size.Width,23);
                label5.Location=new Point(25,pictureBox1.Size.Height+65);
            pictureBox1.Image=b;
                }
            else {numericUpDown3.Value=numericUpDown3.Maximum; }
        }
         protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
    if (keyData == Keys.Left )
    { 
           Cursor.Position=new Point(MousePosition.X-1,MousePosition.Y);     
    }
    if (keyData == Keys.Right) { 
           Cursor.Position=new Point(MousePosition.X+1,MousePosition.Y);     
    }
    if (keyData == Keys.Up){ 
           Cursor.Position=new Point(MousePosition.X,MousePosition.Y-1);     
    }
    if (keyData == Keys.Down){ 
           Cursor.Position=new Point(MousePosition.X,MousePosition.Y+1);     
    }
    return true;
        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            
        }

        private void layout(bool x) {
            numericUpDown1.Visible=x;
            numericUpDown2.Visible=x;
            numericUpDown3.Visible=x;
            label1.Visible=x;
            label2.Visible=x;
            label3.Visible=x;
            start.Visible=x;
            pictureBox1.Visible=!x;
            reset.Visible=!x;
        }
        int red=0,yellow=0;
        private void control() {
            for(int a=0;a<list.Count;a++) {
                if(list[a]==9) {
                    int h=(int)numericUpDown1.Value;
                    int y=a-(h+1);
                 if(y>=0) {
                        if(list[y]!=9&&(y+1)%h!=0) {list[y]=list[y]+1; }
                        y++;
                        if(list[y]!=9) {list[y]=list[y]+1; }
                        y++;
                        if(list[y]!=9&&y%h!=0) {list[y]=list[y]+1; }
                    }
                 y=a-1;
                if(y>=0&&list[y]!=9&&(y+1)%h!=0) {list[y]=list[y]+1; }
                y+=2;
                if(y<list.Count&&list[y]!=9&&y%h!=0) {list[y]=list[y]+1; }
                y=a+h+1;
                    if(y<list.Count) {
                         if(list[y]!=9&&y%h!=0) {list[y]=list[y]+1; }
                        y--;
                        if(list[y]!=9) {list[y]=list[y]+1; }
                        y--;
                       if(list[y]!=9&&(y+1)%h!=0) {list[y]=list[y]+1; }
                    }

                }
            }
        }
        private void generate() {
            int old=0;
            for(int a=0;a<numericUpDown1.Value;a++) {
                for(int b=0;b<numericUpDown2.Value;b++) {
                    Debug.Write(list[b+old]+" ");
                }
                Debug.WriteLine("");
                old+=(int)numericUpDown1.Value;
            }
            Debug.WriteLine("\n");
        }
        private void changeColor(Point x) {
            Color s=b.GetPixel(x.X,x.Y);
            Debug.WriteLine(s);
            int k=(x.X/16)*16;
            int k1=(x.Y/16)*16;
            Rectangle r=new Rectangle(k,k1,16,16);
            if(s==Color.FromArgb(255,0,0,0)) {g.FillRectangle(new SolidBrush(Color.Yellow),r); }
            else if(s==Color.FromArgb(255,255,255,0)) {g.FillRectangle(new SolidBrush(Color.Red),r);}
            else if(s==Color.FromArgb(255,255,0,0)) {g.FillRectangle(new SolidBrush(Color.Black),r);}
            drawScheme();
            pictureBox1.Image=b;
        }
        private void recolor(Point x) {
            int k=(x.X/16)*16;
            int k1=(x.Y/16)*16;
            Rectangle r=new Rectangle(k,k1,16,16);
            g.FillRectangle(new SolidBrush(Color.Gray),r); 
            drawScheme();
            pictureBox1.Image=b;
        }
        List<bool>used=new List<bool>();
        private int check(Point x) {
            int xx=-1;
            if(x.X>=0&&x.Y>=0&&x.X<numericUpDown1.Value*16&&x.Y<numericUpDown2.Value*16) { 
             int k=(x.X/16)*16;
            int k1=(x.Y/16)*16;
             xx=(x.X/16)+((x.Y/16)*(int)numericUpDown1.Value);
            if(!used[xx]) {return -1; } 
            string u=list[xx]==0?" ":list[xx].ToString();
             u=list[xx]==9?"X":u;
            recolor(x);
            g.DrawString(u,SystemFonts.DialogFont,new SolidBrush(Color.Violet),new Point(k+3,k1+1));
           used[xx]=false;
            if(u==" ") {
                Point sx=new Point(x.X-16,x.Y-16);
                check(sx);
                sx=new Point(x.X,x.Y-16);
                check(sx);
                sx=new Point(x.X+16,x.Y-16);
                check(sx);
                sx=new Point(x.X-16,x.Y);
                check(sx);
                sx=new Point(x.X+16,x.Y);
                check(sx);
                sx=new Point(x.X-16,x.Y+16);
                check(sx);
                sx=new Point(x.X,x.Y+16);
                check(sx);
                sx=new Point(x.X+16,x.Y+16);
                check(sx);

            }
            return list[xx];
            }
          return -1;
        }
        
        private void lose() {
            timer1.Stop();
            can=false;
            reset.ForeColor=Color.Red;
            label4.ForeColor=Color.Red;
            label4.Text="Hai Perso!";
            reset.Text="Reset";
        }
        private void win() {
            timer1.Stop();
            can=false;
            reset.ForeColor=Color.Green;
            label4.ForeColor=Color.Green;
            label4.Text="Hai Vinto!";
            reset.Text="Reset";
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            if(can) { 
            timer1.Start();
            Point mpos=MousePosition;
            Point wpos=Location;
            Point pos=new Point(mpos.X-wpos.X-33,mpos.Y-wpos.Y-43);
            Debug.WriteLine(pos);
            if(e.Button.ToString()=="Right") {
               changeColor(pos);
            }
            if(e.Button.ToString()=="Left") {
                int s=check(pos);pictureBox1.Image=b; 
                if(s==9) {lose(); }
                else {
                    bool t=true;
                    for(int a=0;a<used.Count;a++) {if(used[a]&&list[a]!=9) {t=false;} }
                    if(t) {win(); }
                }
            }
            }
        }

        private void reset_Click(object sender, EventArgs e) {
            if(reset.Text=="Resa") {
                int w=pictureBox1.Size.Width/16;
                int h=pictureBox1.Size.Height/16;
                for(int a=0;a<w;a++) {
                    for(int c=0;c<h;c++) {
                        Debug.WriteLine(new Point(a*16,c*16));
                        check(new Point(a*16,c*16));
                    }
                }
                pictureBox1.Image=b;
                can=false;
                reset.ForeColor=Color.Red;
                label4.ForeColor=Color.Red;
                label4.Text="Hai Perso!";
                reset.Text="Reset";
            }
            else if(reset.Text=="Reset") {
                Size=new Size(248,264);
                label5.Text="";
                layout(true);
                label4.Text="";
                reset.Text="Resa";
            }
        }
        int time=0;
        bool can=true;
        private void timer1_Tick(object sender, EventArgs e) {
            time++;
                int oth=time;
                string final="";
                if((oth/60)<10) {final+="0"; }
                final+=(int)(oth/60)+" : ";
                if((oth%60)<10) {final+="0"; }
                final+=(oth%60).ToString();
                label5.Text=final;
            }
        
    }
}
