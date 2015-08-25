using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {
    public partial class Scomposizione : Form {
        public Scomposizione() {
            InitializeComponent();
        this.FormClosing += back;
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
            List<char> num=new List<char>("0123456789".ToCharArray());
            List<char> num2=new List<char>(textBox1.Text.ToCharArray());
            bool ok=true;
            for(int a=0;a<textBox1.TextLength;a++) {
                if(!num.Contains(num2[a])) { ok=false;break;}
            }
            if(ok) {
                olds =textBox1.Text;
                if(textBox1.Text!=""){     
               try { long num1=long.Parse(textBox1.Text);
                if(num1>1) { 
                scom(num1);
                    }
                else if(num1==1) {richTextBox1.SelectionColor=Color.Cyan;
                richTextBox1.AppendText("1");
                richTextBox1.SelectionColor=Color.White;
                richTextBox1.AppendText("  |  ");
                richTextBox1.SelectionColor=Color.Red;
                richTextBox1.AppendText("1\n");
                            label1.Text="1"; }
                else if(num1==0) {richTextBox1.Text="Impossibile scomporre 0";label1.Text="0"; }
                    } catch(OverflowException) {label1.Text="Numero Invalido.";richTextBox1.Text="Numero Invalido.";} }
            }
            else {textBox1.Text=olds; }
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        private void scom(long num) {
            int s=num.ToString().Length;
            label1.Text="";
            richTextBox1.Text="";
            List<long> list=new List<long>();
            while(num!=1) {
                long nn=2;
                while(num%nn!=0) {nn++; }
                list.Add(nn);
                for(int a=0;a<s-num.ToString().Length;a++) {richTextBox1.AppendText("  "); }
                richTextBox1.SelectionColor=Color.Cyan;
                richTextBox1.AppendText(num.ToString());
                richTextBox1.SelectionColor=Color.White;
                richTextBox1.AppendText("  |  ");
                richTextBox1.SelectionColor=Color.Red;
                richTextBox1.AppendText(nn.ToString()+"\n");
                num=(long)num/nn;
            }
            for(int a=0;a<s-1;a++) {richTextBox1.AppendText("  "); }
                richTextBox1.SelectionColor=Color.Cyan;
                richTextBox1.AppendText("1");
                richTextBox1.SelectionColor=Color.White;
                richTextBox1.AppendText("  |  ");
                richTextBox1.SelectionColor=Color.Red;
                richTextBox1.AppendText("1\n");
            List<long> fin1=new List<long>();
            List<long> fin2=new List<long>();
            for(int a=0;a<list.Count;a++) {if(!fin1.Contains(list[a])) {fin1.Add(list[a]); } }
            for(int a=0;a<fin1.Count;a++) {fin2.Add(0); }
            for(int a=0;a<list.Count;a++) {fin2[fin1.IndexOf(list[a])]++; }
            for(int a=0;a<fin1.Count;a++) {if(fin2[a]!=1) { label1.Text+=fin1[a]+" ^ "+fin2[a]+" * ";}else {label1.Text+=fin1[a]+" * ";} }
            label1.Text=label1.Text.Substring(0,label1.Text.Length-3);

        }

        private string olds="";
    }
}
