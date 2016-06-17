using System;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class MemorySetting : Form {
        public MemorySetting() {
            InitializeComponent();
        this.FormClosing += back;
            if(maxhe>50) {maxhe=50; }
            if(maxwi>50) {maxwi=50; }
            label1.Text=maxwi.ToString();
            label2.Text=maxhe.ToString();
        }
         void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
          void textBox1_TextChanged(object sender, EventArgs e) {
            if(textBox1.Text!="") {  try {int h=int.Parse(textBox1.Text);old1=textBox1.Text;} catch(Exception) {textBox1.Text=old1; }}
        }
         void textBox2_TextChanged(object sender, EventArgs e) {
            if(textBox2.Text!="") { try {int h=int.Parse(textBox2.Text);old2=textBox2.Text;} catch(Exception) {textBox2.Text=old2; }}
        }
         void button1_Click(object sender, EventArgs e) {  
            try { b=int.Parse(textBox1.Text);
            a=int.Parse(textBox2.Text);
            if(b%2==0|a%2==0) { 
            if(b<=maxwi&&a<=maxhe) {
                    mem=new Memory();
                    memmen=new MemoryMenu();
                    mem.m=this;
                    memmen.m=this;
                   int k=b*a/2;        
                mem.createscheme(k);
                mem.Size=new Size(b*28+5,a*28+37);
                    mem.ooo=true;
            mem.Show();
            this.Hide();}}else {label5.Visible=true; }}catch(FormatException) { }
        }

         static int scwi=Screen.PrimaryScreen.Bounds.Width-10;
         static int sche=Screen.PrimaryScreen.Bounds.Height-10;
         int maxhe=sche/26-2;
         int maxwi=scwi/26;
        public MemoryMenu memmen;
         string old1="";
         string old2="";
        public Memory mem;
        public int b;
        public int a;
        
        
        
        
       
    }
}
