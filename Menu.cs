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
    
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

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
