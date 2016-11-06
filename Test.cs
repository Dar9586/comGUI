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
    public partial class Test : Form {
        public Test() {
            InitializeComponent();
            FormClosing += back;
        }
        void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        Graphics img;
        Bitmap s=new Bitmap(500,500);
        private void Test_Load(object sender, EventArgs e)
        {
        }

        int hjj=0;
        private void timer2_Tick(object sender, EventArgs e) {
            Console.WriteLine(hjj++);
        }
    }
}
