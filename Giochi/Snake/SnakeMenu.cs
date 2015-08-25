using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class SnakeMenu : Form {
        public SnakeMenu() {
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
            Snake s=new Snake();
            s.men=this;
            s.Show();
            Hide();
        }
    }
}
