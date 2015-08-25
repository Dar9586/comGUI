using System;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class MemoryMenu : Form {
        public MemoryMenu() {
            InitializeComponent();
            this.FormClosing+=back;
        }
        private void back(object sender, EventArgs e) {
           m.Show(); m.mem.Dispose();
        }
        private void button1_Click(object sender, EventArgs e) {
            m.mem.lose();
            button1.Visible=false;
            button2.Visible=true;
            label4.Visible=true;
            label4.ForeColor=Color.Red;
        }
        private void button2_Click(object sender, EventArgs e) {
            m.Show(); m.mem.Dispose();this.Dispose();
        }
        public void timer1_Tick(object sender, EventArgs e) {
            if(label4.Visible==false)
            { time++;}
            string t="";
            if(time<600) {t+="0"; }
            t+=((time-(time%60))/60).ToString()+":";
            if(time%60<10) {t+="0"; }
            t+=(time%60).ToString();
            label1.Text="Tempo: "+t;
        }

        public MemorySetting m;
        private int time=0;
    }
}
