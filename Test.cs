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
        private void Test_Load(object sender, EventArgs e)
        {
            Bitmap s=new Bitmap(500,500);
            Graphics img=Graphics.FromImage(s);
            img.Clear(Color.Black);
        }
    }
}
