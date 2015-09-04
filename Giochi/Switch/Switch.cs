using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class Switch : Form {
        public Switch() {
            InitializeComponent();
        this.FormClosing += back;
        }
        private void back(object sender, EventArgs e) {
            main.Show(); main.swimen.Dispose();Dispose();
        }
        private void create(int x,int y,int te) {
            Button s=new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(24, 24);
            s.BackColor=Color.Black;
            s.ForeColor=Color.Cyan;
            if(te==1) {s.Text=main.si1.Text;}else {s.Text=main.si2.Text; }
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            s.Click += new EventHandler(buttonClick);
            Controls.Add(s);
            list.Add(s);
        }
        private void buttonClick(object sender, EventArgs e) {
            if(re) {
            if(!main.swimen.timer1.Enabled) {main.swimen.timer1.Start(); }
          int j=list.IndexOf((sender as Button));
            List<int> c=new List<int>();
            c.Add(j);
            if(j%main.b!=0) {c.Add(j-1); }
            if((j+1)%main.b!=0) {c.Add(j+1); }
            if((j-main.b)>=0) {c.Add(j-main.b); }
            if((j+main.b)<list.Count) {c.Add(j+main.b); }
            for(int a=0;a<c.Count;a++) {
                if(list[c[a]].Text==main.si1.Text) {list[c[a]].Text=main.si2.Text; }else {list[c[a]].Text=main.si1.Text; }
            }
            int full=0,voi=0;
            
            for(int a=0;a<list.Count;a++) {
                if(list[a].Text==main.si1.Text) {full++; }else {voi++; }
            }
            main.swimen.label2.Text="Completamento: "+full.ToString()+" / "+voi.ToString();
            if(full==0||voi==0) {main.swimen.button1.Visible=false; 
            re=false;
            main.swimen.button2.Visible=true; 
            main.swimen.label4.Visible=true;
            main.swimen.timer1.Stop();
            }
            }
        }
        public void createscheme(int k) {
            
            for(int a=0;a<99999;a++) {comGUI.Menu.rnd.Next(1944465); }   
            int x=5,y=2;
            for(int b=0;b<main.a;b++) {for(int a=0;a<main.b;a++) {
                    create(x,y,comGUI.Menu.rnd.Next(2));
                    x+=26;
                }
            x=5;y+=26;
            }
             int full=0,voi=0;
            for(int a=0;a<list.Count;a++) {
                if(list[a].Text==main.si1.Text) {full++; }else {voi++; }
            }
            main.swimen.label2.Text="Completamento: "+full.ToString()+" / "+voi.ToString();
        }

        public bool re=true;
        public SwitchSetting main;
        List<Button> list=new List<Button>();
    }
}
