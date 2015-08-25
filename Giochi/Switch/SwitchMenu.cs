using System;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class SwitchMenu : Form {
        public SwitchMenu() {
            InitializeComponent();
        this.FormClosing += back;
        }
        private void button1_Click(object sender, EventArgs e) {
            label4.Text="Hai Perso";
            main.swi.re=false;
            timer1.Stop();
            button1.Visible=false;
            button2.Visible=true;
            label4.Visible=true;
            label4.ForeColor=Color.Red;
        }
        private void button2_Click(object sender, EventArgs e) {
            main.Show(); main.swi.Dispose();Dispose();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            if(label4.Visible==false)
            { time++;}
            string t="";
            if(time<600) {t+="0"; }
            t+=((time-(time%60))/60).ToString()+":";
            if(time%60<10) {t+="0"; }
            t+=(time%60).ToString();
            label1.Text="Tempo: "+t;
        }
        private void back(object sender, EventArgs e) {
            main.Show(); main.swi.Dispose();Dispose();
        }

        public SwitchSetting main;
        int time=0;
    }
}
