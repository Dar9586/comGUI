﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace comGUI {
    public partial class Simon : Form {
        public Simon() {
            InitializeComponent();
            this.FormClosing += back;
            for(int a=0;a<99999;a++) {comGUI.Menu.rnd.Next(65169416); }
           recolor();
        }
        private void yellow_Click(object sender, EventArgs e) {
            if(ok) { user.Add(1);last=1;}
        }
        private void green_Click(object sender, EventArgs e) {
            if(ok) { user.Add(3);last=3;}
        }
        private void start_Click(object sender, EventArgs e) {
            iii=false;
            recolor();
            user.Clear();
            list.Clear();
            timer1.Enabled=true;
            start.Visible=false;
            cyan.Enabled=green.Enabled=red.Enabled=yellow.Enabled=true;
            start.Text="Rincomincia";
        }
        private void timer1_Tick(object sender, EventArgs e) {
            comGUI.Menu.rnd.Next(4);
            point.Text=(list.Count-1).ToString();
            if(list.Count==0) {point.Text="0"; }
            for(int a=0;a<user.Count;a++) {
                if(list[a]!=user[a]) {lose(); }}
            if(list.Count==user.Count&&timer1.Enabled) {user.Clear();list.Add(comGUI.Menu.rnd.Next(4));color(); }
        }
        private void cyan_Click(object sender, EventArgs e) {
           if(ok) { user.Add(0);last=0;}
        }
        private void red_Click(object sender, EventArgs e) {
           if(ok) { user.Add(2);last=2;}
        }
        private void col_Tick(object sender, EventArgs e) {
            red.BackColor=R;
            cyan.BackColor=C;
            yellow.BackColor=Y;
            green.BackColor=G;
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        private async void lose2() {
            if(last==0) {C=Color.Black; }
            else if(last==1) {Y=Color.Black; }
            else if(last==2) {R=Color.Black; }
            else if(last==3) {G=Color.Black; }
            int h=list[user.Count-1];
            while(iii) { 
            if(h==0) {cyan.BackColor=Color.Cyan; await Task.Delay(50);cyan.BackColor=Color.DarkCyan; }
            else if(h==1) {yellow.BackColor=Color.Yellow; await Task.Delay(50);yellow.BackColor=Color.DarkOrange;  }
            else if(h==2) {red.BackColor=Color.Red; await Task.Delay(50);red.BackColor=Color.DarkRed; }
            else if(h==3) {green.BackColor=Color.Green; await Task.Delay(50);green.BackColor=Color.DarkGreen; }}
        }
        private async void color() {
            ok=false;
            await Task.Delay(350);
            for(int a=0;a<list.Count;a++) {
                //Debug.Write(list[a]+" ");
                int j=list[a];
                if(j==0) {C=Color.Cyan; }
                else if(j==1) {Y=Color.Yellow; }
                else if(j==2) {R=Color.Red; }
                else if(j==3) {G=Color.Green; }
                await Task.Delay(350);
                recolor();
                await Task.Delay(50);}
            //Debug.WriteLine("");
            ok=true;}    
        private void recolor() {
                C=Color.DarkCyan;
                Y=Color.DarkOrange;
                R=Color.DarkRed;
                G=Color.DarkGreen; }
        private void lose() {
            start.Visible=true;
            ok=false;
            timer1.Enabled=false;
            iii=true;
            lose2();
        }

        private List<int> list=new List<int>();
        private List<int> user=new List<int>();
        private static Color C=new Color();
        private static Color Y=new Color();
        private static Color R=new Color();
        private static Color G=new Color();
        
        private bool iii=false;
        private bool ok=false;
        private int last=0;
    }
}
