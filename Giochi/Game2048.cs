using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class Game2048 : Form {
        public Game2048() {
            InitializeComponent();
            this.FormClosing += back;
            for(int a=0;a<9999;a++) {comGUI.Menu.rnd.Next(897697); }
        }
        private static bool equa(List<int> x,List<int> y) {
            bool k=x.Count==y.Count;
            if(k) { 
            for(int a=0;a<x.Count;a++) {
                if(x[a]!=y[a]) {k=false;break; }
            }
            }
            return k;
        }
        private static List<int> assign(List<int> x,List<Button> y) {
            x.Clear();
            for(int a=0;a<16;a++) {
                if(y[a].Text!="") { 
                x.Add(int.Parse(y[a].Text));

                } else {x.Add(0); }
            }
            return x;
        }
        private static List<int> move(List<int> list, int num1, int num2)
		{
			if (list[num2] == 0 && list[num1] != 0)
			{
				list[num2] = list[num1];
				list[num1] = 0;
                poi2++; 
			}
			else if (list[num2] == list[num1] && list[num1] != 0)
			{
				list[num2] = list[num1] + list[num2];
               
               if(s) { poi+=list[num2];}
                  poi2++; 
				list[num1] = 0;
			}
			return list;
		}
		private static List<int> moveUp(List<int> list,List<Button> lis)
		{
            list=assign(list,lis);
			for (int a = 0; a < 5; a++)
			{
				list = move(list, 4, 0);
				list = move(list, 5, 1);
				list = move(list, 6, 2);
				list = move(list, 7, 3);
				list = move(list, 8, 4);
				list = move(list, 9, 5);
				list = move(list, 10, 6);
				list = move(list, 11, 7);
				list = move(list, 12, 8);
				list = move(list, 13, 9);
				list = move(list, 14, 10);
				list = move(list, 15, 11);
			}
			return list;
		}
		private static List<int> moveDown(List<int> list,List<Button> lis)
		{
            list=assign(list,lis);
			for (int a = 0; a < 5; a++)
			{
				list = move(list, 8, 12);
				list = move(list, 9, 13);
				list = move(list, 10, 14);
				list = move(list, 11, 15);
				list = move(list, 4, 8);
				list = move(list, 5, 9);
				list = move(list, 6, 10);
				list = move(list, 7, 11);
				list = move(list, 0, 4);
				list = move(list, 1, 5);
				list = move(list, 2, 6);
				list = move(list, 3, 7);
			}
			return list;
		}
		private static List<int> moveLeft(List<int> list,List<Button> lis)
		{
            list=assign(list,lis);
			for (int a = 0; a < 5; a++)
			{
				list = move(list, 1, 0);
				list = move(list, 5, 4);
				list = move(list, 9, 8);
				list = move(list, 13, 12);
				list = move(list, 2, 1);
				list = move(list, 6, 5);
				list = move(list, 10, 9);
				list = move(list, 14, 13);
				list = move(list, 3, 2);
				list = move(list, 7, 6);
				list = move(list, 11, 10);
				list = move(list, 15, 14);
			}
			return list;
		}
		private static List<int> moveRight(List<int> list,List<Button> lis)
		{
            list=assign(list,lis);
			for (int a = 0; a < 5; a++)
			{
				list = move(list, 2, 3);
				list = move(list, 6, 7);
				list = move(list, 10, 11);
				list = move(list, 14, 15);
				list = move(list, 1, 2);
				list = move(list, 5, 6);
				list = move(list, 9, 10);
				list = move(list, 13, 14);
				list = move(list, 0, 1);
				list = move(list, 4, 5);
				list = move(list, 8, 9);
				list = move(list, 12, 13);
			}
			return list;
		}
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
{
            if(!start.Visible) {
	//capture up arrow key
    if (keyData == Keys.Up &&up.Visible)
    {
         moveU();
    }
	//capture down arrow key
    if (keyData == Keys.Down &&down.Visible)
    {
          moveD(); 
    }
	//capture left arrow key
    if (keyData == Keys.Left &&left.Visible)
    {
         moveL();   
    }
	//capture right arrow key
    if (keyData == Keys.Right &&right.Visible)
    {
       moveR();
    }
    }
    return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void start_Click(object sender, EventArgs e) {
            start.Visible=false;
            label1.Visible=true;
            label2.Visible=true;
            up.Visible=true;
            left.Visible=true;
            right.Visible=true;
            down.Visible=true;
            start.Text="Rincomicia";
            int h=comGUI.Menu.rnd.Next(16);
            poi=0;label2.Text="0";
            lis.Clear();
            for(int a=0;a<16;a++) {list[a].Text="";lis.Add(0); }
            list[h].Text="2";
            lis[h]=1;
            }
        private void up_Click(object sender, EventArgs e) {
             moveU();
        }
        private void left_Click(object sender, EventArgs e) {
              moveL();
        }
        private void right_Click(object sender, EventArgs e) {
             moveR();
        }
        private void down_Click(object sender, EventArgs e) {
            moveD();
        }
        private void moveD() {lis=moveDown(lis,list);
            int h=comGUI.Menu.rnd.Next(3);
            if(h!=0&& lis.Contains(0)) {
                while(true) {
                    int k=comGUI.Menu.rnd.Next(16);
                    if(lis[k]==0) {lis[k]=2;list[k].Text="2"; break;}
                }
            }
            for(int a=0;a<16;a++) {  if(lis[a]!=0) {   list[a].Text=lis[a].ToString();}else { list[a].Text=""; }}
            label2.Text=poi.ToString();
                s=false;
                poi2=0;moveUp(lis,list); if(poi2==0) {   up.Visible=false;}else {up.Visible=true; }
                poi2=0;moveDown(lis,list); if(poi2==0) {   down.Visible=false;}else {down.Visible=true; }
                poi2=0;moveLeft(lis,list); if(poi2==0) {   left.Visible=false;}else {left.Visible=true; }
                poi2=0;moveRight(lis,list); if(poi2==0) {   right.Visible=false;}else {right.Visible=true; }
                s=true;
                if(up.Visible==false&&down.Visible==false&&left.Visible==false&&right.Visible==false) {
                    start.Visible=true;
                }   }
        private void moveU() {lis=moveUp(lis,list);
            int h=comGUI.Menu.rnd.Next(3);
            if(h!=0&& lis.Contains(0)) {
                while(true) {
                    int k=comGUI.Menu.rnd.Next(16);
                    if(lis[k]==0) {lis[k]=2;list[k].Text="2"; break;}
                }
            }
            for(int a=0;a<16;a++) {  if(lis[a]!=0) {   list[a].Text=lis[a].ToString();}else { list[a].Text=""; }}
            label2.Text=poi.ToString();
                s=false;
                poi2=0;moveUp(lis,list); if(poi2==0) {   up.Visible=false;}else {up.Visible=true; }
                poi2=0;moveDown(lis,list); if(poi2==0) {   down.Visible=false;}else {down.Visible=true; }
                poi2=0;moveLeft(lis,list); if(poi2==0) {   left.Visible=false;}else {left.Visible=true; }
                poi2=0;moveRight(lis,list); if(poi2==0) {   right.Visible=false;}else {right.Visible=true; }
                s=true;
                if(up.Visible==false&&down.Visible==false&&left.Visible==false&&right.Visible==false) {
                    start.Visible=true;
                } }
        private void moveL() {lis=moveLeft(lis,list);
            int h=comGUI.Menu.rnd.Next(3);
            if(h!=0&& lis.Contains(0)) {
                while(true) {
                    int k=comGUI.Menu.rnd.Next(16);
                    if(lis[k]==0) {lis[k]=2;list[k].Text="2"; break;}
                }
            }
            for(int a=0;a<16;a++) {  if(lis[a]!=0) {   list[a].Text=lis[a].ToString();}else { list[a].Text=""; }}
            label2.Text=poi.ToString();
                s=false;
                poi2=0;moveUp(lis,list); if(poi2==0) {   up.Visible=false;}else {up.Visible=true; }
                poi2=0;moveDown(lis,list); if(poi2==0) {   down.Visible=false;}else {down.Visible=true; }
                poi2=0;moveLeft(lis,list); if(poi2==0) {   left.Visible=false;}else {left.Visible=true; }
                poi2=0;moveRight(lis,list); if(poi2==0) {   right.Visible=false;}else {right.Visible=true; }
                s=true;
                if(up.Visible==false&&down.Visible==false&&left.Visible==false&&right.Visible==false) {
                    start.Visible=true;
                }  }
        private void moveR() {lis=moveRight(lis,list);
            int h=comGUI.Menu.rnd.Next(3);
            if(h!=0&& lis.Contains(0)) {
                while(true) {
                    int k=comGUI.Menu.rnd.Next(16);
                    if(lis[k]==0) {lis[k]=2;list[k].Text="2"; break;}
                }
            }
            for(int a=0;a<16;a++) {  if(lis[a]!=0) {   list[a].Text=lis[a].ToString();}else { list[a].Text=""; }}
            label2.Text=poi.ToString();
               s=false;
                poi2=0;moveUp(lis,list); if(poi2==0) {   up.Visible=false;}else {up.Visible=true; }
                poi2=0;moveDown(lis,list); if(poi2==0) {   down.Visible=false;}else {down.Visible=true; }
                poi2=0;moveLeft(lis,list); if(poi2==0) {   left.Visible=false;}else {left.Visible=true; }
                poi2=0;moveRight(lis,list); if(poi2==0) {   right.Visible=false;}else {right.Visible=true; }
                s=true;
                if(up.Visible==false&&down.Visible==false&&left.Visible==false&&right.Visible==false) {
                    start.Visible=true;
                } }

        

        private void createButton(int x,int y) {
            Button s=new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(52, 52);
            s.BackColor=Color.Black;
            s.ForeColor=Color.Cyan;
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            Controls.Add(s);
            list.Add(s);
        }

        private List<Button>list=new List<Button>();
        private List<int>lis=new List<int>();
        
        public static bool s=true;
        public static int poi2=0;
        public static int poi=0;

        private void Game2048_Load(object sender, EventArgs e) {
            List<int> s=new List<int> {12,70,128,186 };
            for(int a=0;a<4;a++) {
                for(int b=0;b<4;b++) {
                    createButton(s[b],s[a]);
                }
            }
        }
    }
}
