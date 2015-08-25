using System;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class SwitchSetting : Form {
        public SwitchSetting() {
            InitializeComponent();
            this.FormClosing += back;
            label1.Text=maxwi.ToString();
            label2.Text=maxhe.ToString();
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
          private void textBox1_TextChanged(object sender, EventArgs e) {
            if(textBox1.Text!="") {  try {int h=int.Parse(textBox1.Text);old1=textBox1.Text;} catch(Exception) {textBox1.Text=old1; }}
        }
        private void textBox2_TextChanged(object sender, EventArgs e) {
            if(textBox2.Text!="") { try {int h=int.Parse(textBox2.Text);old2=textBox2.Text;} catch(Exception) {textBox2.Text=old2; }}
        }
        private void button1_Click(object sender, EventArgs e) {  
            try {if(si1.Text!=si2.Text) { 
                b =int.Parse(textBox1.Text);
            a=int.Parse(textBox2.Text);
            if(b<=maxwi&&a<=maxhe) {
                    swi=new Switch();
                    swimen=new SwitchMenu();
                    swi.main=this;
                    swimen.main=this;
                        swimen.label3.Text=si1.Text+" / "+si2.Text;
                   int k=b*a/2;        
                swi.createscheme(k);
                        int n1=(b*28+5);
                        if(n1<200) {n1=200; }
                swi.Size=new Size(n1,a*28+37);
                  swimen.Show();
            swi.Show();
            this.Hide();}}else {label7.Visible=true;} }catch(FormatException) { }
        }

        private static int scwi=Screen.PrimaryScreen.Bounds.Width-10;
        private static int sche=Screen.PrimaryScreen.Bounds.Height-10;
        private int maxhe=sche/26-2;
        private int maxwi=scwi/26;
        public SwitchMenu swimen;
        private string old1="";
        private string old2="";
        public Switch swi;
        public int b;
        public int a;

        
    }
}
