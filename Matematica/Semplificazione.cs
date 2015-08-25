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
    public partial class Semplificazione : Form {
        public Semplificazione() {
            InitializeComponent();
         this.FormClosing += back;
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
          List<char> n=new List<char>(textBox1.Text.ToCharArray());
            bool ok=true;
       for(int a=0;a<n.Count;a++) {if(!num.Contains(n[a])) { ok=false;} }
       if(ok) {oldtex1=textBox1.Text;
                if(textBox1.Text!="") { 
                try { num1=long.Parse(textBox1.Text);}catch(OverflowException) {textBox1.Text=oldtex1; }
                }else {num1=0; }
            }
       else {textBox1.Text=oldtex1; }
        }
        private void textBox2_TextChanged(object sender, EventArgs e) {
            List<char> n=new List<char>(textBox2.Text.ToCharArray());
            bool ok=true;
       for(int a=0;a<n.Count;a++) {if(!num.Contains(n[a])) { ok=false;} }
       if(ok) {oldtex2=textBox2.Text;
                 if(textBox2.Text!="") { 
                 try { num2=long.Parse(textBox2.Text);}catch(OverflowException) {textBox2.Text=oldtex2; }
                }else {num2=0; }
            }
       else {textBox2.Text=oldtex1; }
        }
        private void timer1_Tick(object sender, EventArgs e) {
            if(num1!=0&&num2!=0) {
                long nu;
                if(num1<num2) {nu=num1; }
                else {nu=num2; }
                while(num1%nu!=0||num2%nu!=0) {
                    nu--;
                }
                label3.Text=((long)(num1/nu)).ToString();
                label4.Text=((long)(num2/nu)).ToString();
                label1.Text="Semplificato per "+nu.ToString();
            }else {label1.Text=label3.Text=label4.Text=""; }
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                Dispose();
               }
        }

        private List<char> num=new List<char>("0123456789".ToCharArray());
        private string oldtex1="";
        private string oldtex2="";
        private long num1=0,num2=0;
    }
}
