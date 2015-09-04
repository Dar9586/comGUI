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
            int a=1;
            while(a<30) {
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
           /* numericUpDown1.Visible=false;
            numericUpDown2.Visible=false;
            numericUpDown3.Visible=false;
            start.Visible=false;*/
                for(int a=0;a<numericUpDown1.Value*numericUpDown2.Value;a++) {list.Add(0); }
                for(int a=0;a<numericUpDown3.Value;a++) {
                    int j=comGUI.Menu.rnd.Next(list.Count);
                    if(list[j]==0) {list[j]=9; }else {a--; }
                }
              //  list[(int)numericUpDown4.Value]=9;
                control();
                generate();
            Size z=new Size((int)(16*numericUpDown1.Value),(int)(16*numericUpDown2.Value));
            b=new Bitmap(z.Width,z.Height);
            g=Graphics.FromImage(b);
            g.Clear(Color.Black);
                pictureBox1.Size=z;
              //  this.Size=new Size(z.Width+50,z.Height+150);
                drawScheme();
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

        private void control() {
            for(int a=0;a<list.Count;a++) {
                if(list[a]==9) {
                    int h=(int)numericUpDown1.Value;
                    int y=a-(h+1);
                    //primi 3 sopra
                 if(y>=0) {
                        if(list[y]!=9&&(y+1)%h!=0) {list[y]=list[y]+1; }
                        y++;
                        if(list[y]!=9) {list[y]=list[y]+1; }
                        y++;
                        if(list[y]!=9&&y%h!=0) {list[y]=list[y]+1; }
                    }
                 y=a-1;
                    //secondi 2 in mezzo
                if(y>=0&&list[y]!=9&&(y+1)%h!=0) {list[y]=list[y]+1; }
                y+=2;
                if(y<list.Count&&list[y]!=9&&y%h!=0) {list[y]=list[y]+1; }
                //terza fila sotto
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

        private void check(Point x) {
            Color s=b.GetPixel(x.X,x.Y);
            Debug.WriteLine(s);
            int k=(x.X/16)*16;
            int k1=(x.Y/16)*16;
            int xx=(x.X/16)+((x.Y/16)*(int)numericUpDown1.Value);
            string u=list[xx]==0?list[xx].ToString():" ";
            g.DrawString(u,SystemFonts.DialogFont,new SolidBrush(Color.Violet),new Point(k+3,k1+1));
            
            pictureBox1.Image=b;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            Point mpos=MousePosition;
            Point wpos=Location;
            Point pos=new Point(mpos.X-wpos.X-33,mpos.Y-wpos.Y-43);
            Debug.WriteLine(pos);
            if(e.Button.ToString()=="Right") {
               changeColor(pos);
            }
            if(e.Button.ToString()=="Left") {
                check(pos);
            }
        }
    }
}
