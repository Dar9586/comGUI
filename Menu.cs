using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace comGUI {
    public partial class Menu : Form {
        static List<Button>lst=new List<Button>();
        public Menu() {
            InitializeComponent();
        }
        void cb(int s,int y,string z,int ind,Size size) {
            Button x=new Button();
            x.BackColor = Color.Black;
            x.FlatStyle = FlatStyle.Flat;
            x.ForeColor = Color.Cyan;
            x.Location = new Point(s, y);
            x.Name = "button"+ind.ToString();
            x.Size = size;
            x.TabIndex = ind;
            x.Text = z;
            x.UseVisualStyleBackColor = false;
            x.Click += new EventHandler(buttonClick);
            lst.Add(x);Controls.Add(x);
        }
        void buttonClick(object sender, EventArgs e) {
            int sen=lst.IndexOf((sender as Button));
            Form s=null;
            switch(sen) {
                case 0 :s=new Test();break;
                case 1 :s=new First();break;
                case 2 :s=new MCD();break;
                case 3 :s=new Tris();break;
                case 4 :s=new Game2048();break;
                case 5 :s=new Calcolatrice();break;
                case 6 :s=new Convertitore();break;
                case 7 :s=new Tiles();break;
                case 8 :s=new Scomposizione();break;
                case 9 :s=new Semplificazione();break;
                case 10:s=new Notazione();break;
                case 11:s=new Password();break;
                case 12:s=new Simon();break;
                case 13:s=new MemorySetting();break;
                case 14:s=new SwitchSetting();break;
                case 15:s=new SnakeSingle();break;
                case 16:s=new Sudoku();break;
                case 17:s=new Piano();break;
                case 18:s=new Anagrammi();break;
                case 19:s=new Galattron();break;
                case 20:s=new MineSweeper();break;
                case 21:s=new Squash();break;
                case 22:s=new Ruffini();break;
                case 23:s=new SpinTheCircle();break;
                case 24:s=new BlackJack();break;
                case 25:s=new Sette_e_Mezzo();break;
                case 26:s=new Ten();break;
                case 27:s=new Arkanoid();break;
                case 28:s=new Browser();break;
                case 29:s=new Forza4();break;
            }if(lst[sen].Text!="WIP") { s.Show();Hide(); }
        }
        List<string>title=new List<string> {
            "Test",
            "First","MCD","Tris","2048",
            "Calcolatrice","Convertitore","Tiles","Scomposizione",
            "Semplificazione","Notazione","Password","Simon",
            "Memory","Switch","Snake","Sudoku",
            "Piano","Anagrammi","Galattron","MineSweeper",
            "Squash","Ruffini","SpinTheCircle","BlackJack",
            "Sette e Mezzo","Ten","Arkanoid","Browser",
            "Forza 4",
        };
        private void Menu_Load(object sender, EventArgs e) {
            cb(12,278,title[0],0,new Size(394, 40));
            lst[0].ForeColor=Color.Red;
            int wid=4,hei=8;
            for(int a=0;a<hei;a++) {
                for(int b=0;b<wid;b++) {
                    cb(101*b+12,29*a+12,(a*wid+b+1)>=title.Count?"WIP":title[a*wid+b+1],a*wid+b+1,new Size(95, 23));
                }
            }
        }

    }
}
