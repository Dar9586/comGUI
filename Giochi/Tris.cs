using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace comGUI {
    public partial class Tris : Form {
        public Tris() {
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
         List<Button>but=new List<Button>();
        private void Tris_Load(object sender, EventArgs e) {
            data.Clear();but.Clear();
            for(int a=0;a<3;a++) {
                for(int b=0;b<3;b++) {createButton(13+b*66,13+a*66); }
            }
        }
        void createButton(int x,int y){
            Button x1=new Button();
            x1.FlatStyle = FlatStyle.Flat;
            x1.ForeColor = Color.Cyan;
            x1.Location = new Point(x, y);
            x1.Size = new Size(64, 64);
            x1.UseVisualStyleBackColor = true;
            x1.Click += button_Click;
            x1.TabStop=false;
            x1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            x1.Text=" ";
            x1.Visible=false;
            Controls.Add(x1);but.Add(x1);}
        List<int>data=new List<int>();
        //0=modalità,1=turno(0=x,1=o),2=punti player,3=punti giocatore/computer,
        private void button_Click(object sender, EventArgs e) {
            int sen=but.IndexOf(sender as Button);
            but[sen].Click -= button_Click;
            but[sen].ForeColor=data[1]==0?Color.Green:Color.Red;
            but[sen].Text=data[1]==0?"X":"O";
            if(checkWin(true)!=0) {updatePoint();button3.Visible=true;for(int a=0;a<9;a++) {but[a].Click-=button_Click; }return; };
            switch(data[0]) {
                case 0:AI();if(checkWin(true)!=0) {updatePoint();button3.Visible=true;for(int a=0;a<9;a++) {but[a].Click-=button_Click; }return; };break;
                case 1:data[1]=data[1]==0?1:0;break;
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            data=new List<int> {(sender as Button).TabIndex,rnd.Next(2),0,0 };
            button1.Visible=false;button2.Visible=false;label1.Visible=true;label2.Visible=true;
            updatePoint();
            for(int a=0;a<9;a++) {but[a].Visible=true; }
            if(data[0]==0&&data[1]==1) {AI();data[1]=0; }
        }
        int chk(List<int>x,bool up,int s) {label3.Text=data[0]==0?"Hai Perso!":"Vince il giocatore 2";but[x[0]].ForeColor=Color.Coral;but[x[1]].ForeColor=Color.Coral;but[x[2]].ForeColor=Color.Coral;if(up)data[s==1?3:2]++;return s; }
        private int checkWin(bool up) {
            string str="";for(int a=0;a<9;a++) {str+=but[a].Text; }
                 if(check(str,new List<int>{0,1,2},"OOO")) {return chk(new List<int>{0,1,2},up,1);}
            else if(check(str,new List<int>{3,4,5},"OOO")) {return chk(new List<int>{3,4,5},up,1);}
            else if(check(str,new List<int>{6,7,8},"OOO")) {return chk(new List<int>{6,7,8},up,1);}
            else if(check(str,new List<int>{0,3,6},"OOO")) {return chk(new List<int>{0,3,6},up,1);}
            else if(check(str,new List<int>{1,4,7},"OOO")) {return chk(new List<int>{1,4,7},up,1);}
            else if(check(str,new List<int>{2,5,8},"OOO")) {return chk(new List<int>{2,5,8},up,1);}
            else if(check(str,new List<int>{0,4,8},"OOO")) {return chk(new List<int>{0,4,8},up,1);}
            else if(check(str,new List<int>{2,4,6},"OOO")) {return chk(new List<int>{2,4,6},up,1);}
            else if(check(str,new List<int>{0,1,2},"XXX")) {return chk(new List<int>{0,1,2},up,2);}
            else if(check(str,new List<int>{3,4,5},"XXX")) {return chk(new List<int>{3,4,5},up,2);}
            else if(check(str,new List<int>{6,7,8},"XXX")) {return chk(new List<int>{6,7,8},up,2);}
            else if(check(str,new List<int>{0,3,6},"XXX")) {return chk(new List<int>{0,3,6},up,2);}
            else if(check(str,new List<int>{1,4,7},"XXX")) {return chk(new List<int>{1,4,7},up,2);}
            else if(check(str,new List<int>{2,5,8},"XXX")) {return chk(new List<int>{2,5,8},up,2);}
            else if(check(str,new List<int>{0,4,8},"XXX")) {return chk(new List<int>{0,4,8},up,2);}
            else if(check(str,new List<int>{2,4,6},"XXX")) {return chk(new List<int>{2,4,6},up,2);}
            else {
             bool s=true; for(int a=0;a<9;a++){if(but[a].Text==" "){s=false;break;}}if(s){for(int a=0;a<9;a++) {but[a].ForeColor=Color.Coral; } label3.Text="Pareggio!";return 3;}
            }return 0;
        }
        void updatePoint() {
            switch(checkWin(false)) {
                case 1:label3.ForeColor=Color.Red;break;
                case 2:label3.ForeColor=Color.Green;break;
                case 3:label3.ForeColor=Color.Coral;break;
            }
            label1.Text=(data[0]==0?"Giocatore : ":"Giocatore 1 : ")+data[2].ToString();
            label2.Text=(data[0]==0?"Computer  : ":"Giocatore 2 : ")+data[3].ToString();
        }
        
        bool check(string x,List<int> num,string comp) {
            string y=x[num[0]].ToString()+x[num[1]].ToString()+x[num[2]].ToString();
            return y==comp;}
        void AIchk(int x) {but[x].Text="O";but[x].Click-=button_Click;but[x].ForeColor=Color.Red; }
        private void AI( ) {
            string str="";for(int a=0;a<9;a++) {str+=but[a].Text; }
                 if(check(str,new List<int>{0,1,2},"OO ")) {AIchk(2);}
            else if(check(str,new List<int>{0,1,2},"O O")) {AIchk(1);}
            else if(check(str,new List<int>{0,1,2}," OO")) {AIchk(0);}
            else if(check(str,new List<int>{3,4,5},"OO ")) {AIchk(5);}
            else if(check(str,new List<int>{3,4,5},"O O")) {AIchk(4);}
            else if(check(str,new List<int>{3,4,5}," OO")) {AIchk(3);}
            else if(check(str,new List<int>{6,7,8},"OO ")) {AIchk(8);}
            else if(check(str,new List<int>{6,7,8},"O O")) {AIchk(7);}
            else if(check(str,new List<int>{6,7,8}," OO")) {AIchk(6);}
            else if(check(str,new List<int>{0,3,6},"OO ")) {AIchk(6);}
            else if(check(str,new List<int>{0,3,6},"O O")) {AIchk(3);}
            else if(check(str,new List<int>{0,3,6}," OO")) {AIchk(0);}
            else if(check(str,new List<int>{1,4,7},"OO ")) {AIchk(7);}
            else if(check(str,new List<int>{1,4,7},"O O")) {AIchk(4);}
            else if(check(str,new List<int>{1,4,7}," OO")) {AIchk(1);}
            else if(check(str,new List<int>{2,5,8},"OO ")) {AIchk(8);}
            else if(check(str,new List<int>{2,5,8},"O O")) {AIchk(5);}
            else if(check(str,new List<int>{2,5,8}," OO")) {AIchk(2);}
            else if(check(str,new List<int>{0,4,8},"OO ")) {AIchk(8);}
            else if(check(str,new List<int>{0,4,8},"O O")) {AIchk(4);}
            else if(check(str,new List<int>{0,4,8}," OO")) {AIchk(0);}
            else if(check(str,new List<int>{2,4,6},"OO ")) {AIchk(6);}
            else if(check(str,new List<int>{2,4,6},"O O")) {AIchk(4);}
            else if(check(str,new List<int>{2,4,6}," OO")) {AIchk(2);}
            else if(check(str,new List<int>{0,1,2},"XX ")) {AIchk(2);}
            else if(check(str,new List<int>{0,1,2},"X X")) {AIchk(1);}
            else if(check(str,new List<int>{0,1,2}," XX")) {AIchk(0);}
            else if(check(str,new List<int>{3,4,5},"XX ")) {AIchk(5);}
            else if(check(str,new List<int>{3,4,5},"X X")) {AIchk(4);}
            else if(check(str,new List<int>{3,4,5}," XX")) {AIchk(3);}
            else if(check(str,new List<int>{6,7,8},"XX ")) {AIchk(8);}
            else if(check(str,new List<int>{6,7,8},"X X")) {AIchk(7);}
            else if(check(str,new List<int>{6,7,8}," XX")) {AIchk(6);}
            else if(check(str,new List<int>{0,3,6},"XX ")) {AIchk(6);}
            else if(check(str,new List<int>{0,3,6},"X X")) {AIchk(3);}
            else if(check(str,new List<int>{0,3,6}," XX")) {AIchk(0);}
            else if(check(str,new List<int>{1,4,7},"XX ")) {AIchk(7);}
            else if(check(str,new List<int>{1,4,7},"X X")) {AIchk(4);}
            else if(check(str,new List<int>{1,4,7}," XX")) {AIchk(1);}
            else if(check(str,new List<int>{2,5,8},"XX ")) {AIchk(8);}
            else if(check(str,new List<int>{2,5,8},"X X")) {AIchk(5);}
            else if(check(str,new List<int>{2,5,8}," XX")) {AIchk(2);}
            else if(check(str,new List<int>{0,4,8},"XX ")) {AIchk(8);}
            else if(check(str,new List<int>{0,4,8},"X X")) {AIchk(4);}
            else if(check(str,new List<int>{0,4,8}," XX")) {AIchk(0);}
            else if(check(str,new List<int>{2,4,6},"XX ")) {AIchk(6);}
            else if(check(str,new List<int>{2,4,6},"X X")) {AIchk(4);}
            else if(check(str,new List<int>{2,4,6}," XX")) {AIchk(2);}
            else {int s=rnd.Next(9);while (but[s].Text!=" ") {s=rnd.Next(9); }AIchk(s);}
        }
        private void button3_Click(object sender, EventArgs e) {
            button3.Visible=false;label3.ForeColor=Color.Black;
            for(int a=0;a<9;a++) {Controls.Remove(but[a]);but[a].Dispose(); }
            but.Clear(); for(int a=0;a<3;a++) {
                for(int b=0;b<3;b++) {createButton(13+b*66,13+a*66);but[but.Count-1].Visible=true; }
            }data[1]=rnd.Next(2);if(data[0]==0&&data[1]==1) {AI();data[1]=0; }
        }
    }
}
