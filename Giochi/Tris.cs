using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace comGUI {
    public partial class Tris : Form {
        public Tris() {
            InitializeComponent();
            this.FormClosing += back;
            list.Add(button1);
            list.Add(button2);
            list.Add(button3);
            list.Add(button6);
            list.Add(button5);
            list.Add(button4);
            list.Add(button9);
            list.Add(button8);
            list.Add(button7);
        }
        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled=false;
            button1.Text=s;
            if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }

        }
        private void button2_Click(object sender, EventArgs e) {
            button2.Enabled=false;
            button2.Text=s;
             if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button3_Click(object sender, EventArgs e) {
            button3.Enabled=false;
            button3.Text=s;
             if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button6_Click(object sender, EventArgs e) {
            button6.Enabled=false;
            button6.Text=s;
            if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button5_Click(object sender, EventArgs e) {
            button5.Enabled=false;
            button5.Text=s;
             if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button4_Click(object sender, EventArgs e) {
            button4.Enabled=false;
            button4.Text=s;
            if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button9_Click(object sender, EventArgs e) {
            button9.Enabled=false;
            button9.Text=s;
             if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button8_Click(object sender, EventArgs e) {
            button8.Enabled=false;
            button8.Text=s;
             if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button7_Click(object sender, EventArgs e) {
            button7.Enabled=false;
            button7.Text=s;
            if(select) {checkwin(list); }else {if(s=="X") { s="O";}else {s="X";}checkwin(list); }
        }
        private void button10_Click(object sender, EventArgs e) {
            button11.Visible=false;
            button10.Visible=false;
            label1.Text="Giocatore";
            label2.Text="Computer";
            label3.Text="0";
            label4.Text="0";
            s="X";
            select=true;
            for(int a=0;a<9;a++) {list[a].Enabled=true; list[a].Text=" "; }
        }
        private void button11_Click(object sender, EventArgs e) {
            button11.Visible=false;
            button10.Visible=false;
            label1.Text="Giocatore X";
            label2.Text="Giocatore O";
            label3.Text="0";
            label4.Text="0";
            for(int a=0;a<9999;a++) {rnd.Next(9784987); }
            int o=rnd.Next(2);
            if(o==1) {s="X" ;}else {s="0"; }
            for(int a=0;a<9;a++) {list[a].Enabled=true;list[a].Text=" "; }
        }
        private void button12_Click(object sender, EventArgs e) {
            for(int a=0;a<9;a++) {list[a].Enabled=true;list[a].Text=" "; }
            button12.Visible=false;
            label5.Text="";
        }
        private static string check(List<Button> list,string str){
			string fin="";
			for(int a=0;a<3;a++){
				fin=fin+list[int.Parse(str.ToCharArray()[a].ToString())].Text;
			}
			return fin;
		}
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        private void checkwin(List<Button> list) {
                string draw="";
                bool dra=true; 
                for(int a=0;a<9;a++) {draw+=list[a].Text; if(list[a].Text==" ") {dra=false;} }
				List<string> x=new List<string>{"630","741","852","012","345","678","642","840"};
                for(int a=0;a<8;a++){
					if (check(list,x[a])=="XXX") { win(1); return; }
					else if (check(list,x[a])=="OOO") { win(2); return; }
					else if (dra) { win(3); return;}
				}
				
                if(select) {
					List<string> x1=new List<string>{"012","021","120","345","453","354","678","876","867","630","603","036","741","417","714","852","285","258","642","624","246","840","408","804"};
					List<int> x2=new List<int>{2,1,0,5,3,4,8,6,7,0,3,6,1,7,4,2,5,8,2,4,6,0,8,4};
					bool used=true;
					for(int a=0;a<x1.Count;a++){
						if(check(list,x1[a])=="OO ") { list[x2[a]].Text = "O";list[x2[a]].Enabled=false; win(2);used=false; }
				       else if(check(list,x1[a])=="XX ") { list[x2[a]].Text = "O";list[x2[a]].Enabled=false;used=false; }
					}
              
				if(used){
                    while (true){
                      int k=rnd.Next(9);
                    if(list[k].Text==" ") {
                            list[k].Enabled=false;
                            list[k].Text="O";
                            break;
                        }
                    }
                }
				
			
            }
        }
        private void win(int p) {
            if(!select) { 
            if(p==1) {
                label3.Text=(int.Parse(label3.Text)+1).ToString();
                label5.Text="Ha vinto il Giocatore X.";
            }
            if(p==2) {
                label4.Text=(int.Parse(label4.Text)+1).ToString();
                label5.Text="Ha vinto il Giocatore O.";
            }
            }
            else {
                 if(p==1) {
                label3.Text=(int.Parse(label3.Text)+1).ToString();
                label5.Text="Ha vinto il Giocatore.";
            }
            if(p==2) {
                label4.Text=(int.Parse(label4.Text)+1).ToString();
                label5.Text="Ha vinto il Computer.";
            }
            }
            if(p==3) {
                label5.Text="I due Giocatori hanno pareggiato.";
            }
            for(int a=0;a<9;a++) {list[a].Enabled=false; }
            button12.Visible=true;
        }
        
        private List<Button> list=new List<Button> ();
        private Random rnd=new Random();
        private static string s="X"; 
        private bool select=false;
    }
}
