using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace comGUI {
    public partial class Convertitore : Form {
        public Convertitore() {
            InitializeComponent();
             FormClosing += back;
        }
         void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            int s=(int)numericUpDown1.Value;
            if(numericUpDown1.Value<min) {numericUpDown1.Value=min;}
            List<int>maxlen=new List<int>{0,0,63,40,32,28,25,23,21,20,19,19,18,18,17,17,16,16,16,15,15,15,15,14,14,14,14,14,14,13,13,13,13,13,13,13,13};
            if(textBox1.Text.Length>maxlen[(int)numericUpDown1.Value]) {textBox1.Text=textBox1.Text.Substring(0,maxlen[(int)numericUpDown1.Value]); }
            textBox1.MaxLength=maxlen[(int)numericUpDown1.Value];
            /*ulong num=to10(textBox1.Text,(int)numericUpDown1.Value);
             str=toOther(num);
            format();*/
        }
         void textBox1_TextChanged(object sender, EventArgs e) {
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
            /*ulong num=to10(textBox1.Text,(int)numericUpDown1.Value);
             str=toOther(num);
               format();*/
            }
            else {textBox1.Text=old; }
        }
         void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
         static StringBuilder rev(string str1)
		{
            StringBuilder str=new StringBuilder();
            str.Append(str1);
			char[] array = str.ToString().ToCharArray();
			Array.Reverse(array);
			str.Remove(0, str.Length);
			str.Append(array);
			return str;
		}
         ulong to10(string num,int bas ) {
            List<char> allo=new List<char>("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
             List<int> n=new List<int>();
            for(int a=0;a<num.Length;a++) {
                n.Add(allo.IndexOf(num.ToCharArray()[a]));
                
            }
            ulong final=0;
            for(int a=0;a<n.Count;a++) {Debug.WriteLine(n[a]+"*"+bas+"^"+(n.Count-a-1)+"+"); final+=(ulong)n[a]*(ulong)Math.Pow(bas,n.Count-a-1); }
            return final;}
         List<string> toOther(ulong num) {
            List<char> allo=new List<char>("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            List<int> n=new List<int>();
            List<string> final=new List<string>();
            try { 
            for(int a=0;a<35;a++) {
                n.Clear();
                ulong nn=num;
                while(nn!=0) {
                       // Debug.WriteLine(nn+" "+(a+2)+" "+((int)(nn%(ulong)(a+2))));
                    n.Add((int)(nn%(ulong)(a+2)));nn=(ulong)(nn/(ulong)(a+2));
                }
                string part="";
                for(int b=0;b<n.Count;b++) {
                    part+=allo[n[b]].ToString();
                }
                //Debug.WriteLine(part);
                part=rev(part).ToString();
                final.Add(part);
            }}catch(ArgumentOutOfRangeException) {final.Clear();for(int a=0;a<35;a++) {final.Add("Impossibile convertire.");}}
            return final;
        }
         void format() {
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
          List<string> str=new List<string>();
         string old="";
         int min=2;

        private void button1_Click(object sender, EventArgs e)
        {
            ulong num=to10(textBox1.Text,(int)numericUpDown1.Value);
             str=toOther(num);
             format();
        }
    }
}
