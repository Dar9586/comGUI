using System;
using System.Windows.Forms;

namespace comGUI {
    public partial class Menu : Form {
         
        public Menu() {
            InitializeComponent();
        }

        private void back(object sender, EventArgs e) {
            if (Program.start.Visible == false) {
                Program.start.Show();
            }
            else {
                Dispose();
            }
        }
        public static Random rnd=new Random(Environment.TickCount);
        private void button1_Click(object sender, EventArgs e) {
            First s=new First();
            s.Show();
            this.Hide();
        }
         
        private void button2_Click(object sender, EventArgs e) {
             MCD s=new MCD();
            s.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e) {
            Tris s=new Tris();
            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) {
            Game2048 s=new Game2048();
            s.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e) {
            Calcolatrice s=new Calcolatrice();
            s.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e) {
            Convertitore s=new Convertitore();
            s.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e) {
            Tiles s=new Tiles();
            s.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e) {
            Scomposizione s=new Scomposizione();
            s.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e) {
            Semplificazione s=new Semplificazione();
            s.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e) {
            Notazione s=new Notazione();
            s.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e) {
            Password s=new Password();
            s.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e) {
            Simon s=new Simon();
            s.Show();
            this.Hide();
        }

        public void button13_Click(object sender, EventArgs e) {
            Test s=new Test();
            s.Show();
        }

        public void button14_Click(object sender, EventArgs e) {
            MemorySetting s=new MemorySetting();
            s.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e) {
            SwitchSetting s=new SwitchSetting();
            s.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e) {
            SnakeSingle s=new SnakeSingle();
            s.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            rnd.Next();
        }

        private void button17_Click(object sender, EventArgs e) {
            Sudoku s=new Sudoku();
            s.Show();
            this.Hide();
        
        }

        private void button18_Click(object sender, EventArgs e) {
            Piano s=new Piano();
            s.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e) {
            Anagrammi s=new Anagrammi();
            s.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e) {
            Galattron s=new Galattron();
            s.Show();
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e) {
            Minesweeper s=new Minesweeper();
            s.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e) {
            test1 s=new test1();
            s.Show();
            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e) {
            Ruffini s=new Ruffini();
            s.Show();
            this.Hide();
        }

        private void button24_Click(object sender, EventArgs e) {
            BattagliaSetting s=new BattagliaSetting();
            s.Show();
            this.Hide();
        }
    }
}
