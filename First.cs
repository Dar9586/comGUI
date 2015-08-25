using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace comGUI {
    public partial class First : Form {
        public First() {
            InitializeComponent();
            this.FormClosing += back;
        }

        private void button1_Click(object sender, EventArgs e) {
            label1.Text="Hai scritto: "+textBox1.Text;
            Debug.WriteLine(label1.Text);
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 this.Dispose();
                 this.Close();
               }
        }
    }
}
