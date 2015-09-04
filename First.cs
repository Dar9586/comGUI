using System;
using System.Windows.Forms;

namespace comGUI {
    public partial class First : Form {
        public First() {
            InitializeComponent();
            this.FormClosing += back;
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        private void button1_Click(object sender, EventArgs e) {
            label1.Text="Hai scritto: "+textBox1.Text;
        }  
    }
}
