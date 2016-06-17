using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class Tiles : Form {
 public Tiles() {
            InitializeComponent();
         this.FormClosing += back;
            for(int a=0;a<99999;a++) {rnd.Next(648974); }
        }
  void back(object sender, EventArgs e) {
            if (Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        Random rnd=new Random(Environment.TickCount);
  static string where(int num)
		{
			if (num == 0){return "09,15";}
			else if (num == 1){return "10,14,16";}
			else if (num == 2){return "07,11,15,17";}
			else if (num == 3){return "08,12,16,18";}
			else if (num == 4){return "13,09,17,19";}
			else if (num == 5){return "10,18,20";}
			else if (num == 6){return "11,19";}
			else if (num == 7){return "02,16,22";}
			else if (num == 8){return "03,17,21,23";}
			else if (num == 9){return "00,04,14,18,22,24";}
			else if (num == 10){return "01,05,15,19,23,25";}
			else if (num == 11){return "02,06,16,20,24,26";}
			else if (num == 12){return "03,17,25,27";}
			else if (num == 13){return "04,18,26";}
			else if (num == 14){return "01,09,23,29";}
			else if (num == 15){return "00,02,10,24,28,30";}
			else if (num == 16){return "01,03,07,11,21,25,29,31";}
			else if (num == 17){return "02,04,08,12,22,26,30,32";}
			else if (num == 18){return "03,05,09,13,23,27,31,33";}
			else if (num == 19){return "04,06,10,24,32,34";}
			else if (num == 20){return "05,11,25,33";}
			else if (num == 21){return "08,16,30,36";}
			else if (num == 22){return "07,09,17,31,35,37";}
			else if (num == 23){return "08,10,14,18,28,32,36,38";}
			else if (num == 24){return "09,11,15,19,29,33,37,39";}
			else if (num == 25){return "10,12,16,20,30,34,38,40";}
			else if (num == 26){return "11,13,17,31,39,41";}
			else if (num == 27){return "12,18,32,40";}
			else if (num == 28){return "15,23,37,43";}
			else if (num == 29){return "14,16,24,38,42,44";}
			else if (num == 30){return "15,17,21,25,35,39,43,45";}
			else if (num == 31){return "16,18,22,26,36,40,44,46";}
			else if (num == 32){return "17,19,23,27,37,41,45,47";}
			else if (num == 33){return "18,20,24,38,46,48";}
			else if (num == 34){return "19,25,39,47";}
			else if (num == 35){return "22,30,44";}
			else if (num == 36){return "21,23,31,45";}
			else if (num == 37){return "22,24,28,32,42,46";}
			else if (num == 38){return "23,25,29,33,43,47";}
			else if (num == 39){return "24,26,30,34,44,48";}
			else if (num == 40){return "25,27,31,45";}
			else if (num == 41){return "26,32,46";}
			else if (num == 42){return "29,37";}
			else if (num == 43){return "28,30,38";}
			else if (num == 44){return "29,31,35,39";}
			else if (num == 45){return "30,32,36,40";}
			else if (num == 46){return "31,33,37,41";}
			else if (num == 47){return "32,34,38";}
			else if (num == 48){return "33,39";}
			else{return "";}
		}
  void canUse(int num) {
             string str=where(num);
            string[] st=str.Split(',');
            List<int> s=new List<int>();
             for(int a=0;a<49;a++) {list[a].ForeColor=Color.Black;if(a==num) {list[a].ForeColor=Color.Green;} }
            for(int a=0;a<st.Length;a++) {s.Add(int.Parse(st[a])); }
            for(int a=0;a<s.Count;a++) {
                if(list[s[a]].Text!="") {list[s[a]].ForeColor=Color.Red; }
                else {list[s[a]].ForeColor=Color.Blue;list[s[a]].Enabled=true; }
            }
        }
  void lose() {
             for(int a=0;a<49;a++) {list[a].ForeColor=Color.Red;}
            timer1.Stop();
            start.Visible=true;
            start.Text="Rincomincia";
            label3.ForeColor=Color.Red;label3.Text="Hai Perso!";  
        }
  void win() {
            for(int a=0;a<49;a++) {list[a].ForeColor=Color.Green;}
            timer1.Stop();
            start.Visible=true;
            start.Text="Rincomincia";
            label3.ForeColor=Color.Green;label3.Text="Hai Vinto!";  
        }

  void button_Click(object sender, EventArgs e) {button(list.IndexOf(sender as Button));}
 
  void timer1_Tick(object sender, EventArgs e) {   time++;
            int m=(int) time/60;
            int s=time%60;
            string t="";
            if(m<10) {t+="0";}
            t+=m.ToString();
            t+=" : ";
            if(s<10) {t+="0";}
            t+=s.ToString();
            label1.Text=t;
        }
  void button(int button) {
            for(int a=0;a<49;a++) {list[a].Enabled=false; }
            poi++;
            if (poi<10) {list[button].Text="0"; }
            list[button].Text+=poi.ToString();
            canUse(list.IndexOf(list[button]));
            if(poi==49){win();return;}
            bool k=true;
            for (int a=0;a<49;a++){if(list[a].Enabled==true){k=false;}}
            if (k){lose();}
        }
  void start_Click(object sender, EventArgs e) {
            label1.Text="00 : 00";
            label3.Text="";
            for(int a=0;a<49;a++){list[a].Text="";}
            poi=1;
            time=0;
            label1.Visible=true;
            label2.Visible=true;
            timer1.Enabled=true;
            start.Visible=false;
            int h=rnd.Next(49);
            list[h].Text="01";
           canUse(h);
        }

         List<Button> list=new List<Button>();
         int time=0;
         int poi=1;

         void createButton(int x,int y) {
            Button s=new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(30, 30);
            s.BackColor=Color.FromArgb(255,64,64,64);
            s.ForeColor=Color.Red;
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            s.Click += new EventHandler(button_Click);
            Controls.Add(s);
            list.Add(s);
            
        }

         void Tiles_Load(object sender, EventArgs e) {
            int s=13;
            List<int> o=new List<int>();
            while(o.Count<7) {o.Add(s);s+=36; }
            for(int a=0;a<7;a++) {
                for(int b=0;b<7;b++) {
                    createButton(o[b],o[a]);
                }
            }
        }
    }
}
