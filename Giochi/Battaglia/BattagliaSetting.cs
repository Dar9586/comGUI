using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class BattagliaSetting : Form {
        public BattagliaSetting() {
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
            Battaglia s=new Battaglia();
            s.oooo=this;
            s.numBoat.Add((int)numericUpDown5.Value);
            s.numBoat.Add((int)numericUpDown4.Value);
            s.numBoat.Add((int)numericUpDown3.Value);
            s.numBoat.Add((int)numericUpDown2.Value);
            s.numBoat.Add((int)numericUpDown1.Value);
            
            s.bas=(int)numericUpDown6.Value;
            s.hei=(int)numericUpDown7.Value;
            s.Show();
            this.Hide();
        }

    }
}
