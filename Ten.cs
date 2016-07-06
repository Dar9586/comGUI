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
    public partial class Ten : Form {
        public Ten() {
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
        List<Button>but=new List<Button>();
        void createButton(int x,int y) {
            Button x1=new Button();
            x1.BackColor = Color.Black;
            x1.FlatStyle = FlatStyle.Flat;
            x1.BackColor = Color.Cyan;
            x1.Location = new Point(x, y);
            x1.TabStop=false;
            x1.Visible=false;
            x1.Size = new Size(25, 25);
            x1.UseVisualStyleBackColor = false;
            x1.Click+=buttonClick;
            x1.Tag=" ";
            x1.MouseEnter+=buttonMouseEnter;
            x1.MouseLeave+=buttonMouseLeave;
            Controls.Add(x1);but.Add(x1);
        }
        void buttonMouseLeave(object sender, EventArgs e) {
            int sen=findcubes(but.IndexOf(sender as Button));
            if(but[0].Size==new Size(25,25)&&complete[sen]==' ') { 
                recolor(sen,-1);
            }
            
        }
        void buttonMouseEnter(object sender, EventArgs e) {
            int sen=findcubes(but.IndexOf(sender as Button));
            if(but[0].Size==new Size(25,25)&&complete[sen]==' ') {
                recolor(-1,sen); 
            }
        }
        void buttonClick(object sender, EventArgs e) {
            int sen=findcubes(but.IndexOf(sender as Button));
            if(but[0].Size==new Size(25,25)&&complete[sen]==' ') { 
                reposition(true);
                changeCube(sen);
            }
        }
        void recolor(int ol,int ne){
            for(int a=0;a<9;a++) {
                if (ol!=-1) { but[cubes[ol][a]].BackColor=colors[cubes[ol][a]]; }
                if (ne!=-1) { but[cubes[ne][a]].BackColor=colors[cubes[ne][a]]==Color.Cyan?Color.Green:colors[cubes[ne][a]];
                } } }
        int findcubes(int num) {
            for(int a=0;a<9;a++) { if(cubes[a].Contains(num)) { return a; } }return -1;}
        List<Button>but1=new List<Button>();
        void createButton1(int x,int y){
            Button x1=new Button();
            x1.FlatStyle = FlatStyle.Flat;
            x1.BackColor = Color.Cyan;
            x1.Location = new Point(x, y);
            x1.Size = new Size(64, 64);
            x1.UseVisualStyleBackColor = true;
            x1.Click += button_Click1;
            x1.TabStop=false;
            x1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point,0);
            x1.Text=" ";
            x1.Visible=false;
            Controls.Add(x1);but1.Add(x1);}

        void checkwins() {
            int o=checkWin(findcubes((int)but1[0].Tag),false);
                if(o!=0) {
                    switch(o) {
                        case 1:complete[findcubes((int)but1[0].Tag)]='X';for(int a=0;a<9;a++) {but[cubes[findcubes((int)but1[0].Tag)][a]].Tag='X'; }break;
                        case 2:complete[findcubes((int)but1[0].Tag)]='O';for(int a=0;a<9;a++) {but[cubes[findcubes((int)but1[0].Tag)][a]].Tag='O'; }break;
                        case 3:complete[findcubes((int)but1[0].Tag)]='L';for(int a=0;a<9;a++) {but[cubes[findcubes((int)but1[0].Tag)][a]].Tag='L'; }break;
                } 
                    int o1=checkWin(findcubes((int)but1[0].Tag),true);
                    if(o1!=0) {end(o1);return;}
                }
        }

        async void button_Click1(object sender, EventArgs e) {
            int sen=but1.IndexOf(sender as Button);
            if(colors[(int)but1[sen].Tag]==Color.Cyan&&data[2]) {
                data[2]=false;
                but[(int)but1[sen].Tag].BackColor=data[1]?Color.Red:data[0]?Color.Yellow:Color.Red;
                but[(int)but1[sen].Tag].Tag=data[1]?"X":data[0]?"O":"X";
                colors[(int)but1[sen].Tag]=data[1]?Color.Red:data[0]?Color.Yellow:Color.Red;
                but1[sen].BackColor=data[1]?Color.Red:data[0]?Color.Yellow:Color.Red;
                await Task.Delay(data[1]?500:0);
                button3.BackColor=data[1]?Color.Black:data[0]?Color.Red:Color.Yellow;
                data[0]=!data[0];
                checkwins();
                if(complete[but1.IndexOf(sender as Button)]==' ') { 
                    recolor(findcubes((int)but1[0].Tag),but1.IndexOf(sender as Button));
                changeCube(but1.IndexOf(sender as Button));}
                else {recolor(findcubes((int)but1[0].Tag),-1); reposition(false); }
                if(data[1]) {data[0]=false; mainAI(false);}
            }
            data[2]=true;
        }
        void end(int num) {
            reposition(false);
            textBox1.Visible=true;
            button4.Visible=true;
            switch(num) {
                case 1:textBox1.Text=data[1]?"Hai Vinto":"Vince il giocatore 1";textBox1.ForeColor=Color.Red;break;
                case 2:textBox1.Text=data[1]?"Hai Perso":"Vince il giocatore 2";textBox1.ForeColor=Color.Yellow;break;
                case 3:textBox1.Text="Pareggio"; textBox1.ForeColor=Color.Coral;break;
            }
            for(int a=0;a<81;a++) {but[a].Click-=buttonClick; }
        }
        bool check(string x,List<int> num,string comp) {
            string y=x[num[0]].ToString()+x[num[1]].ToString()+x[num[2]].ToString();
            return y==comp;}
        int checkWin(int cube,bool super) {
            string str="";if(!super) { str=buildString(findcubes((int)but1[0].Tag));} else {
                for(int a=0;a<9;a++) {str+=complete[a]; }str.Replace('L',' ');
            }
                 if(check(str,new List<int>{0,1,2},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{3,4,5},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{6,7,8},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{0,3,6},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{1,4,7},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{2,5,8},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{0,4,8},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{2,4,6},"OOO")) {return super?2:chk(cube,2);}
            else if(check(str,new List<int>{0,1,2},"XXX")) {return super?1:chk(cube,1);}
            else if(check(str,new List<int>{3,4,5},"XXX")) {return super?1:chk(cube,1);}
            else if(check(str,new List<int>{6,7,8},"XXX")) {return super?1:chk(cube,1);}
            else if(check(str,new List<int>{0,3,6},"XXX")) {return super?1:chk(cube,1);}
            else if(check(str,new List<int>{1,4,7},"XXX")) {return super?1:chk(cube,1);}
            else if(check(str,new List<int>{2,5,8},"XXX")) {return super?1:chk(cube,1);}
            else if(check(str,new List<int>{0,4,8},"XXX")) {return super?1:chk(cube,1);}
            else if(check(str,new List<int>{2,4,6},"XXX")) {return super?1:chk(cube,1);}
            else {
             bool s=true;
                for (int a=0;a<9;a++){
                    if (str[a]==' '){s =false;break;}} 
                if(s) {return super?3:chk(cube,3); }
            }return 0;
        }
        int chk(int cube,int who) {
            Color f=Color.Gray;
            if(who==1) {f=Color.Red; }
            else if(who==2) {f=Color.Yellow; }
            else if(who==3) {f=Color.Coral; }
            for(int a=0;a<9;a++) {
                but[cubes[cube][a]].BackColor=f;
                colors[cubes[cube][a]]=f;
            }
            return who;
        }

        void changeCube(int cube) {
            for(int a=0;a<9;a++) {but1[a].Tag=cubes[cube][a];
                    but1[a].BackColor=colors[cubes[cube][a]]; }
        }
        string buildString(int cube) {
            string fin="";
            for(int a=0;a<9;a++) {fin+=but[cubes[cube][a]].Tag;}
            return fin;
        }

        List<char>complete=new List<char>();
        List<Color>colors=new List<Color>();
        List<bool>data=new List<bool>();
        //0=turno(0=rosso,1=giallo),1=modo(0=player,1=computer)
        List<List<int>>where=new List<List<int>> {
            new List<int> {0,3,6,27,30,33,54,57,60},
            new List<int> {1,4,7,28,31,34,55,58,61},
            new List<int> {2,5,8,29,32,35,56,59,62},
            new List<int> {9,12,15,36,39,42,63,66,69},
            new List<int> {10,13,16,37,40,43,64,67,70},
            new List<int> {11,14,17,38,41,44,65,68,71},
            new List<int> {18,21,24,45,48,51,72,75,78},
            new List<int> {19,22,25,46,49,52,73,76,79},
            new List<int> {20,23,26,47,50,53,74,77,80}
        };
        List<List<int>>cubes=new List<List<int>>();
        List<int>d=new List<int> {12,43,74,114,145,176,216,247,278,12,18,24,36,42,48,60,66,72};
        private void Ten_Load(object sender, EventArgs e) {
            but.Clear();but1.Clear();
            for(int a=0;a<3;a++) {for(int b=0;b<3;b++) {createButton1(13+b*66,13+a*66); }}
            for(int a=0;a<9;a++) {for(int b=0;b<9;b++) {createButton(d[b],d[a]); } }
            for(int a=0;a<9;a++) {int y=where[0][a]; cubes.Add(new List<int> {y,y+1,y+2,y+9,y+10,y+11,y+18,y+19,y+20});}
        }
        void reposition(bool small) {
            for (int a=0;a<9;a++) {
                for (int b=0;b<9;b++) {but[b+a*9].Size=small?new Size(5,5):new Size(25,25);
                    but[b+a*9].Location=new Point(d[b+(small?9:0)]+(small?350:0),d[a+(small?9:0)]);}
                but1[a].Visible=small;}
        }
        Random rnd=new Random(Environment.TickCount);
        private void button_Click(object sender, EventArgs e) {
            data.Clear(); data = new List<bool> {rnd.Next(2)==1?true:false,(sender as Button).TabIndex==1?true:false,true};
            complete.Clear(); complete = Enumerable.Repeat(' ', 9).ToList();
            colors.Clear(); colors = Enumerable.Repeat(Color.Cyan, 81).ToList(); 
            button1.Visible=button2.Visible=false;
            for(int a=0;a<81;a++) {but[a].Visible=true;but[a].Click+=buttonClick;but[a].BackColor=Color.Cyan;but[a].Tag=" "; }
            button3.BackColor=data[0]?Color.Yellow:Color.Red;button3.Visible=data[1]?false:true;
            if(data[0]&&data[1]) {mainAI(true); }
        }

        private async void mainAI(bool first) {
            if(first) { await Task.Delay(500);changeCube(rnd.Next(9));reposition(true); await Task.Delay(500); }
            else if(but[0].Size==new Size(25,25)||complete[findcubes((int)but1[0].Tag)]!=' ') { await Task.Delay(500);selectCubeAI(); await Task.Delay(500); }
            for(int a=0;a<81;a++) {but[a].BackColor=colors[a]; }
            for(int a=0;a<9;a++) {but[cubes[findcubes((int)but1[0].Tag)][a]].BackColor=but[cubes[findcubes((int)but1[0].Tag)][a]].BackColor==Color.Cyan?Color.Green:but[cubes[findcubes((int)but1[0].Tag)][a]].BackColor; }
            await Task.Delay(500);await playAI(findcubes((int)but1[0].Tag),true);
        }
        private async Task<string> playAI(int cube,bool mode) {
            string str=buildString(cube);string hhh="";
                 if(checkAI(str,0,1,2,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,0,1,2,1)); }
            else if(checkAI(str,3,4,5,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,3,4,5,1)); }
            else if(checkAI(str,6,7,8,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,6,7,8,1)); }
            else if(checkAI(str,0,3,6,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,0,3,6,1)); }
            else if(checkAI(str,1,4,7,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,1,4,7,1)); }
            else if(checkAI(str,2,5,8,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,2,5,8,1)); }
            else if(checkAI(str,0,4,8,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,0,4,8,1)); }
            else if(checkAI(str,2,4,6,1)!=-1){hhh=(mode?"":"V")+await updateAI(checkAI(str,2,4,6,1)); }
            else if(checkAI(str,0,1,2,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,0,1,2,2)); }
            else if(checkAI(str,3,4,5,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,3,4,5,2)); }
            else if(checkAI(str,6,7,8,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,6,7,8,2)); }
            else if(checkAI(str,0,3,6,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,0,3,6,2)); }
            else if(checkAI(str,1,4,7,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,1,4,7,2)); }
            else if(checkAI(str,2,5,8,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,2,5,8,2)); }
            else if(checkAI(str,0,4,8,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,0,4,8,2)); }
            else if(checkAI(str,2,4,6,2)!=-1){hhh=(mode?"":"B")+await updateAI(checkAI(str,2,4,6,2)); }
            else { int s=rnd.Next(9);while (but1[s].BackColor!=Color.Cyan) {s=rnd.Next(9); }
            hhh= mode?await updateAI(checkAI(str,s,s,s,3)):"N9"; }
            return hhh;
        }

        private async Task<string> updateAI(int v) {
            int o=cubes[findcubes((int)but1[0].Tag)][v];
            but[o].BackColor=Color.Yellow;
            colors[o]=Color.Yellow;
            but[o].Tag="O";
            but1[v].BackColor=Color.Yellow;
            checkwins();
            await Task.Delay(500);
            if(complete[v]==' ') { 
                    recolor(findcubes((int)but1[0].Tag),v);
                changeCube(v);}
                else {recolor(findcubes((int)but1[0].Tag),-1); reposition(false); }
            return o.ToString();
        }
        private int checkAI(string str,int n1,int n2,int n3, int v) {
            if(v==3) {return n1; }
            int how=0,pos=-1;
            string h=str[n1].ToString()+str[n2].ToString()+str[n3].ToString();
            for(int a=0;a<3;a++) {if(h[a]!=' ') {how++; }else {switch(a) { case 0:pos=n1;break;case 1:pos=n2;break;case 2:pos=n3;break; } } }
            if (how==2) {
                if(pos==n1&&str[n2]==str[n3]) {return pos; }
                if(pos==n2&&str[n1]==str[n3]) {return pos; }
                if(pos==n3&&str[n1]==str[n2]) {return pos; }
            }
            return -1;
        }
        private async void selectCubeAI() {
            for(int a=0;a<9;a++) {if(complete[a]==' ') { string s=await playAI(a,false);if(s[0]=='V') {changeCube(a);reposition(true);return; } } }
            for(int a=0;a<9;a++) {if(complete[a]==' ') { string s=await playAI(a,false);if(s[0]=='B') {changeCube(a);reposition(true);return; } } }
            while(true) {int k=rnd.Next(9);if(complete[k]==' ') {changeCube(k);reposition(true);return; } }
        }

        private void button4_Click(object sender, EventArgs e) {
            for(int a=0;a<81;a++) {but[a].Visible=false; }
            button4.Visible=false;
            textBox1.Visible=false;
            button3.Visible=false;
            button1.Visible=button2.Visible=true;
        }
    }
}
