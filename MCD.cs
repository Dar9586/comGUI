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
    public partial class MCD : Form {
        private string oldnum1="",oldnum2="";
        List<string>allow=new List<string> {"0","1","2","3","4","5","6","7","8","9"};
        public MCD() {
            InitializeComponent();
             this.FormClosing += back;
        }

        
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 this.Dispose();
                 this.Close();
               }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
             bool ok=true;
            for(int a=0;a<textBox2.TextLength;a++) {
                if(!allow.Contains(textBox2.Text.ToCharArray()[a].ToString())) {ok=false; }
            }      
            if(!ok) {textBox2.Text=oldnum2;}else {oldnum2=textBox2.Text; }         
        }

        private void button1_Click(object sender, EventArgs e) {
            label3.Visible=true;
            label4.Visible=true;
            try {
                long num1=long.Parse(textBox1.Text);
                long num2=long.Parse(textBox2.Text);
                if(num1<Int64.MaxValue&&num1>0&&num2<Int64.MaxValue&&num2>0) {
                    long num3;
            if (num1 < num2) {num3 = num1; }
            else{num3 = num2;}
            while (num1 % num3 != 0 || num2 % num3 != 0){num3--;}
            label3.Text="MCD: "+num3.ToString();
              if (num1 > num2){num3 = num1;}
            else{num3 = num2;}
            while (num3 % num1 != 0 || num3 % num2 != 0){num3++;}
            label4.Text="mcm: "+num3.ToString();

                }else {int h=0;int a=6/h; }
            }catch(Exception) {
                label3.Text="MCD: Numeri Invalidi";
                label4.Text="mcm: Numeri Invalidi";
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            bool ok=true;
            for(int a=0;a<textBox1.TextLength;a++) {
                if(!allow.Contains(textBox1.Text.ToCharArray()[a].ToString())) {ok=false; }
            }      
            if(!ok) {textBox1.Text=oldnum1; }else {oldnum1=textBox1.Text; }                                          
        }
    }

    
}
