using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace comGUI {
    public partial class Convertitore : Form {
        public Convertitore() {
            InitializeComponent();
             this.FormClosing += back;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            int s=(int)numericUpDown1.Value;
            if(numericUpDown1.Value<min) {numericUpDown1.Value=min;}
            else if(numericUpDown1.Value>36) {numericUpDown1.Value=36; }
            long num=to10(textBox1.Text,(int)numericUpDown1.Value);
             str=toOther(num);
            format();
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
            List<char>cha=new List<char>(textBox1.Text.ToCharArray());
            List<char> allo=new List<char>(" 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            int max=2;
            bool pass=true;
            for(int a=0;a<cha.Count;a++) {if(!allo.Contains(cha[a])||cha[a]==' ') {pass=false;break;} }
            if(pass) { 
                old=textBox1.Text;
            for(int a=0;a<cha.Count;a++) {
                    int k=allo.IndexOf(cha[a]);
                if(k>max) {max=k; }
                }
            if(max<2) { max=2;}
            min=max;
                if (numericUpDown1.Value<min) {numericUpDown1.Value=min;}
            long num=to10(textBox1.Text,(int)numericUpDown1.Value);
             str=toOther(num);
               format();
            }
            else {textBox1.Text=old; }
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        private static StringBuilder rev(string str1)
		{
            StringBuilder str=new StringBuilder();
            str.Append(str1);
			char[] array = str.ToString().ToCharArray();
			Array.Reverse(array);
			str.Remove(0, str.Length);
			str.Append(array);
			return str;
		}
        private long to10(string num,int bas ) {
            List<char> allo=new List<char>("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
             List<int> n=new List<int>();
            for(int a=0;a<num.Length;a++) {
                n.Add(allo.IndexOf(num.ToCharArray()[a]));
            }
            long final=0;
            for(int a=0;a<n.Count;a++) { final+=n[a]*(long)Math.Pow(bas,n.Count-a-1); }
            return final;}
        private List<string> toOther(long num) {
            List<char> allo=new List<char>("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            List<int> n=new List<int>();
            List<string> final=new List<string>();
            for(int a=0;a<35;a++) {
                n.Clear();
                long nn=num;
                while(nn!=0) {
                    n.Add((int)(nn%(a+2)));nn=(long)(nn/(a+2));
                }
                string part="";
                for(int b=0;b<n.Count;b++) {
                    try { 
                    part+=allo[n[b]].ToString();}catch(ArgumentOutOfRangeException) {part=".eritrevnoc elibissopmI";break;}
                }
                part=rev(part).ToString();
                final.Add(part);
            }
            if(final.Contains("Impossibile convertire.")) {final.Clear();for(int a=0;a<35;a++) {final.Add("Impossibile convertire.");} }
            return final;
        }
        private void format() {
            richTextBox1.Text="";
            for(int a=0;a<35;a++) {
                richTextBox1.SelectionColor=Color.White;
                if(a>7) { 
                richTextBox1.AppendText((a+2).ToString()+" ");}
                else { richTextBox1.AppendText("0"+(a+2).ToString()+" ");}
                if(a==0||a==6||a==8||a==14) {richTextBox1.SelectionColor=Color.Red; }
                else { richTextBox1.SelectionColor=Color.Cyan;}
                richTextBox1.AppendText(str[a]+" ");
                if(a<34) {richTextBox1.AppendText("\n"); }
        richTextBox1.SelectionColor=richTextBox1.ForeColor;
            }
        }

        private  List<string> str=new List<string>();
        private string old="";
        private int min=2;

    }
}
